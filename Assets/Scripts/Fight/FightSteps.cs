using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSteps : MonoBehaviour
{ 
    IEnumerator Animate(IFeatures feature, params Transform[] argv)
    {
        if (!feature.GetActiveAnimate())
        {
            float[,] startPos = new float[argv.Length, 2];
            for (int i = 0; i < argv.Length; i++)
            {
                startPos[i, 0] = argv[i].transform.position.x;
                startPos[i, 1] = argv[i].transform.position.y;
            }

            int o = Random.Range(1, 15);
            bool xMove = Random.Range(0, 2) == 1;
            bool yMove = Random.Range(0, 2) == 1;
            for (int i = 0; i < o; i++)
            {
                int xVector = Random.Range(1, 10) * (xMove ? 1 : -1);
                int yVector = Random.Range(1, 10) * (yMove ? 1 : -1);
                yield return new WaitForSeconds(0.01f);
                foreach (var j in argv)
                {
                    j.transform.position = new Vector3(j.transform.position.x + xVector, j.transform.position.y + yVector);
                }
                xMove = !xMove;
                yMove = !yMove;
            }

            for (int i = 0; i < argv.Length; i++)
                argv[i].transform.position = new Vector3(startPos[i, 0], startPos[i, 1]);
            feature.InvertActiveAnimate();
        }
    }


    List<Hero> heroes;
    List<IEnemy> enemies;
    List<EnFeatures> enFeatures;
    List<Features> features;
    Transform parentOfButton;
    readonly bool[] HaveAbility = new bool[8];

    int NumHero = 0;
    public bool StepOver = false;

    int SmartRandomHero()
    {
        
        var t = false;
        for (int i = 0; i < heroes.Count; i++)
        {
            t = t || (heroes[i].PersentHealth() != 0);
        }
        if (!t) return -1;
        int u = Random.Range(0, heroes.Count);
        while (heroes[u].PersentHealth() == 0) u = Random.Range(0, heroes.Count);
        return u;
    }

    int SmartRandomEnemy()
    {
        var t = false;
        for (int i = 0; i < enemies.Count; i++)
        {
            t = t || (enemies[i].PersentHealth() != 0);
        }
        if (!t) return -1;
        int u = Random.Range(0, enemies.Count);
        while (!enemies[u].Life()) u = Random.Range(0, enemies.Count);
        return u;
    }

    void BeforeStep(int j)
    {
        for (int i = 0; i < 8; i++)
        {
            HaveAbility[i] = heroes[j].HaveAbility(i);
        }
    }

    public bool winBattle = true;
    public bool loseBattle = true;
    public bool Ending = false;

    IEnumerator EndStep()
    {
        Ending = true;
        var t = false;
        for (int i = 0; i < enemies.Count; i++)
        {
            t = t || enemies[i].Life();
            if (enemies[i].Life())
            {
                var u = SmartRandomHero();
                if (u == -1) break;
                heroes[u].Damaging(enemies[i].GetPower());
                if (!features[u].GetActiveAnimate()) 
                {
                    StartCoroutine(Animate(features[u], features[u].outObjects()));
                    features[u].InvertActiveAnimate();
                    if (heroes[u].PersentHealth() == 0) features[u].Refresh(heroes[u]);
                }

            }
        }
        yield return new WaitForSeconds(0.3f);
        winBattle = t;
        if (!winBattle)
            yield break;
        
            t = false;
            for (int i = 0; i < GlobalVaribles.Heros.Count; i++)
            {
                t = t || (GlobalVaribles.Heros[i].PersentHealth() != 0);
            }
            loseBattle = t;
        ButtonInTouch.isCanPressed = true;
        Ending = false;
    }

    void IncHero()
    {
        NumHero++;
        
        while (NumHero < heroes.Count && heroes[NumHero].PersentHealth() == 0)
        {
            NumHero++;
        }
        if (NumHero == heroes.Count) return;
        if (NumHero > heroes.Count) NumHero = 0;

        BeforeStep(NumHero);
        for (int i = 0; i < 8; i++)
        {
            parentOfButton.GetChild(i).GetComponent<UnityEngine.UI.Button>().gameObject.SetActive(HaveAbility[i]);
        }
        features[NumHero].NextStage();
    }

    void ButWork(int i)
    {
        if (!Ending)
        {

            switch (i)
            {
                case 0:
                    var u = SmartRandomEnemy();
                    if (u == -1 || Ending) break;
                    if (NumHero >= heroes.Count) return;
                    enemies[u].Damaging(heroes[NumHero].GetPower());
                    enFeatures[u].Refresh(enemies[u]);
                    if (!enFeatures[u].GetActiveAnimate())
                    {
                        StartCoroutine(Animate(enFeatures[u], enFeatures[u].outObjects()));
                        enFeatures[u].InvertActiveAnimate();
                    }
                    break;
                case 1:
                    heroes[NumHero].Defender = true;
                    break;
                case 2:
                    heroes[NumHero].Heal(100);
                    break;
                case 3:  // Run
                    break;


                case 4:  // Special Hero Ability
                    break;
                case 5:  // Special Weapun Ability
                    break;
                case 6:  // Special Combination
                    break;
                case 7:  // Anigilation Ability
                    break;


            }
            var t = false;
            for (int j = 0; j < enemies.Count; j++)
            {
                t = t || enemies[j].Life();
            }
            winBattle = t;
            if (!winBattle)
                return;
            if (NumHero >= heroes.Count) return;
            features[NumHero].NextStage();
            IncHero();
            if (NumHero >= heroes.Count)
            {
                StepOver = true;
                StartCoroutine(EndStep());
            }
            ButtonInTouch.isCanPressed = true;
        }
    }
    public void Refresh(List<Hero> _heroes, List<IEnemy> _enemies, List<Features> _features, List<EnFeatures> _enFeatures)
    {
        heroes = _heroes;
        enemies = _enemies;
        features = _features;
        enFeatures = _enFeatures;

        for (int i = 0; i < heroes.Count; i++)
            features[i].Refresh(heroes[i]);

        for (int i = 0; i < enemies.Count; i++)
            enFeatures[i].Refresh(enemies[i]);

        StepOver = false;
        IncHero();
    }



    public void newFightSteps(List<Hero> _heroes, List<IEnemy> _enemies, List<Features> _features, List<EnFeatures> _enFeatures, Transform _parentOfButton)
    {

        heroes = _heroes;
        enemies = _enemies;
        features = _features;
        enFeatures = _enFeatures;
        parentOfButton = _parentOfButton;

        for (int i = 0; i < parentOfButton.transform.childCount; i++)
        {
            int i1 = i;
            parentOfButton.GetChild(i).GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            parentOfButton.GetChild(i).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ButWork(i1));
        }
        BeforeStep(NumHero);
        for (int i = 0; i < 8; i++)
        {
            parentOfButton.GetChild(i).GetComponent<UnityEngine.UI.Button>().gameObject.SetActive(HaveAbility[i]);
        }
        features[0].NextStage();
    }


}
