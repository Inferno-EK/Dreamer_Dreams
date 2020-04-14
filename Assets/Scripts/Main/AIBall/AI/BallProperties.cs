using System.Collections.Generic;
using UnityEngine;

public class BallProperties
{
    public delegate int Response(BallProperties objectProperties);
    
    public int Energy { get { return _energy; } set { if (value > maxEnergy) { _energy = maxEnergy; return; } if (value >= 0) { _energy = value; } else { _energy = -1; } } }
    public List<GenCode> Genes { get; }
    public int ColsGenes { get { return Genes.Count; } }
    public int LengthGenes { get { if (Genes.Count != 0) return Genes[0].GenLenght; else  return 0; } }

    public int MovingSpeed { get;  }
    public int RotationSpeed { get; }
    public int Health { get { return _health; } set { if (value >= 0) { _health = value; } } }
    public int BoundsForfeit { get; }
    public int RotateForfeit { get; }

    private int _energy;
    private int _health;
    private float mutationChance;
    private int mutationPower;
    private int maxEnergy;
    private int maxHealth;

    public BallProperties()
    {
        Genes = new List<GenCode>();
        maxHealth = 1;
        maxEnergy = 100;
        Energy = maxEnergy;
        Genes.Add(new GenCode());
        MovingSpeed = Random.Range(500, 1000);
        RotationSpeed = Random.Range(290, 550);
        BoundsForfeit = 50;
        RotateForfeit = 20;
        mutationChance = 0.25f;
        mutationPower = 5;
        Health = 1;
    }

    public BallProperties(BallProperties other)
    {
        other.Energy = other.maxEnergy;

        this.maxEnergy = other.maxEnergy;
        this.maxHealth = other.maxHealth;
        this.MovingSpeed = other.MovingSpeed;
        this.RotationSpeed = other.RotationSpeed;
        this.BoundsForfeit = other.BoundsForfeit;
        this.RotateForfeit = other.RotateForfeit;
        this.mutationChance = other.mutationChance;
        this.mutationPower = other.mutationPower;
        this.Genes = new List<GenCode>();
        foreach (var item in other.Genes)
        {
            Genes.Add(new GenCode(item));
        }

        if (mutationChance <= Random.Range(0f, 1f))
        {
            int mutate = MovingSpeed;
            MutationBasic(ref mutate);
            MovingSpeed = mutate;

            mutate = RotationSpeed;
            MutationBasic(ref mutate);
            RotationSpeed = mutate;

            mutate = BoundsForfeit;
            MutationBasic(ref mutate);
            BoundsForfeit = mutate;

            mutate = RotateForfeit;
            MutationBasic(ref mutate);
            RotateForfeit = mutate;

            mutate = maxEnergy;
            MutationBasic(ref mutate);
            maxEnergy = mutate;

            MutationGenes();
            MutationHealth();
            MutationMutationPower();
            MutationMutationChance();

        }

        Energy = maxEnergy;
        Health = maxHealth;
    }

    public BallProperties Split()
    {
        var bp = new BallProperties(this);
        return bp;
    }


    void MutationBasic(ref int Basic) // Speeds, maxEnergy and forfait
    {
        float mutation_stage = Random.Range(0f, 1f);
        if (mutation_stage <= 0.33f)
        {
            Basic -= Basic / 100 * mutationPower;
        }
        if (mutation_stage >= 0.66f)
        {
            Basic += Basic / 100 * mutationPower;
        }
    }

    void MutationGenes()
    {
        float mutation_stage = Random.Range(0f, 1f);
        if ((mutation_stage <= 0.0625f || (mutation_stage <= 0.25f && mutation_stage > 0.125f)) && Genes.Count > 1)
        {
            int id_gen_to_delete = Random.Range(0, Genes.Count);
            Genes.RemoveAt(id_gen_to_delete);
        }
        if (mutation_stage <= 0.125f)
        {
            foreach (var item in Genes)
            {
                item.GenMutate(mutationPower);
            }
        }
        if (mutation_stage >= 0.9375f)
        {
            Genes.Add(new GenCode());
        }
    }

    void MutationHealth()
    {
        float mutation_stage = Random.Range(0f, 1f);
        if (mutation_stage <= 0.125f && maxHealth > 1)
        {
            --maxHealth;
        }

        if (mutation_stage >= 0.9375f)
        {
            ++maxHealth;
        }
    }

    void MutationMutationChance()
    {
        float mutation_stage = Random.Range(0f, 1f);
        if (mutation_stage <= 0.33f )
        {
            mutationChance += 0.1f;
        }

        if (mutation_stage >= 0.66f)
        {
            mutationChance -= 0.1f;
        }
    }
    void MutationMutationPower()
    {
        float mutation_stage = Random.Range(0f, 1f);
        if (mutation_stage <= 0.33f)
        {
            mutationPower += 1;
        }

        if (mutation_stage >= 0.66f)
        {
            mutationPower -= 1;
        }
    }
}



