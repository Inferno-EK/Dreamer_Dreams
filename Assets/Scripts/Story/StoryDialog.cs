using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoryDialog : MonoBehaviour
{
    [SerializeField] private double LettersForSecond = 30f;
    [SerializeField] private double FraseDelay = 1f;
    [SerializeField] private string fileName = null;
    [SerializeField] private UnityEngine.UI.Text Name;
    [SerializeField] private UnityEngine.UI.Text Text;
    struct Frase 
    {
        public string Name;
        public Color nameColor;
        public string Text;

        public Frase(string Name, Color nameColor, string Text)
        {
            this.Name = Name;
            this.nameColor = nameColor;
            this.Text = Text;
        }
    }

    private List<Frase> _frases;
    private bool fraseEnd;
    private System.Timers.Timer timer;
    private int numberFrase;
    private int i;
    private double delay;
    private void Awake()
    {
        CharactersSc charactersSc;
        Reader Male = new Reader(@"Names\Male.txt");
        Reader Female = new Reader(@"Names\Female.txt");
        charactersSc = new CharactersSc();

        char[] traslateTemperament = { 'х', 'с', 'ф', 'м' };

        _frases = new List<Frase>();
        Reader all = new Reader(fileName);
        char temperamentG = ' ';
        char gengerG = ' ';
        string gname = "";
        try
        {
            temperamentG = traslateTemperament[GlobalVaribles.Heros[0].MyProp.Temperament];
            gengerG = GlobalVaribles.Heros[0].MyProp.Genger[15].ToString().ToLower()[0];
            gname = GlobalVaribles.Heros[0].GetName();
        }
        catch (System.Exception)
        {
            temperamentG = traslateTemperament[charactersSc.Temperament];
            gengerG = charactersSc.Genger[15].ToString().ToLower()[0];
            gname = charactersSc.Genger[15] == 'Ж' ? Female.GetRandomVal() : Male.GetRandomVal();
        }

        char temperamentN = traslateTemperament[charactersSc.Temperament];
        char gengerN = charactersSc.Genger[15].ToString().ToLower()[0];
        string nname = charactersSc.Genger[15] == 'Ж' ? Female.GetRandomVal() : Male.GetRandomVal();

        List<string> allText = (new Reader(fileName)).GetAllVal();
        Stack<bool> condinios = new Stack<bool>();
        condinios.Push(true);
        foreach (var i in allText)
        {
            if (i[0] == '?')
            {
                bool resG = false;
                bool resN = false;
                int j = 1;
                while (i[j] != ' ')
                {
                    if (i[j] == '.')
                    {
                        resG = true;
                        resN = true;
                    }
                    resG = resG || i[j] == temperamentG;
                    resN = resN || i[j] == temperamentN;
                    j++;
                }
                j++;
                resG = resG && i[j] == gengerG && condinios.Peek();
                resN = resN && i[j] == gengerN && condinios.Peek();

                if (i[j + 2] == 'г') condinios.Push(resG);
                else condinios.Push(resN);
            }
            else if (i[0] == '!')
            {
                condinios.Push(!condinios.Pop());
            }
            else if (i[0] == '.')
            {
                condinios.Pop();
            }
            else
            {
                if (condinios.Peek())
                {
                    string a = i.Replace("~г~", gname);
                    a = a.Replace("~н~", nname);
                    string name = "";
                    string text = "";
                    int j = 0;
                    for (; a[j] != ':'; ++j)
                    {
                        name += a[j];
                    }
                    j++;
                    for (; j < a.Length; ++j)
                    {
                        text += a[j];
                    }
                    _frases.Add(new Frase(name, Color.white, text));
                }
            }

        }




    }

   
    private void Start()
    {
        i = 0;
        numberFrase = 0;
        fraseEnd = false;
        Text.text = "";
        Name.text = _frases[numberFrase].Name;
    }

    private void FixedUpdate()
    {
        if (numberFrase >= _frases.Count)
        {
            return;
        }
        if (Input.anyKeyDown)
        {
            Input.ResetInputAxes();
            if (!fraseEnd)
            {
                fraseEnd = true;
                Text.text = _frases[numberFrase].Text;
                delay = FraseDelay;
            }
            else
            {
                Text.text = "";
                delay = 0f;
                numberFrase++;
                if (numberFrase >= _frases.Count)
                {
                    return;
                }
                
                Name.text = _frases[numberFrase].Name;
                i = 0;
            }
        }

        if (delay > 0f)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                Text.text = "";
                numberFrase++;
                if (numberFrase >= _frases.Count)
                {
                    return;
                }
                
                Name.text = _frases[numberFrase].Name;
                i = 0;
            }
        }
        else
        {
            if (i < _frases[numberFrase].Text.Length)
            {
                Text.text += _frases[numberFrase].Text[i];
                i++;
            }
            else
            {
                fraseEnd = true;
                delay = FraseDelay;
            }
        }

    }
}
