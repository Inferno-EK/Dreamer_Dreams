using System.Collections.Generic;
using UnityEngine;

public static class AIContainer
{
    public static List<GameObject> objects = new List<GameObject>();
    public static List<BallAI> ais = new List<BallAI>();
    private static List<int> next_Id = new List<int>();
    public static void Add(GameObject ball, ref int Id)
    {
        if (next_Id.Count == 0)
        {
            Id = objects.Count;
            objects.Add(ball);
            ais.Add(ball.transform.GetComponent<BallAI>());
            return;
        }
        Id = next_Id[0];
        next_Id.RemoveAt(0);
        objects[Id] = ball;
        ais[Id] = ball.transform.GetComponent<BallAI>();

    }
    public static void Remove(int i)
    {
        next_Id.Add(i);
        objects[i] = null;
        ais[i] = null;
    }

    public static float[] AllDistanseFrom(int i)
    {
        float[] result = new float[ais.Count];
        for (int j = 0; j < objects.Count; ++j)
        {
            try
            {
                result[j] = Vector3.Distance(objects[i].transform.position, objects[j].transform.position);
            }
            catch (System.Exception)
            {

                result[j] = -1;
            }

            
        }
        return result;
    }

    public static int FindNearest(int i)
    {
        float[] distanse = AllDistanseFrom(i);
        int minId = -1;
        float minValue = float.MaxValue;
        for (int j = 0; j < objects.Count; ++j)
        {
            if (i == j) continue;
            if (minValue > distanse[j] && distanse[j] != -1)
            {
                minValue = distanse[j];
                minId = j;
            }
        }
        return minId;
    }

    public static float[] AllDistanseFrom(Vector3 position)
    {
        float[] result = new float[ais.Count];
        for (int j = 0; j < objects.Count; ++j)
        {
            try
            {
                result[j] = Vector3.Distance(position, objects[j].transform.position);
            }
            catch (System.Exception)
            {
                result[j] = -1;
            }


        }
        return result;
    }

    public static int FindNearest(Vector3 position)
    {
        float[] distanse = AllDistanseFrom(position);
        int minId = -1;
        float minValue = float.MaxValue;
        for (int j = 0; j < objects.Count; ++j)
        {
            if (minValue > distanse[j] && distanse[j] != -1)
            {
                minValue = distanse[j];
                minId = j;
            }
        }
        return minId;
    }

}
