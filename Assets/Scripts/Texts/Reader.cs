using System.Collections.Generic;
using UnityEngine;

public class Reader
{
    List<string> val = new List<string>();
    System.IO.StreamWriter writer;

    public Reader(string Name, bool WriteAble = false, bool FlushAble = true)
    {
        string startupPath = System.IO.Directory.GetCurrentDirectory();

        System.IO.StreamReader file = new System.IO.StreamReader(startupPath + @"\Texts\" + Name);

        string s = file.ReadLine();
        while (!file.EndOfStream)
        {
            val.Add(s);
            s = file.ReadLine();
        }
        val.Add(s);
        file.Close();

        if (WriteAble)
            writer = new System.IO.StreamWriter(startupPath + @"\Texts\" + Name, !FlushAble);
        else
            writer = null;
    }

    public List<string> GetAllVal()
    {
        return val;
    }

    public string GetVal(int i)
    {
        if (i < val.Count)
            return val[i];
        return "";
    }

    public string GetRandomVal()
    {
        return val[Random.Range(0, val.Count)];
    }

    public void ReWrite(List<string> texts)
    {
        if (writer != null)
        {
            using (writer)
            { 
                int Max = texts.Count;
                for (int i = 0; i < Max; i++)
                {
                    writer.WriteLine(texts[i]);
                }
            }
        }
    }
}
