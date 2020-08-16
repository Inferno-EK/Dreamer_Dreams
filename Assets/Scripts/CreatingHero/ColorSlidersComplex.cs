using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Delegates;

public class ColorSlidersComplex : MonoBehaviour
{
    public Color SummaryColor;

    [SerializeField] private GradientSlider RedSlider;
    [SerializeField] private GradientSlider GreenSlider;
    [SerializeField] private GradientSlider BlueSlider;

    public event OnChangeColor onChangeColorEvent;

    private void Awake()
    {
        SummaryColor.a = 1f;
        onChangeColorEvent += (Color c) => {  };
        RedSlider.onChangeColorEvent += (Color color) => { SummaryColor.r = color.r; onChangeColorEvent.Invoke(SummaryColor); };
        BlueSlider.onChangeColorEvent += (Color color) => { SummaryColor.b = color.b; onChangeColorEvent.Invoke(SummaryColor); };
        GreenSlider.onChangeColorEvent += (Color color) => { SummaryColor.g = color.g; onChangeColorEvent.Invoke(SummaryColor); };
    }
}
