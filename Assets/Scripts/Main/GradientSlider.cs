using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Delegates;

public class GradientSlider : MonoBehaviour
{
    [SerializeField] private Color StartColor = Color.black;
    [SerializeField] private Color MiddleColor = Color.black;
    [SerializeField] private Color EndColor = Color.black;


   
    public event OnChangeColor onChangeColorEvent;

    private Gradient _baseGradient;

    void Start()
    {
        var baseSlider = GetComponent<UnityEngine.UI.Slider>();
        var fieldImage = transform.GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Image>();

        onChangeColorEvent += (Color color) => { baseSlider.image.color = color; };
        onChangeColorEvent += (Color color) => { fieldImage.color = color; };

        _baseGradient = new Gradient();
        var gradientKeys = new GradientColorKey[3];
        gradientKeys[0] = new GradientColorKey(StartColor, 0f);
        gradientKeys[1] = new GradientColorKey(MiddleColor, 0.5f);
        gradientKeys[2] = new GradientColorKey(EndColor, 1f);

        var gradientAlpha = new GradientAlphaKey[1];
        gradientAlpha[0] = new GradientAlphaKey(1f, 0f);

        _baseGradient.SetKeys(gradientKeys, gradientAlpha);
        baseSlider.onValueChanged.AddListener((float value) => { onChangeColorEvent.Invoke(_baseGradient.Evaluate(value)); });

        var startValue = Random.value;
        onChangeColorEvent.Invoke(_baseGradient.Evaluate(startValue));
        baseSlider.value = startValue;
    }
}
