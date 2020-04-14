using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    int ColsHero, ColsEnemy;
    readonly List<Hero> heroes = new List<Hero>();
    readonly List<IEnemy> enemies = new List<IEnemy>();
    readonly List<Features> features = new List<Features>();
    readonly List<EnFeatures> enFeatures = new List<EnFeatures>();
    FightSteps fightSteps;

    void Start()
    {
        var Typeses = new List<System.Type>();
        {
            var AllType = Assembly.GetExecutingAssembly();
            var interfaseType = typeof(IEnemy);



            foreach (var type in AllType.GetTypes())
            {
                if (interfaseType.IsAssignableFrom(type))
                    Typeses.Add(type);
            }

            Typeses.Remove(interfaseType);

        }
        if (GlobalVaribles.Heros.Count < 4)
            ColsEnemy = Random.Range(1, GlobalVaribles.Heros.Count + 3);
        else
            ColsEnemy = Random.Range(1, 7);

        if (ColsEnemy > GlobalVaribles.Heros.Count)
            ColsHero = GlobalVaribles.Heros.Count;
        else
            ColsHero = ColsEnemy - (Random.Range(0, 10) > 6 && ColsEnemy >= 3 ? Random.Range(0, 3) : 0);

        for (int i = 0; i < ColsEnemy; i++) { enemies.Add((IEnemy)System.Activator.CreateInstance(Typeses[Random.Range(0, Typeses.Count)])); enemies[i].SetHealth(Random.Range(100, GlobalVaribles.ColsStep * 1000)); enemies[i].SetPower(Random.Range(GlobalVaribles.ColsStep, GlobalVaribles.ColsStep * 20)); }
        var cHeros = new List<Hero>(GlobalVaribles.Heros);
        
        GameObject baseFas = gameObject.transform.Find("Image").Find("Heros").GetChild(0).gameObject;
        GameObject imageHero = gameObject.transform.Find("View").Find("Heros").GetChild(0).gameObject;
        bool HaveOneLife = false;
        for (int i = 0; i < ColsHero; i++)
        {

            int f = 0;
            while (!HaveOneLife)
            {
                f = Random.Range(0, cHeros.Count);
                HaveOneLife = cHeros[f].PersentHealth() != 0;
            }
            heroes.Add(cHeros[f]);
            cHeros.RemoveAt(f);
            Features fas;


            fas = new Features(Instantiate(baseFas, new Vector3(baseFas.transform.position.x, baseFas.transform.position.y - (50 * i)), baseFas.transform.rotation, baseFas.transform.parent), Instantiate(imageHero, new Vector3(imageHero.transform.position.x + (i >= 3 ? 250 - 80 * (i - 3) : -80 * i), imageHero.transform.position.y + (-80 * (i >= 3 ? (i - 3) : i))), imageHero.transform.rotation, imageHero.transform.parent));

            features.Add(fas);
            features[i].Refresh(heroes[i]);
        }
        Destroy(imageHero);
        Destroy(baseFas);

        GameObject imageEnemy = gameObject.transform.Find("View").Find("Enemys").GetChild(0).gameObject;
        baseFas = gameObject.transform.Find("Image").Find("Enemys").GetChild(0).gameObject;
        for (int i = 0; i < ColsEnemy; i++)
        {
            EnFeatures eFas;

            eFas = new EnFeatures(Instantiate(baseFas, new Vector3(baseFas.transform.position.x, baseFas.transform.position.y - (50 * i)), baseFas.transform.rotation, baseFas.transform.parent), Instantiate(imageEnemy, new Vector3(imageEnemy.transform.position.x - (i >= 3 ? 250 - 80 * (i - 3) : -80 * i), imageEnemy.transform.position.y + (-80 * (i >= 3 ? (i - 3) : i))), imageEnemy.transform.rotation, imageEnemy.transform.parent));
            enFeatures.Add(eFas);
            eFas.Refresh(enemies[i]);
        }



        Destroy(imageEnemy);
        Destroy(baseFas);

        gameObject.AddComponent<FightSteps>();
        gameObject.GetComponent<FightSteps>().newFightSteps(heroes, enemies, features, enFeatures, gameObject.transform.Find("Buttons"));
        fightSteps = gameObject.GetComponent<FightSteps>();
    }
    void Update()
    {
        if (!fightSteps.loseBattle || !fightSteps.winBattle)
        {
            for (int i = 0; i < enemies.Count; i++)
                if (enemies[i].GetHealth() == 0)
                    GlobalVaribles.Kills++;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Mods/Win_and_Lose");
        }
        if (fightSteps.StepOver && !fightSteps.Ending)
        {
            heroes.Clear();
            var cHeros = new List<Hero>(GlobalVaribles.Heros);
            bool HaveOneLife = false;
            for (int i = 0; i < ColsHero; i++)
            {
                int f = Random.Range(0, cHeros.Count);
                while (!HaveOneLife)
                {
                    if (!fightSteps.loseBattle || !fightSteps.winBattle)
                        break;
                    f = Random.Range(0, cHeros.Count);
                    HaveOneLife = cHeros[f].PersentHealth() != 0;
                }
                heroes.Add(cHeros[f]);
                cHeros.RemoveAt(f);
                features[i].Refresh(heroes[i]);
            }
            fightSteps.Refresh(heroes, enemies, features, enFeatures);
        }
    }
}
