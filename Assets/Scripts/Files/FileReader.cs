using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;

public class FileReader
{ 
    readonly public List<string> _buffer;

    public FileReader(string pathFromHomeDerictory, string fileName)
    {
        _buffer = new List<string>();
        var lines = File.ReadAllLines(Directory.GetCurrentDirectory() + pathFromHomeDerictory + fileName);
        foreach (var item in lines)
        {
            _buffer.Add(item);
        }
    }
}


