using UnityEngine;
public class Hero
{
    public bool Defender = false;
    public readonly CharactersSc MyProp;
    readonly string Name;
    Sprite[] sprites { get; }
    readonly Color[] spColors;
    readonly bool[] HaveAbilityes = new bool[8];
    public Hero(string _Name, CharactersSc _MyProp, Sprite[] _sprites, Color[] SpritesColor)
    {
        HaveAbilityes[0] = true;
        HaveAbilityes[1] = true;
        HaveAbilityes[2] = true;
        MyProp = _MyProp;
        Name = _Name;
        sprites = _sprites.Clone() as Sprite[];
        spColors = SpritesColor.Clone() as Color[];
    }


    public string GetName() { return Name; }
    public int GetPower() { return MyProp.Strength; }
    public void Display(UnityEngine.UI.Image[] images)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            images[i].sprite = sprites[i];
            images[i].color = spColors[i];
        }
    }

    public void Heal(float Persent)
    {
        var h = MyProp.MaxHealth * Persent / 100;
        MyProp.Health += (int)h;
        if (MyProp.Health > MyProp.MaxHealth) MyProp.Health = MyProp.MaxHealth;
    }

    public float PersentHealth()
    {
        if (MyProp.Health == 0) return 0;
        return (float)System.Math.Round((float)(MyProp.Health / (float)MyProp.MaxHealth) *100, 2);
    }

    public bool HaveAbility(int i)
    {
        return HaveAbilityes[i];
    }

    public void SetAbiluty(int i, bool Value)
    {
        HaveAbilityes[i] = Value;
    }

    public void Damaging(int Power)
    {
        MyProp.Health -= Defender ? Power : Power;
        if (MyProp.Health < 0) MyProp.Health = 0;
        Defender = false;

    }
}