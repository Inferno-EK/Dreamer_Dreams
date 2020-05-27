using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomize : MonoBehaviour
{
    [SerializeField] SpriteSellector[] _spriteSellectors;
    [SerializeField] Slider[] _sliders;

    public void Randomizing()
    {
        foreach (var item in _sliders)
        {
            item.value = Random.value;
        }

        foreach (var item in _spriteSellectors)
        {
            item.SetIndex(Random.Range(0, item.GetLength()));
        }
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        Randomizing();
    }

    private void Start()
    {
        StartCoroutine(LateStart());
    }

}
