using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Person : MonoBehaviour
{
    Text text;
    Transform hero;
    CharactersSc charactersSc;
    Hero newHero;
    Sprite[] heirs, eyesBack, eyesFor, mouse;
    readonly Reader Male = new Reader(@"Names\Male.txt");
    readonly Reader Female = new Reader(@"Names\Female.txt");

    void End(bool val)
    {
        if (val)
            GlobalVaribles.Heros.Add(newHero);
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Selector");
    }

    void Start()
    {

        text = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        hero = gameObject.transform.GetChild(0).GetChild(0);
        charactersSc = new CharactersSc();
        heirs = Resources.LoadAll<Sprite>("Image/CreatePers/Elements/Heir") as Sprite[];
        mouse = Resources.LoadAll<Sprite>("Image/CreatePers/Elements/Mouse") as Sprite[];
        eyesBack = Resources.LoadAll<Sprite>("Image/CreatePers/Elements/Eye/Colored") as Sprite[];
        eyesFor = Resources.LoadAll<Sprite>("Image/CreatePers/Elements/Eye/Sprite") as Sprite[];

        int eyeId = Random.Range(0, eyesFor.Length);

        Sprite[] f =
       {
            heirs[Random.Range(0, heirs.Length)],
            eyesFor[eyeId],
            mouse[Random.Range(0, mouse.Length)],
            eyesBack[eyeId]
        };

        Color[] c = 
        {
            new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)),
            new Color(1f, 1f, 1f),
            new Color(1f, 1f, 1f),
            new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)),
        };

        text.supportRichText = true;
        newHero = new Hero(charactersSc.Genger[15] == 'Ж' ? Female.GetRandomVal() : Male.GetRandomVal(), charactersSc, f, c);
        text.text = $"<i><size={(5 + text.fontSize).ToString()}>{newHero.GetName()}</size></i>\n\n"  + charactersSc.FullText();

        Image[] i =
        {
            hero.Find("Heir").GetComponent<Image>(),
            hero.Find("Eye").GetComponent<Image>(),
            hero.Find("Mouse").GetComponent<Image>(),
            hero.Find("ColEye").GetComponent<Image>()
        };
        newHero.Display(i);


        gameObject.transform.GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
        gameObject.transform.GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();

        gameObject.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => End(true));
        gameObject.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => End(false));
    }
}
