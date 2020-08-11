using System.Threading;
using UnityEngine;

public static class Dasher 
{
    static public bool Enabled = false;

    static public void Dash(Rigidbody2D _rigidbody2D, Enums.Derection derection)
    {
        if (enable && !inJump && Enabled)
        {
            _rigidbody2D.velocity = Vector3.zero;
            _rigidbody2D.angularVelocity = 0;
            _rigidbody2D.AddForce(
                new Vector2(
                    (derection == Enums.Derection.Left ? -1 : 1) * 300,
                    0
                )
            );

            inJump = true;
            recharge();
        }
    }

    static public void Refresh()
    {
        inJump = false;
    }

    static private bool inJump = false;
    static private bool enable = true;
    static private void recharge()
    {
        enable = false;
        Timer reroll = new Timer((object obj) => { enable = true; }, new AutoResetEvent(true), 100, 0);
    }

}
