using UnityEngine.UI;
using UnityEngine;

public class EnFeatures : IFeatures
{
    public bool GetActiveAnimate()
    {
        return ActiveAnimate;
    }

    public void InvertActiveAnimate()
    {
        ActiveAnimate = !ActiveAnimate;
    }
    readonly GameObject img;
    private readonly Text tHealth;
    private readonly Text Name;
    private readonly Image iHealth;
    private readonly Image BackGround;
    bool ActiveAnimate = false;
    public EnFeatures(GameObject _stat, GameObject enImg)
    {
        BackGround = _stat.transform.GetChild(2).GetComponent<Image>();
        Name = _stat.transform.GetChild(0).GetComponent<Text>();
        tHealth = _stat.transform.GetChild(1).GetChild(2).GetComponent<Text>();
        iHealth = _stat.transform.GetChild(1).GetChild(1).GetComponent<Image>();
        img = enImg;
    }

    void SetName(string New_Name)
    {
        Name.text = New_Name;
    }

    public Transform outObjects()
    {
        return img.transform.GetComponent<Transform>();
    }

    public void Refresh(IEnemy New_Enemy)
    {
        SetName(New_Enemy.Name());
        img.GetComponent<Image>().sprite = New_Enemy.GetSprite();
        if (New_Enemy.PersentHealth() == 0)
        {
            img.GetComponent<Image>().color = new Color(1f, 1f, 1f);
            img.SetActive(false);
        }
        else
            img.SetActive(true);    
        tHealth.text = $"{New_Enemy.PersentHealth()}%";
        iHealth.fillAmount = New_Enemy.PersentHealth() / 100;
        if (iHealth.fillAmount != 0)
            BackGround.color = new Color(0f, 0f, 0f, 0f);
        else
            BackGround.color = new Color(1f, 0f, 0f, 0.25f);
        
    }

}
