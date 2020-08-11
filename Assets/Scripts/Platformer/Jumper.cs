using System.Collections;
using UnityEngine;

public static class Jumper 
{
    static public IEnumerator Jump(Rigidbody2D _rigidBody)
    {
        int nowJump = ++countOfJump;
        if (nowJump <= maxJump)
        {
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = 0;
            float JumpPower = 0;
            while (Input.GetKey(KeyCode.Space) && JumpPower < 0.125f && nowJump == countOfJump)
            {

                _rigidBody.AddForce(new Vector2(0, 1) * 20);
                JumpPower += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    static public void Inc() 
    {
        maxJump++;
    }

    static public void Refresh()
    {
        countOfJump = 0;
    }

    static private int maxJump = 1;
    static private int countOfJump = 0;
}
