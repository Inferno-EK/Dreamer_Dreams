using System.Collections;
using System.Threading;
using UnityEngine;

static public class SpiritDash
{
    static public bool SpiritSummoned { get; private set; } = false;
    static public bool Active = true;
    static public bool Enabled = false;
    static public bool MoveUp { get; private set; } = false;
    static public bool MoveDown { get; private set; } = false;
    static public bool MoveLeft { get; private set; } = false;
    static public bool MoveRight { get; private set; } = false;

    static private void recharge()
    {
        Active = false;
        Timer reroll = new Timer((object obj) => { Active = true; }, new AutoResetEvent(true), 5000, 0);
    }

    static public GameObject Spirit = null;
    static public IEnumerator SpiritPath(HeroMove hero)
    {
        if (Enabled && Active)
        {
            hero.EnableMove = false;
            if (!SpiritSummoned)
            {
                Spirit.transform.position = hero.transform.position;
                float time = 0;
                SpiritSummoned = true;
                Spirit.SetActive(true);
                while (SpiritSummoned && time <= 5f)
                {
                    float axisH = Input.GetAxis("Horizontal");
                    float axisV = Input.GetAxis("Vertical");

                    float axisHR = Input.GetAxisRaw("Horizontal");
                    float axisVR = Input.GetAxisRaw("Vertical");

                    MoveUp = axisVR == 1;
                    MoveDown = axisVR == -1;
                    MoveRight = axisHR == 1;
                    MoveLeft = axisHR == -1;

                    if (System.Math.Abs(axisH) >= System.Math.Abs(axisV))
                        Spirit.transform.position += new Vector3(axisH, 0) * 0.05f;
                    else
                        Spirit.transform.position += new Vector3(0, axisV) * 0.05f;

                    time += Time.fixedDeltaTime;
                    yield return new WaitForFixedUpdate();
                }

                hero.transform.position = Spirit.transform.position;

                hero.EnableMove = true;
                SpiritSummoned = false;
                Spirit.SetActive(false);
            }
            else
            {
                SpiritSummoned = false;
            }
            recharge();
        }

    }
}
