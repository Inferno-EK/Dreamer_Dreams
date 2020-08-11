using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeroPacker : MonoBehaviour
{
    [SerializeField] InputField _nameField;

    [SerializeField] SpriteSellector _heir;
    [SerializeField] SpriteSellector _eye;
    [SerializeField] SpriteSellector _mouse;
    
    [SerializeField] SpriteSellector _armor;
    [SerializeField] SpriteSellector _weapon;

    [SerializeField] GradientSlider _bodyColor;
    [SerializeField] Slider _bodySlider;


    [SerializeField] Slider _heirColor_R;
    [SerializeField] Slider _heirColor_G;
    [SerializeField] Slider _heirColor_B;

    [SerializeField] Slider _eyeColor_R;
    [SerializeField] Slider _eyeColor_G;
    [SerializeField] Slider _eyeColor_B;

    private int newHeroId = -1;

    public void HeroMake()
    {
        Global gl = Global.Instantiate();

        if (newHeroId != -1)
        {
            gl.Herous.Delete(newHeroId);
        }        


        newHeroId = gl.Herous.Add(
            new Hero(
                _nameField.name, 
                new Appearance(
                    _bodyColor.GetColor(_bodySlider.value), 
                    makeColor(_heirColor_R, _heirColor_G, _heirColor_B), 
                    makeColor(_eyeColor_R, _eyeColor_G, _eyeColor_B)
                ), 
                1f
            )
        );

        Debug.Log(newHeroId);
    }


    private Color makeColor (Slider To_R, Slider To_G, Slider To_B)
    {
        return new Color(To_R.value, To_G.value, To_B.value);
    }

}
