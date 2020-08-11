#define MYDEBUG

using Enums;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMove : MonoBehaviour
{
    public bool EnableMove = true;

    [SerializeField] private GameObject spirit;
    private Rigidbody2D _rigidBody;
    private Vector3 scale;

    private void Start()
    {
        SpiritDash.Spirit = spirit;
        scale = transform.localScale;
        _rigidBody = transform.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.transform.GetComponent<IsGround>() != null)
        {
            Jumper.Refresh();
            Dasher.Refresh();
        }
    }

    Derection nowDerection = Derection.Right;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(SpiritDash.SpiritPath(this));
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = 0;
        }

        if (EnableMove)
        {
            float axis = Input.GetAxis("Horizontal");
            float derection = Input.GetAxisRaw("Horizontal");

            if (derection != 0)
            {
                var nd = axis > 0 ? Derection.Right : Derection.Left;
                if (nowDerection != nd)
                {
                    scale.x *= -1;
                    nowDerection = nd;
                }
                transform.localScale = scale;
            }


            _rigidBody.transform.position += new Vector3(axis, 0) * 0.05f;
#if MYDEBUG
            if (Input.GetKeyDown(KeyCode.J))
            {
                Jumper.Inc();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpiritDash.Enabled = true;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                Dasher.Enabled = true;
            }
#endif
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Dasher.Dash(_rigidBody, nowDerection);
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Jumper.Jump(_rigidBody));
            }
        }
    }
}
