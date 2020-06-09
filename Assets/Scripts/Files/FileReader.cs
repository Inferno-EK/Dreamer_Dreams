using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;

public class FileReader
{ 
    readonly public List<string> Lines;

    public FileReader(string pathFromHomeDerictory, string fileName)
    {
        Lines = new List<string>();
        var lines = File.ReadAllLines(Directory.GetCurrentDirectory() + pathFromHomeDerictory + fileName);
        foreach (var item in lines)
        {
            Lines.Add(item);
        }
    }


}


