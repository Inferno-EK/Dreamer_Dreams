using Enums;
public class Hero : Creature
{
    public Characteristics HeroCharacteristics { get; private set; }
    public Gender HeroGenger { get; private set; }

    public Hero(string Name, float ScaleCharacteristicsFactor) : base(Global.Instantiate().Herous.NextValue(), Name)
    {
        System.Random random = new System.Random();
        HeroCharacteristics = new Characteristics(ScaleCharacteristicsFactor);
        HeroGenger = (Gender)(random.Next(0, 2));
    }
    

}