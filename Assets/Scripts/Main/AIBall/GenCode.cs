using System.Collections.Generic;
public class GenCode
{
    public delegate int Response(BallProperties objectProperties);

    private int zeroResponse(BallProperties objectProperties)
    {
        return 0;
    }

    public int GenLenght { get; private set; }

    private List<Response> genes;
    public List<int> weight;
    public GenCode()
    {
        genes = new List<Response>();
        weight = new List<int>();
        GenLenght = 1;
        genes.Add(zeroResponse);
        weight.Add(-1);
    }

    public GenCode(GenCode other)
    {
        genes = new List<Response> (other.genes);
        weight = new List<int>(other.weight);
        GenLenght = other.GenLenght;
    }

    public Response this[int i]
    {
        get
        {
            if (i > GenLenght)
                return zeroResponse;
            return genes[i];
        }
        set
        {
            if (i > GenLenght)
                return;
            genes[i] = value;
        }
    }


    public void GenMutate(int mutationPower)
    {
        float mutation_stage = UnityEngine.Random.value;
        if (mutation_stage <= 0.33f && GenLenght > 1)
        {
            int id_gen_to_delete = UnityEngine.Random.Range(0, GenLenght);
            genes.RemoveAt(id_gen_to_delete);
            weight.RemoveAt(id_gen_to_delete);
            GenLenght--;

        }
        if (mutation_stage >= 0.66f)
        {
           
            genes.Add(zeroResponse);
            weight.Add(-1);
            GenLenght++;
        }
        float cols_gen_to_mutate = UnityEngine.Random.Range(0, GenLenght);
        for (int i = 0; i < cols_gen_to_mutate; ++i)
        {

            int id_gen_to_mutate = UnityEngine.Random.Range(0, GenLenght);
            try
            {
                genes[id_gen_to_mutate] = zeroResponse;
                weight[id_gen_to_mutate] = -1;
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogError(id_gen_to_mutate.ToString() + ' ' + genes.Count + ' ' + GenLenght.ToString() + "\n" + e.Message);
            }
        }
    }

    public int id_next_empty() => genes.IndexOf(zeroResponse);

    

}
