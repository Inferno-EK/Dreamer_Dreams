using UnityEngine;
using UnityEngine.UI;
using Delegates;

public class SpriteSellector : MonoBehaviour
{
    [SerializeField] private Sprite[] AllSprite;


    [Header("Control Buttons")]
    [SerializeField] private Image ToSprite;
    [SerializeField] private Button LeftArrow;
    [SerializeField] private Button RightArrow;
    [SerializeField] private int StartIndex = 0;


    
    public event OnValueChange onValueChange;

    public void SetIndex(int value)
    {
        if (value >= AllSprite.Length || value < 0) { throw new System.Exception("Index out of range"); }
        _index = value;
        onValueChange.Invoke(AllSprite[_index], _index);
    }

    public int GetLength()
    {
        return AllSprite.Length;
    }

    private int _index;

    enum ArrowDerection
    {
        Left,
        Right
    }


    private void Start()
    {

        if (AllSprite == null) { throw new System.Exception("List of sprites is empty. Please, check values"); }
        if (StartIndex >= AllSprite.Length || StartIndex < 0) { throw new System.Exception("Index out of range"); }
        _index = StartIndex;
        ToSprite.sprite = AllSprite[_index];
        ToSprite.preserveAspect = true;

        onValueChange += (Sprite sprite, int i) => { ToSprite.sprite = sprite; };

        LeftArrow.onClick.AddListener(() => OnArrowClick(ArrowDerection.Left));
        RightArrow.onClick.AddListener(() => OnArrowClick(ArrowDerection.Right));

        onValueChange.Invoke(AllSprite[_index], _index);
    }

    private void OnDestroy()
    {
        onValueChange -= (Sprite sprite, int i) => { ToSprite.sprite = sprite; };
    }

    private void OnArrowClick(ArrowDerection derection)
    {
        if (derection == ArrowDerection.Right)
        {
            _index = (_index == 0 ? AllSprite.Length : _index) - 1;
        }
        else
        {
            _index = _index == AllSprite.Length - 1 ? 0 : _index + 1;
        }


        onValueChange.Invoke(AllSprite[_index], _index);
    }


}
