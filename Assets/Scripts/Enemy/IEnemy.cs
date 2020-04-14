public interface IEnemy
{
    UnityEngine.Sprite GetSprite();
    void SetHealth(int HowMuch);
    void SetPower(int HowMuch);
    float PersentHealth();
    int GetHealth();
    string Name(); 
    int GetId();
    void Damaging(int Power);
    int GetPower();
    bool Life();
    bool HaveSpecialAbility();
}
























































