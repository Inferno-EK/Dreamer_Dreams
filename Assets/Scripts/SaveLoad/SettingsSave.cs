using System.IO;

namespace Save
{
    static public class SettingsSave
    {
        public static void SaveProgressTo(string Pash)
        {
            File.WriteAllLines(Pash, Settings.Saving());
        }

    }
}
