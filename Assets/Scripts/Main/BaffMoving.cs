using UnityEngine;

public class BaffMoving : MonoBehaviour
{
    private Vector3 Speed;
    private Renderer r;

    private void Start()
    {
        r = transform.GetComponent<Renderer>();
        try
        {
            BallAI aI = AIContainer.ais[AIContainer.FindNearest(transform.position)];
            Color color = aI.gameObject.transform.GetComponent<SpriteRenderer>().color;
            color.a = 0.5f;
            transform.GetComponent<ParticleSystem>().startColor = color;
            Speed = new Vector3(0, 0, aI.properties.MovingSpeed * 1.1f * 0.02f);
        }
        catch
        {
            Color color = Color.magenta;
            color.a = 0.5f;
            transform.GetComponent<ParticleSystem>().startColor = color;
            Speed = new Vector3(0, 0, 500 * 0.02f);
            transform.rotation *= Quaternion.Euler(Random.Range(0f, 360f), -90f, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int x = AIContainer.FindNearest(transform.position);
        try
        {
            transform.LookAt(AIContainer.objects[x].transform.position);

        }
        catch (System.Exception) 
        {
            if (!r.isVisible)
            {
                Destroy(gameObject);
            }
        }
        finally
        {

            transform.Translate(Speed);
            Speed.z += 0.05f;
        }
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
