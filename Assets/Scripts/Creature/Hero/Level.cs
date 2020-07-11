public class Level
{
    public int NowLevel { get; private set; }
    public float GetPercent()
    {
        return int.Parse((nowExp / expToNewLelel * 1000).ToString()) / 10; // format to **.*%
    }
    public bool MaxLevel { get; private set; }
    public bool CanUpgrate { get; private set; }
    public void AddExp(int value)
    {
        nowExp += value;
        if (nowExp < 0)
        {
            nowExp = 0;
            return;
        }

        if (MaxLevel && nowExp > expToNewLelel)
        {
            nowExp = expToNewLelel;
        }

        if (nowExp >= expToNewLelel)
        {
            CanUpgrate = true;
            
        }
    }
    public void Upgrate()
    {
        
        if (!CanUpgrate)
        {

            NowLevel++;
            if (NowLevel == 100)
                MaxLevel = true;

            nowExp -= expToNewLelel;
            expToNewLelel *= 2;

            CanUpgrate = false;


            if (nowExp >= expToNewLelel)
            {
                CanUpgrate = true;
            }
        }
    }
    public Level() {}

    private int expToNewLelel = 128;
    private int nowExp = 0;



}
