using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tess : MonoBehaviour
{
    void Start()
    {
        Debug.Log(System.IO.Directory.GetCurrentDirectory());
        var a = new FileReader("\\t\\", "t.txt");
        Hero[] h = { new Hero("asd", new Appearance(Color.white, Color.white, Color.white), 1f) };
        var d = new DialogParser(a, h);

        foreach (var i in d.Frases)
        {
            Debug.Log(i.First + ": " + i.Second);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
