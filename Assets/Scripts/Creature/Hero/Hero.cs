using Enums;
public class Hero : Creature
{
    public Characteristics HeroCharacteristics { get; private set; }
    public Genger HeroGenger { get; private set; }

    public Appearance HeroAppearance { get; private set; }

    public Hero(string Name, Appearance Self, float ScaleCharacteristicsFactor) : base(Global.Instantiate().Herous.NextValue(), Name)
    {
        HeroAppearance = Self;



        System.Random random = new System.Random();
        HeroCharacteristics = new Characteristics(ScaleCharacteristicsFactor);
        HeroGenger = (Genger)(random.Next(0, 2));
    }
    

}













