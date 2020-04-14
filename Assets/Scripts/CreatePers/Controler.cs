using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Controler : MonoBehaviour
{
    readonly int[] maxValue = new int[3];

    InputField inName;

    public static int[] Left = new int[3],
             Right = new int[3];
    readonly Slider[,] sliders = new Slider[2, 3];
    readonly Image[] im = new Image[3];
    readonly List<Sprite[]> sprites = new List<Sprite[]>();
    Sprite[] colorEye;
    Image colorE;
    readonly Text[] Nums = new Text[3];
    Text Characters;
    CharactersSc firstValue;

    Reader Male;
    Reader Female;

    void FirstPerson()
    {

        Hero hero;
        Sprite[] sprites = new Sprite[4];
        Color[] colors = new Color[4];
        for (int i = 0; i < 4; i++)
        {
            if (i == 3)
            {
                sprites[i] = colorE.sprite;
                colors[i] = new Color(sliders[1, 0].value, sliders[1, 1].value, sliders[1, 2].value);
            }
            else
            {
                colors[i] = i > 0 ? Color.white : new Color(sliders[0, 0].value, sliders[0, 1].value, sliders[0, 2].value);
                sprites[i] = im[i].sprite;
            }
        }
        string Name = inName.text == "" ? (firstValue.Genger[15] == 'Ж' ? Female.GetRandomVal() : Male.GetRandomVal()) : inName.text;
        inName.text = firstValue.Genger[15] == 'Ж' ? Female.GetRandomVal() : Male.GetRandomVal();
        hero = new Hero(Name, new CharactersSc(firstValue), sprites, colors);
        GlobalVaribles.Heros.Add(hero);
    }

    void Randomaze()
    {
        for (int i = 0; i < 3; i++)
        {
            int f = Random.Range(0, sprites[i].Length);
            im[i].sprite = sprites[i][f];
            if (i == 1) colorE.sprite = colorEye[f];
            Nums[i].text = $"{f}";
            if (i != 2)
            {
                for (int j = 0; j < 3; j++)
                    sliders[i, j].value = Random.Range(0f, 1f);
                if (i == 1)
                    colorE.color = new Color(sliders[i, 0].value, sliders[i, 1].value, sliders[i, 2].value);
                else
                    im[i].color = new Color(sliders[i, 0].value, sliders[i, 1].value, sliders[i, 2].value);
            }
        }

        firstValue.SimpleRefresh();
        Characters.text = firstValue.FullText();
    }


    void Start()
    {

        Male = new Reader(@"Names\Male.txt");
        Female = new Reader(@"Names\Female.txt");

        Button comlpete = gameObject.transform.parent.GetChild(3).GetChild(1).GetComponent<Button>();
        Button refresh = gameObject.transform.parent.GetChild(3).GetChild(0).GetComponent<Button>();
        refresh.onClick.AddListener(Randomaze);
        comlpete.onClick.AddListener(FirstPerson);
        GUIStyle style = new GUIStyle
        {
            richText = true
        };
        Characters = gameObject.transform.parent.GetChild(1).GetChild(0).GetComponent<Text>();
        firstValue = new CharactersSc();
        Characters.text = firstValue.FullText();
        inName = gameObject.transform.GetChild(0).GetComponent<InputField>();
        for (int i = 1; i < 4; i++)
        {
            im[i - 1] = gameObject.transform.parent.Find("Images").GetChild(i + 1).GetComponent<Image>();
            string s = "";
            switch (i)
            {
                case 1: { s = "Heir"; break; }
                case 2: { s = "Eye/Sprite"; break; }
                case 3: { s = "Mouse"; break; }
            }
            sprites.Add(Resources.LoadAll<Sprite>("Image/CreatePers/Elements/" + s) as Sprite[]);
            if (i == 2) { colorEye =  (Resources.LoadAll<Sprite>("Image/CreatePers/Elements/Eye/Colored") as Sprite[]).Clone() as Sprite[]; colorE = gameObject.transform.parent.Find("Images").GetChild(1).GetComponent<Image>(); colorE.sprite = colorEye[0]; }
            im[i - 1].sprite = sprites[i - 1][0];
            maxValue[i - 1] = sprites[i - 1].Length;
            Nums[i - 1] = gameObject.transform.GetChild(i).GetChild(1).GetComponent<Text>();
            Left[i - 1] = 0;
            Right[i - 1] = 0;
            if (i == 3) break;
            for (int j = 0; j < 3; j++) sliders[i - 1, j] = gameObject.transform.GetChild(i).GetChild(4).GetChild(j).GetComponent<Slider>();
        }
        Randomaze();
    }

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Left[i] != 0)
            {
                int f;
                if (Left[i] <= int.Parse(Nums[i].text))
                    f = int.Parse(Nums[i].text) - Left[i];
                else
                    f = maxValue[i] + int.Parse(Nums[i].text) - Left[i];
                Left[i] = 0;
                im[i].sprite = sprites[i][f];
                if (i == 1)
                    colorE.sprite = colorEye[f];
                Nums[i].text = $"{f}";
            }
            if (Right[i] != 0)
            {
                int f;
                if (Right[i] < (maxValue[i] - int.Parse(Nums[i].text)))
                    f = int.Parse(Nums[i].text) + Right[i];
                else
                    f = int.Parse(Nums[i].text) - maxValue[i] + Right[i];
                Right[i] = 0;
                im[i].sprite = sprites[i][f];
                if (i == 1)
                    colorE.sprite = colorEye[f];
                Nums[i].text = $"{f}";
            }
            if (i == 1)
                colorE.color = new Color(sliders[i, 0].value, sliders[i, 1].value, sliders[i, 2].value);
            else
                if (i == 0)
                    im[i].color = new Color(sliders[i, 0].value, sliders[i, 1].value, sliders[i, 2].value);
        }
    }
}
