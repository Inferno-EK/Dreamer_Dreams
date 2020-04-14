using UnityEngine;

public class BaffMoving : MonoBehaviour
{
    private Vector3 Speed;


    private void Start()
    {
        BallAI aI = AIContainer.ais[AIContainer.FindNearest(transform.position)];
        Color color = aI.gameObject.transform.GetComponent<SpriteRenderer>().color;
        color.a = 0.5f;
        transform.GetComponent<ParticleSystem>().startColor = color;
        Speed = new Vector3(0, 0, aI.properties.MovingSpeed * 0.02f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            int x = AIContainer.FindNearest(transform.position);
            transform.LookAt(AIContainer.objects[x].transform.position);
            transform.Translate(Speed);
            Speed.z += 0.005f;
    }
    bool inEnter = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!inEnter)
        {
            inEnter = true;
            collision.transform.parent.gameObject.GetComponent<BallAI>().Split();
            Destroy(gameObject);
        }
    }
}
