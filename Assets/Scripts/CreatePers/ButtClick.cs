using UnityEngine;

class ButtClick : MonoBehaviour
{
    public void Click(string Num_Orientation)
    {
        if (Num_Orientation[1] == 'R')
            Controler.Right[int.Parse(Num_Orientation[0].ToString())]++;
        else
            Controler.Left[int.Parse(Num_Orientation[0].ToString())]++;
    }
}
