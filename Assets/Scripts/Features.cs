using UnityEngine;
using UnityEngine.UI;


public class Features : IFeatures
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
    private int NowStage = 0;
    public bool ActiveAnimate = false;
    public Features (GameObject _stat, GameObject heroImg)
    {
        BackGround = _stat.transform.GetChild(2).GetComponent<Image>();
        Name = _stat.transform.GetChild(0).GetComponent<Text>();
        tHealth = _stat.transform.GetChild(1).GetChild(2).GetComponent<Text>();
        iHealth = _stat.transform.GetChild(1).GetChild(1).GetComponent<Image>();
        img = heroImg;
    }

    void SetName(string New_Name)
    {
        Name.text = New_Name;
    }
        
    public void Refresh(Hero New_Nero)
    {
        SetName(New_Nero.GetName());
        Image[] images = new Image[4];

        images[0] = img.transform.Find("Heir").GetComponent<Image>();
        images[1] = img.transform.Find("Eye").GetComponent<Image>();
        images[2] = img.transform.Find("Mouse").GetComponent<Image>();
        images[3] = img.transform.Find("ColEye").GetComponent<Image>();

        New_Nero.Display(images);
        img.SetActive(New_Nero.PersentHealth() != 0);
        tHealth.text = $"{New_Nero.PersentHealth()}%";
        iHealth.fillAmount = New_Nero.PersentHealth() / 100;
        if (iHealth.fillAmount != 0)    
            BackGround.color = new Color(0f, 0f, 0f, 0f);
        else
            BackGround.color = new Color(1f, 0f, 0f, 0.25f);
        NowStage = 0;
    }

    public Transform[] outObjects()
    {
        return new Transform[]
        {
            img.transform.Find("Heir"),
            img.transform.Find("Eye"),
            img.transform.Find("Mouse"),
            img.transform.Find("ColEye"),
            img.transform.Find("Image")
        };
    }

    public void NextStage()
    {
        if (iHealth.fillAmount != 0)
            switch (NowStage)
            {
                case 0: { BackGround.color = new Color(0f, 1f, 1f, 0.25f); NowStage++; break; }
                case 1: { BackGround.color = new Color(1f, 0.5f, 0f, 0.25f); break; }
            }
        else
            BackGround.color = new Color(1f, 0f, 0f, 0.25f);

    } 
}
