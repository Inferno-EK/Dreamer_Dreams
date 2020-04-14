using System;
using System.Collections.Generic;
public class WeapunsConstructor
{
	List<Pair<Type, List<Type>>> pairs;
	public WeapunsConstructor()
	{

		Reader reader = new Reader("Weapun\\GraphOfClasses.txt");
		List<Type> types = Typer<BaseWeapuns>.GetTypeChild(false);

		pairs = new List<Pair<Type, List<Type>>>();
		var fg = reader.GetAllVal();
		foreach (string str in fg)
		{
			List<int> idType = new List<int>();
			string baseTypeName = "";
			int i = 0;
			while (str[i] != ':')
			{
				baseTypeName = "";
				idType.Add(0);
				for (; str[i] != ' ' && str[i] != ','; i++)
				{
					baseTypeName += str[i];
				}
				i++;
				for (; idType[idType.Count - 1] < pairs.Count; idType[idType.Count - 1]++)
				{
					if (pairs[idType[idType.Count - 1]].First.Name == baseTypeName)
						goto inTypeList;
				}
				{ // if type is missing we add new list for this type  
					Type adding = typeof(Object);
					for (int j = 0; j < types.Count; j++)
						if (types[j].Name == baseTypeName)
						{
							adding = types[j];
							break;
						}
					pairs.Add(new Pair<Type, List<Type>>(adding, new List<Type>()));
				}
			inTypeList:;
				if (str[i] == ':') break;
				else i++;
			}
			i += 2;
			while (str[i] != '\0')
			{
				baseTypeName = "";
				for (; i < str.Length && str[i] != ' ' && str[i] != ',' && str[i] != '\n'; i++)
				{
					baseTypeName += str[i];
				}
				i++;
				Type adding = typeof(Object);
				for (int j = 0; j < types.Count; j++)
					if (types[j].Name == baseTypeName)
					{
						adding = types[j];
						break;
					}
				foreach (var a in idType)
				{
					pairs[a].Second.Add(adding);
				}
				if (!(i < str.Length)) break;
				else i++;
			}
		}
	}

	public T Upgrate<T>(T upretableBase) where T : BaseWeapuns
	{
		if (upretableBase.weapunClasses.Contains((int)Enums.WeapunClasses.Melee))
		{
			foreach (var a in pairs)
				if (a.First == upretableBase.GetType())
					return (T) System.Activator.CreateInstance(a.Second[new Random().Next(0, a.Second.Count)]);
			
		}
		return upretableBase;
	}


}

