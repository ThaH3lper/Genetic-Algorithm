﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class Population
    {
        AIEntity[] entitys;
        List<AIEntity> dead;

        SimulationWorld world;
        int amount;
        public Population(SimulationWorld world, int amount)
        {
            this.amount = amount;
            this.world = world;
            entitys = new AIEntity[amount];
            dead = new List<AIEntity>();

            for (int i = 0; i < amount; i++)
                entitys[i] = new AIEntity(world);
        }

        public void Update(float delta)
        {
            foreach (AIEntity e in entitys)
            {
                e.Update(delta);
                if (e.IsDead() && !dead.Contains(e))
                    dead.Add(e);
            }
        }

        public bool IsDead()
        {
            return (dead.Count == entitys.Length);
        }

        public void SortAfterFitness()
        {
            SortAlgorithm.MergeSort(entitys, 0, entitys.Length - 1);
        }

        public int GetAmount() { return amount; }

        public void Breed()
        {
            dead.Clear();
            BreedMachine.Breed(world, this);
        }

        public void Mutate(float percentageOfGeneMutation)
        {
            for (int i = 1; i < amount; i++)
            {
                entitys[i].GetGenome().Mutate(percentageOfGeneMutation);
                entitys[i].UpdateMutation();
            }
        }

        public AIEntity[] GetEntitys() { return entitys; }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (AIEntity e in entitys)
                e.Draw(spriteBatch);
            spriteBatch.DrawString(Globals.font, "Living: " + (amount - dead.Count), new Vector2(0, 0), Color.Black);
        }
    }
}