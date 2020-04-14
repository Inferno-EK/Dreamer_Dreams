using UnityEngine;

public class Win_or_lose : MonoBehaviour
{
    bool Win = false;
    UnityEngine.UI.Text mText, sText, Log;


    void Awake()
    {
        sText = gameObject.transform.GetChild(1).GetChild(1).GetComponent<UnityEngine.UI.Text>();
        Log = gameObject.transform.GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        mText = gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        for (int i = 0; i < GlobalVaribles.Heros.Count; i++)
        {
            Win = Win || (GlobalVaribles.Heros[i].PersentHealth() != 0);
            if (Win) break;
        }
        mText.color = Win ? new Color(0, 1, 0, 1) : new Color(1, 0, 0, 1);
        mText.text = Win ? "   Вы выиграли!!!   " : "   Вы проиграли!!!   ";
        gameObject.transform.GetChild(2).GetComponent<UnityEngine.UI.Image>().color = mText.color;
    }

    void Start()
    {
        if (Win)
        {
            sText.color = new Color(0, 1, 0, 1);
            Log.color = new Color(0, 1, 0, 1);
            sText.text = "И";
            Log.text = "Никто не умер";
            for (int i = 0; i < GlobalVaribles.Heros.Count; )
            {
                if (GlobalVaribles.Heros[i].PersentHealth() == 0)
                {
                    if (sText.text[0] == 'И')
                    {
                        sText.color = new Color(1, 0, 0, 1);
                        Log.color = new Color(1, 0, 0, 1);
                        sText.text = "НО";
                        Log.text = "";
                    }
                    else
                    {
                        Log.text += "Умер " + GlobalVaribles.Heros[i].GetName() + "\n";
                        GlobalVaribles.Heros.RemoveAt(i);
                    }
                }
                else i++;
            }
            GlobalVaribles.ColsStep++;
        }
        else
        {
            sText.text = "";
            Log.text = $"Всего ходов: {GlobalVaribles.ColsStep}\nВсего убито врагов: {GlobalVaribles.Kills}\n";
        }
    }

    void Update()
    {
        if (Input.anyKey)
        {
            if (Win)
                UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Selector");
            else
            {
                GlobalVaribles.Heros.Clear();
                GlobalVaribles.Kills = 0;
                GlobalVaribles.ColsStep = 1;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Main");
            
            }
        }
    }
}
