﻿using System.Collections.Generic;

namespace ShogunOptimizer
{
    public class Build
    {
        public double Value;

        public Weapon Weapon;

        public Artifact Flower;
        public Artifact Plume;
        public Artifact Sands;
        public Artifact Goblet;
        public Artifact Circlet;

        public IEnumerable<Artifact> Artifacts
        {
            get
            {
                yield return Flower;
                yield return Plume;
                yield return Sands;
                yield return Goblet;
                yield return Circlet;
            }
        }
    }
}
