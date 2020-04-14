using UnityEngine;

public class Cloud : MonoBehaviour
{
    public bool aLife = true;

    static Sprite[] sprites = null;
    bool moving;
    float speed;
    Vector3 vector;
    // Use this for initialization
    void Start()
    {
        if (sprites == null)
            sprites = Resources.LoadAll<Sprite>("Image/Fight/Clouds") as Sprite[];
        

        gameObject.GetComponent<UnityEngine.UI.Image>().sprite =  sprites[Random.Range(0, sprites.Length)];
        moving = MoveCloud.MoveLeft;
        speed = Random.Range(0.5f, 2f);
        float scaler = Random.Range(0.5f, 5f);
        gameObject.transform.localScale = new Vector3(2 * scaler,
                                                      1 * scaler,
                                                      gameObject.transform.localScale.z);

        vector = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        vector.x += speed * (moving ? -1 : 1);
        gameObject.transform.position = vector;

        if (System.Math.Abs(vector.x) > Screen.width/2 + gameObject.transform.localScale.x * 200 + 15) aLife = false;

    }
}
