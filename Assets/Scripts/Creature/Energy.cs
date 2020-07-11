public class Energy
{
    public int MaxEnergy { get; private set; }
    public int NowEnergy { get; private set; }
    public void Heal(float Percent)
    {
        NowEnergy += (int)(MaxEnergy * Percent);
        if (NowEnergy < 0) NowEnergy = 0;
        if (NowEnergy > MaxEnergy) NowEnergy = MaxEnergy;
    }

    public Energy(int maxEnergy)
    {
        MaxEnergy = maxEnergy;
        NowEnergy = MaxEnergy;
    }
}
