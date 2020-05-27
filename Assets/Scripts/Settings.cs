using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates.Settings;

public class Settings
{
	public event OnScreenSizeChange onScreenSizeChange;




	private static Settings inisialisadedObject;


	private Settings(IEnumerable<string> loadedOptions)
	{
		if (loadedOptions is null)
		{
			throw new ArgumentNullException(nameof(loadedOptions));
		}
	}

	private Settings()
	{

	}

	public static Settings Instantiate(IEnumerable<string> loadedOptions)
	{
		if (inisialisadedObject == null)
		{
			inisialisadedObject = new Settings(loadedOptions);
		}
		return inisialisadedObject;
	}

	public static Settings Instantiate()
	{
		if (inisialisadedObject == null)
		{
			inisialisadedObject = new Settings();
		}
		return inisialisadedObject;
	}

	public static List<string> Saving()
	{
		var result = new List<string>();



		return result;
	}
}

