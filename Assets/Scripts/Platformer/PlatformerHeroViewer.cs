using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformerHeroViewer : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private SpriteRenderer _body;
    [SerializeField] private int _mainHeroId;
    [SerializeField] private int _secondHeroId;

    private Global gl;
    private bool _isMainHero;
    private bool _haveTab;
    private void Start()
    {
        gl = Global.Instantiate();
        if (!gl.Herous.IsValidIndex(_mainHeroId)) Debug.LogError("Main hero not initialised");
        _body.color = gl.Herous[_mainHeroId].HeroAppearance.BodyColor;
        _haveTab = _secondHeroId != -1 && gl.Herous.IsValidIndex(_secondHeroId);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_haveTab && Input.GetKeyDown(KeyCode.Tab))
        {
            _isMainHero = !_isMainHero;
            _body.color = gl.Herous[_isMainHero ? _mainHeroId : _secondHeroId].HeroAppearance.BodyColor;
        }
    }
}
