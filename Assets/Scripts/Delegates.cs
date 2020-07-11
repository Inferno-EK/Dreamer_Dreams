namespace Delegates
{
    public delegate void OnChangeColor(UnityEngine.Color color);
    public delegate void OnValueChange(UnityEngine.Sprite toChange, int number);
    public delegate Weapon WeaponConstructor();
    namespace Settings
    {
        public delegate void OnScreenSizeChange(UnityEngine.Vector2 sizes);
    }
}
