using System.Collections.Generic;
using System.IO;

class ReaderWeapon
{
    static bool CreateString(ref string old, bool adding, string source)
    {
        int j = 0;
        if (adding)
        {
            while (source[j] == '\t' || source[j] == ' ') j++;
            while (j < source.Length && source[j] != '\"') old += source[j++];
            if (j < source.Length && source[j] == '\"')
                return true;
            else
                old += ' ';
        }
        else
        {
            j++;
            old = "";
            while (source[j++] != '\"') ;
            while (j < source.Length && source[j] != '\"') old += source[j++];
            if (j < source.Length && source[j] == '\"')
                return true;
            else
                old += ' ';
        }
        return false;
    }
    
    static public CreatorClasses[] ReadWeapons(string folderName)
    {
        List<CreatorClasses> result = new List<CreatorClasses>();
        foreach (string file in Directory.EnumerateFiles(System.IO.Directory.GetCurrentDirectory() + @"\Texts\" + folderName, "*.txt"))
        {
            Reader reader = new Reader(file);
            List<string> vs = reader.GetAllVal();
            List<string> forRestriction = new List<string>();
            string Name = "";
            string Description = "";
            string ClassW = "";
            string waySprite = "";

            char inside = '-';
            foreach (var i in vs)
            {
                if (i == "")
                    continue;
                if (inside != '-')
                {
                    switch (inside)
                    {
                        case 'N':
                            inside = CreateString(ref Name, true, i) ? '-' : inside;
                            break;
                        case 'D':
                            inside = CreateString(ref Description, true, i) ? '-' : inside;
                            break;
                        case 'R':
                            if (i != "]")
                                forRestriction.Add(i);
                            else
                                inside = '-';
                            break;
                        case 'C':
                            inside = CreateString(ref ClassW, true, i) ? '-' : inside;
                            break;
                        case 'S':
                            inside = CreateString(ref waySprite, true, i) ? '-' : inside;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (i[0])
                    {
                        case 'N':
                            inside = 'N';
                            inside = CreateString(ref Name, false, i) ? '-' : inside;
                            break;
                        case 'D':
                            inside = 'D';
                            inside = CreateString(ref Description, false, i) ? '-' : inside;
                            break;
                        case 'R':
                            inside = 'R';
                            break;
                        case 'C':
                            inside = 'C';
                            inside = CreateString(ref ClassW, false, i) ? '-' : inside;
                            break;
                        case 'S':
                            inside = 'S';
                            inside = CreateString(ref waySprite, false, i) ? '-' : inside;
                            break;
                    }
                }
            }
            result.Add(new CreatorClasses(Name, Description, ClassW, new Restriction(forRestriction), waySprite));

        }
        return result.ToArray();
    }
}