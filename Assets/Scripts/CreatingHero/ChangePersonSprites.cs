using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Enums;

public class ChangePersonSprites : MonoBehaviour
{
    public Color NextColor;
    public List<Color> ExtraColor;

    public bool Enable;
    public Derection CurrentDerection { get; private set; }

    [SerializeField] ColorSlidersComplex _toHeirComplex;
    [SerializeField] ColorSlidersComplex _toEyeComplex;
    [SerializeField] SpriteSellector _heirSellector;
    [SerializeField] SpriteSellector _eyeSellector;
    [SerializeField] SpriteSellector _mouseSellector;
    [SerializeField] private GameObject GameObjectSliderToChangeSkin;
    private Transform _base;
    private Color _nowColor;
    private List<SpriteRenderer> _sprites;
    private List<SpriteRenderer> _extraSprites;

    private float _delta;

    private int __eyeFrontId;
    private int __mouseId;
    private int __heirId;
    public void SetHeirColor(Color color)
    {
        ExtraColor[__heirId] = color;
        SetExtraColor();
    }

    private int __eyeBackId;
    public void SetEyeColor(Color color)
    {
        ExtraColor[__eyeBackId] = color;
        SetExtraColor();
    }

    public void SetColor(Color value)
    {
        if (value == _nowColor)
            return;

        foreach (var item in _sprites)
        {
            item.color = value;
        }

        _nowColor = value;
    }

    public void SetExtraColor()
    {
        for (int i = 0; i < _extraSprites.Count; i++)
        {
            _extraSprites[i].color = Color.Lerp(ExtraColor[i], Color.clear, _delta);
        }
    }

    public void SetDerection(Derection newDerection)
    {
        if (newDerection != CurrentDerection)
            Reverse();
    }


    private void Reverse()
    {
        var nowDerection = -1 * _base.localScale.x;

        _base.localScale = new Vector3(nowDerection, _base.localScale.y, _base.localScale.z);
        CurrentDerection = (Derection)((int)CurrentDerection*-1);
    }

    private void Awake()
    {
        GameObjectSliderToChangeSkin.GetComponent<GradientSlider>().onChangeColorEvent += (Color color) => { NextColor = color; };


        _base = transform;
        _sprites = new List<SpriteRenderer>();
        _extraSprites = new List<SpriteRenderer>();

        for (int i = 0; i < transform.childCount; ++i)
        {
            var child = transform.GetChild(i);

            if (child.GetComponent<SpriteRenderer>() != null)
            {
                if (child.GetComponent<Rigidbody2D>() != null)
                {
                    _sprites.Add(child.GetComponent<SpriteRenderer>());
                }
                else
                {
                    ExtraColor.Add(Color.white);
                    _extraSprites.Add(child.GetComponent<SpriteRenderer>());
                }
            }

            for (int j = 0; j < child.childCount; ++j)
            {
                var сhallenger = child.GetChild(j);
                
                if (сhallenger.GetComponent<SpriteRenderer>() != null)
                {
                    if (сhallenger.GetComponent<Rigidbody2D>() != null)
                    {
                        _sprites.Add(сhallenger.GetComponent<SpriteRenderer>());
                    }
                    else
                    {
                        switch (сhallenger.name)
                        {
                            case "heir":
                                __heirId = ExtraColor.Count;
                                _toHeirComplex.onChangeColorEvent += SetHeirColor;
                                _heirSellector.onValueChange += (Sprite toChange, int number) => { _extraSprites[__heirId].sprite = toChange; };
                                break;
                            case "eyeBack":
                                __eyeBackId = ExtraColor.Count;
                                _toEyeComplex.onChangeColorEvent += SetEyeColor;
                                break;
                            case "eyeFront":
                                __eyeFrontId = ExtraColor.Count;
                                _eyeSellector.onValueChange += (Sprite toChange, int number) => { _extraSprites[__eyeFrontId].sprite = toChange; };
                                break;
                            case "mouse":
                                __mouseId = ExtraColor.Count;
                                _mouseSellector.onValueChange += (Sprite toChange, int number) => { _extraSprites[__mouseId].sprite = toChange; };
                                break;
                        }

                        ExtraColor.Add(Color.white);
                        _extraSprites.Add(сhallenger.GetComponent<SpriteRenderer>());
                    }
                }
            }
        }

        _delta = 1f;
        _nowColor = Color.white;
        SetColor(Color.clear);
        SetExtraColor();

        CurrentDerection = Derection.Left;
    }

    private void OnDestroy()
    {
        GameObjectSliderToChangeSkin.GetComponent<GradientSlider>().onChangeColorEvent -= (Color color) => { NextColor = color; };
    }



    private void FixedUpdate()
    {
        if (Enable)
        {
            _delta -= Time.fixedDeltaTime;
            if (_delta >= 0f)
            {
                SetColor(Color.Lerp(NextColor, Color.clear, _delta));
                SetExtraColor();
            }
            else
            {
                SetColor(NextColor);
                _delta = 0f;
            }
            
        }
        else
        {
            _delta += Time.fixedDeltaTime;
            if (_delta <= 1f)
            {
                SetColor(Color.Lerp(NextColor, Color.clear, _delta));
                SetExtraColor();
            }
            else
            {
                SetColor(Color.clear);
                _delta = 1f;
            }
            
        }
    }
}
