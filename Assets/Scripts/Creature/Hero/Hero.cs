using Enums;
public class Hero : Creature
{
    
    public Genger HeroGenger { get; private set; }
    public Appearance HeroAppearance { get; private set; }
    public Level HeroLevel;
    public Hero(string Name, Appearance Self, float ScaleCharacteristicsFactor) : base(Global.Instantiate().Herous.NextValue(), Name, ScaleCharacteristicsFactor)
    {
        HeroAppearance = Self;
        System.Random random = new System.Random();
        Characteristics.Randomising(ScaleCharacteristicsFactor);
        HeroGenger = (Genger)(random.Next(0, 2));
    }
    
    public void Heal(float Percent = 1)
    {
        Characteristics.ThisHealth.Heal(Percent);
    }
}













