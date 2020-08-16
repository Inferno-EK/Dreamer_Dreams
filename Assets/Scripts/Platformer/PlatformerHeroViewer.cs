using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformerHeroViewer : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private SpriteRenderer _body;

    private Global gl;

    private void Awake()
    {
        gl = Global.Instantiate();
        if (gl.mainHero == null)
        {
#if MYDEBUG
            gl.mainHero = new Hero("Тут будет имя", new Appearance(Color.white, Color.white, Color.white), 1);
#else
            Debug.LogError("Main hero not initialised");
#endif
        }
        _body.color = gl.mainHero.HeroAppearance.BodyColor;
        _name.text = gl.mainHero.Name;
    }
}
