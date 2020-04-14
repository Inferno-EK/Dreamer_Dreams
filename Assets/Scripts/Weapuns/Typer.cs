using System;
using System.Collections.Generic;

public class Typer<T>
{
	static public List<Type> GetTypeChild(bool Remove = true)
	{
		var LTypes = new List<Type>();
		var AllType = System.Reflection.Assembly.GetExecutingAssembly();
		var interfaseType = typeof(T);


		foreach (var type in AllType.GetTypes())
			if (interfaseType.IsAssignableFrom(type))
				LTypes.Add(type);
		if (Remove)
			LTypes.Remove(interfaseType);
		return LTypes;
	}
}
