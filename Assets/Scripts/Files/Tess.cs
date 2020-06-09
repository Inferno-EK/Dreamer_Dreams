using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class Tess : MonoBehaviour
{
    [SerializeField] private Writer[] writers;

    void f(FileReader a, DialogParser d)
    {
        StartCoroutine(new DialogViewer().ctor(writers, a, d));
    }
    void Start()
    {
        var a = new FileReader("\\t\\", "t.txt");
        Hero[] h = { new Hero("asd", new Appearance(Color.white, Color.white, Color.white), 1f) };
        var d = new DialogParser(a, h);
        a = new FileReader("\\t\\", "c.txt");
         f(a, d);
    }
}
