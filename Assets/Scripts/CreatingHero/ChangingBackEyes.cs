using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingBackEyes : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private UnityEngine.UI.Image _thisImage;
    [SerializeField] private SpriteRenderer[] _toSprites;

    [SerializeField] private SpriteSellector _sellector;

    private void Awake()
    {
        _sellector.onValueChange += ChangeBack;
    }

    private void ChangeBack(Sprite toChange, int number)
    {
        _thisImage.sprite = _sprites[number % _sprites.Length];
        foreach (var item in _toSprites)
        {
            item.sprite = _sprites[number % _sprites.Length]; 
        }
    }
}
