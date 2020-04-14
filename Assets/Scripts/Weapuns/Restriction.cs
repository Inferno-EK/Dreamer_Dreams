using UnityEngine;
using System.Collections.Generic;

class Restriction
{
    int Strength = 0,
        Dexterity = 0,
        Intelligence = 0,
        Luck = 0,
        Wisdom = 0,
        Endurance = 0,
        MaxHealth = 0,
        Learning = 0;

    public Restriction(List<string> vs)
    {
        foreach (var item in vs)
        {
            char switcher = item[0];
            int i = 1;
            while(switcher == ' ' || switcher == '\t')
            {
                switcher = item[i];
                i++;
            }
            string toInt = "";
            for (int j = i + 1; j < item.Length; j++)
            {
                switch (item[j])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        toInt += item[j];
                        break;
                }
                
            }
            int value = int.Parse(toInt);
            switch (switcher)
            {
                case 'S':
                    Strength = value;
                    break;
                case 'D':
                    Dexterity = value;
                    break;
                case 'I':
                    Intelligence = value;
                    break;
                case 'L':
                    if (item[i + 1] == 'u')
                        Luck = value;
                    else
                        Learning = value;
                    break;
                case 'W':
                    Wisdom = value;
                    break;
                case 'E':
                    Endurance = value;
                    break;
                case 'M':
                    MaxHealth = value;
                    break;
                default:
                    Debug.LogError("ErRor");
                    break;
            }
        }

    }
}
