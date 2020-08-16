using System.Collections;
using System.Threading;
using UnityEngine;

static public class SpiritDash
{
    static public bool SpiritSummoned { get; private set; } = false;
    static public bool Active = true;
    static public bool Enabled = false;

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

                    Spirit.transform.position += new Vector3(axisH, axisV) * 0.05f;

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
