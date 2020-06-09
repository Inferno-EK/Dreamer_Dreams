using System;
using System.Collections.Generic;

public class DialogParser
{
    public readonly List<Pair<string, string>> Frases;

    public DialogParser(FileReader InputDialog, Hero[] heroes)
    {
        Frases = new List<Pair<string, string>>();
        Stack<bool> isEnable = new Stack<bool>();

        foreach (var i in InputDialog._buffer)
        {
            switch (i[0])
            {
                case '?':


                    var par = i.Split(' ');
                    bool useFrises = isEnable.Count == 0 || isEnable.Peek();

                    for (int p = 1; p < par.Length; p++)
                    {
                        if (par[p].Length == 0) continue;
                        if (par[p][0] == '-')
                        {
                            if (par[p][1] == 'r')
                            {
                                
                                useFrises = useFrises && (UnityEngine.Random.value <= (float)(Convert.ToInt32(par[++p])) / Convert.ToInt32(par[++p]));
                            }
                            else
                            {
                                var g = heroes[Convert.ToInt32(par[++p])].HeroGenger;
                                var compareString = "f";
                                if (g == Enums.Genger.Male) compareString = "m";
                                useFrises = useFrises && par[++p] == compareString;
                            }
                        }
                        else break;

                    }
                    isEnable.Push(useFrises);
                    break;
                case '!':
                    isEnable.Push(!isEnable.Pop() && (isEnable.Count == 0 || isEnable.Peek()));
                    break;
                case '.':
                    isEnable.Pop();
                    break;
                case 'f':
                    if (!(isEnable.Count == 0 || isEnable.Peek())) break;
                    char[] sep = { ' ' };
                    int j = 0;
                    for (int c = 0; j < i.Length && c < 2; j++) { if (i[j] == ' ') c++; }
                    var parF = i.Split(sep, 3);
                    Frases.Add(new Pair<string, string>(heroes[Convert.ToInt32(parF[1].Substring(1))].Name, parF[2]));
                    break;
            }


        }

    }
}
