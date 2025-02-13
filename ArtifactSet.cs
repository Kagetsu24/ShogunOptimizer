﻿namespace ShogunOptimizer
{
    public class ArtifactSet
    {
        public virtual double GetStat(StatType statType, Build build, Character character, int count)
        {
            return 0;
        }

        public override string ToString() => GetType().Name;
    }
}
