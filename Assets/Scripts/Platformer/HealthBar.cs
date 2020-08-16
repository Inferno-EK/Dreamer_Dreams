using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image Bar = null;
    [SerializeField] private Text Percent = null;

    private void Start()
    {
        Global gl = Global.Instantiate();
        if (gl.mainHero != null) gl.mainHero.onChangeHealth += Change;
        else Debug.LogError("Not init main hero");
    }

    public void Change(float value)
    {
        Bar.fillAmount = value;
        Percent.text = ((int)(System.Math.Round(value * 100))).ToString() + "%";
    }
}
