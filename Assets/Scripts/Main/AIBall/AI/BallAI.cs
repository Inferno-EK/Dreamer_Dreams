using UnityEngine;

public class BallAI : MonoBehaviour
{
    public BallProperties properties = null;

    public int Id;
    public void Killing()
    {
        Instantiate(transform.parent.GetComponent<ObjectContainer>()._object, gameObject.transform.position, Quaternion.identity);
        AIContainer.Remove(Id);
        Destroy(gameObject);
    }
    public bool isAlife() => properties.Health != 0;
    public void Initialize()
    {
        if (properties == null)
        {
            properties = new BallProperties();
            float colorited = Random.Range(0f, 1f);
            bool color = Random.Range(0, 10) == 0;
            Color ballColor;
            bool currentColor;
            int colStage = 25;
            do
            {
                currentColor = true;
                ballColor = new Color((color ? colorited / 4 : 0f), (!color ? 1 - colorited / 2 : 0f), 1f, 0.5f);
                foreach (var i in AIContainer.objects)
                {
                    if (i.GetComponent<SpriteRenderer>().color == ballColor)
                    {
                        currentColor = false;
                        break;
                    }
                }
                --colStage;
            } while (!currentColor && colStage != 0);
            Gradient trailColor = new Gradient();

            var colorKey = new GradientColorKey[2];
            colorKey[0].color = ballColor;
            colorKey[0].time = 0.0f;
            colorKey[1].color = Color.white;
            colorKey[1].time = 1.0f;

            var alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 0.5f;
            alphaKey[0].time = 0.0f;
            alphaKey[1].alpha = 0.25f;
            alphaKey[1].time = 1.0f;

            trailColor.SetKeys(colorKey, alphaKey);
            gameObject.GetComponent<SpriteRenderer>().color = ballColor;
            gameObject.GetComponent<TrailRenderer>().colorGradient = trailColor;
        }
        /*
        foreach (var item in properties.Genes)
        {
            int next = item.id_next_empty();
            while (next != -1)
            {
                
                next = item.id_next_empty();
                next = -1;
            }

        }*/
        StartCoroutine(e(Random.Range(1f, 5f)));
        AIContainer.Add(gameObject, ref Id);
    }

    public void Initialize(GameObject old)
    {
        properties = old.GetComponent<BallAI>().properties.Split();
        if (Random.value <= 0.1)
        {
            properties = new BallProperties();
            float colorited = Random.Range(0f, 1f);
            bool color = Random.Range(0, 10) == 0;
            Color ballColor = new Color((color ? colorited / 4 : 0f), (!color ? 1 - colorited / 2 : 0f), 1f, 0.5f);
            Gradient trailColor = new Gradient();

            var colorKey = new GradientColorKey[2];
            colorKey[0].color = ballColor;
            colorKey[0].time = 0.0f;
            colorKey[1].color = Color.white;
            colorKey[1].time = 1.0f;

            var alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 0.5f;
            alphaKey[0].time = 0.0f;
            alphaKey[1].alpha = 0.25f;
            alphaKey[1].time = 1.0f;

            trailColor.SetKeys(colorKey, alphaKey);
            gameObject.GetComponent<SpriteRenderer>().color = ballColor;
            gameObject.GetComponent<TrailRenderer>().colorGradient = trailColor;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = old.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<TrailRenderer>().colorGradient = old.GetComponent<TrailRenderer>().colorGradient;
        }
        
    }

    public GameObject Split()
    {
        GameObject n = Instantiate(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation * Quaternion.Euler(0f, 0f, 180f), transform.parent);
        n.name = gameObject.name;
        n.GetComponent<Ball_Moving>().enabled = true;
        n.GetComponent<BallAI>().Initialize(gameObject);
        n.transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
        n.transform.GetChild(1).GetComponent<Collider2D>().enabled = true;
        return n;
    }
    

    public void Damage()
    {
        properties.Health--;
    }
    public void BoundsForfeit()
    {
        properties.Energy -= properties.BoundsForfeit;
    }

    public void RotateForfeit()
    {
        properties.Energy -= properties.RotateForfeit;
    }
    bool stage = true;

    System.Collections.IEnumerator e(float time)
    {
        WaitForSeconds w = new WaitForSeconds(time);
        while (true)
        {
            yield return w;
            stage = !stage;
        }

    }

    public float Calculate()
    {
        if (properties.Energy < 0)
        {
            Killing();
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return 90f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            return -90f;
        }
        return (stage ? 90f : -90f);
    }
}
