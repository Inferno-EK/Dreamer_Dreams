using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testes : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Text text1;
 //   [SerializeField] private UnityEngine.UI.Text text2;

    void Start()
    {
        var q = MeleeWeaponUpdator.Initialise();
        var a = new Melee();
        Debug.Log(q.Update(a.GetType()).GetType().Name);

        var b = new Class1();
        Debug.Log(q.Update(b.GetType()).GetType().Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
