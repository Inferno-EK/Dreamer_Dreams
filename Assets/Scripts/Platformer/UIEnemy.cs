using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnemy : MonoBehaviour
{
    Global gl;

    private void Start()
    {
        gl = Global.Instantiate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroMove>() != null)
        {
            gl.mainHero.Damage(50);
        }
    }
}
