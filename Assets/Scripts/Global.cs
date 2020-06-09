using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global
{
	public SmartList<Hero> Herous;
	public SmartList<Enemy> Enemies;
	public Settings AllSettings;
	//public ProjectResources GlobalResurses;
	

	private static Global inisialisadedObject;
	private Global()
	{
		Herous = new SmartList<Hero>();
		Enemies = new SmartList<Enemy>();
		AllSettings =  Settings.Instantiate();
	}
	public static Global Instantiate()
	{
		if (inisialisadedObject == null)
		{
			inisialisadedObject = new Global();
		}
		return inisialisadedObject;
	}
}
