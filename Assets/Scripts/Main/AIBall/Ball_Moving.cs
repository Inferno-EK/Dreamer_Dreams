using UnityEngine;

public class Ball_Moving : MonoBehaviour
{
	public Transform projector = null;
	public int MovingSpeed = 0;
	public float Angles = 0f;
	private Quaternion step;
	private float x = 0f, maxX = 0f;
	BallAI aI;
	bool outOfBound = false;
	void Start()
	{
		aI = gameObject.GetComponent<BallAI>();
		aI.Initialize();
		MovingSpeed = aI.properties.MovingSpeed;
		Angles = aI.properties.RotationSpeed * 0.02f;
		transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		step = Quaternion.Euler(0f, 0f, 0f);
		transform.Translate(new Vector3(0, 10 * MovingSpeed, 0) * Time.deltaTime);
	}
	
	public void Rotation(float Angle)
	{
		if (Angle == 0)
		{
			return;
		}
		if (!(x < maxX) || !(step.z * Angle / System.Math.Abs(Angle) >= 0))
		{
			aI.RotateForfeit();
		}
		x = 0;
		maxX = System.Math.Abs(Angle) / Angles * 0.02f;
		step = Quaternion.Euler(0f, 0f, Angles * (Angle / System.Math.Abs(Angle)));
	}


	void FixedUpdate()
	{

		x += Time.deltaTime;
		if (x <= maxX)
		{
			projector.rotation *= step; 
		}
		

		transform.Translate(new Vector3(0, MovingSpeed, 0) * Time.deltaTime);

		if (transform.position.x > Screen.width * 0.5f || transform.position.x < -Screen.width * 0.5f ||
			transform.position.y > Screen.height * 0.5f || transform.position.y < -Screen.height * 0.5f
			)
		{
			outOfBound = true;
			if (transform.position.x > Screen.width * 0.5f)
			{
				transform.position += new Vector3(-10f, 0f);
			}
			if (transform.position.x  < -Screen.width * 0.5f)
			{
				transform.position += new Vector3(10f, 0f);
			}
			if (transform.position.y > Screen.height * 0.5f)
			{
				transform.position += new Vector3(0f, -10f);
			}
			if (transform.position.y < -Screen.height * 0.5f)
			{
				transform.position += new Vector3(0f, 10f);
			}


			projector.rotation *= Quaternion.Euler(0f, 0f, 180f + Random.Range(-90f, 90f));
		}
		else
		{
			if (outOfBound)
			{
				outOfBound = false;
				aI.BoundsForfeit();
			}
		}

		Rotation(aI.Calculate());
	}
}
