using System;
using System.Collections.Generic;
using System.Reflection;
using Delegates;
public class MeleeWeaponUpdator
{
    private static Type ByName(string name)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            var tt = assembly.GetType(name);
            if (tt != null)
            {
                return tt;
            }
        }

        return null;
    }

    public Weapon Update(Type type)
    {
        int val = UnityEngine.Random.Range(0, constrictors[type].Count);
        return (Weapon)Activator.CreateInstance(constrictors[type][UnityEngine.Random.Range(0, constrictors[type].Count)]);
    }
    
    private Dictionary<Type, List<Type>> constrictors = null;
    private static MeleeWeaponUpdator this_Initialisation = null;
    private MeleeWeaponUpdator()
    {
        FileReader file = new FileReader("\\text\\", "weapon_upgrate.u");
        constrictors = new Dictionary<Type, List<Type>>();

        Type nowType = null;
        foreach (string i in file.Lines)
        {
            if (i.Split(' ').Length > 1)
            {
                nowType = ByName(i.Split(' ')[0]);
                constrictors[nowType] = new List<Type>();
            } 
            else
            {
                if (i != ";")
                {
                    constrictors[nowType].Add(ByName(i));
                }
                else
                {
                    nowType = null;
                }
            }
        }
    }

    static public MeleeWeaponUpdator Initialise()
    {
        if (this_Initialisation == null)
            this_Initialisation = new MeleeWeaponUpdator();
        return this_Initialisation;
    }
}
