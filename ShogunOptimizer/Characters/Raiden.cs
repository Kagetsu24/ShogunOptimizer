﻿using System;

namespace ShogunOptimizer.Characters
{
    public class Raiden : Character
    {
        public int Resolve = 60;

        public Raiden()
        {
            BaseAtk = 337;
            BaseHp = 12907;

            AscensionStat = .32;
            AscensionStatType = StatType.EnergyRecharge;
        }

        public const string PropertySkillInitial = "skillInitial";
        public const string PropertyBurstInitial = "burstInitial";
        public const string PropertyBurstEnergyRestored = "burstEnergyRestored";

        public override double Calculate(string property, Build build, HitType hitType, Enemy enemy)
        {
            switch (property)
            {
                case PropertySkillInitial:
                    return (1.172 * GetTalentPercentageScaling(SkillLevel)) * GetDamage(build, DamageType.Skill, Element.Electro, hitType, enemy);
                case PropertyBurstInitial:
                    var burstScaling = GetTalentPercentageScaling(BurstLevel);
                    return (4.008 * burstScaling + 0.0389 * burstScaling * Resolve) * GetDamage(build, DamageType.Burst, Element.Electro, hitType, enemy);
                case PropertyBurstEnergyRestored:
                    return 5 * Math.Min(2.5, 1.6 + 0.1 * BurstLevel) * (1 + .006 * Math.Max(0, base.GetStat(StatType.EnergyRecharge, build) - 1));

                default:
                    return base.Calculate(property, build, hitType, enemy);
            }
        }

        public override double GetStat(StatType statType, Build build)
        {
            var stat = base.GetStat(statType, build);

            switch (statType)
            {
                case StatType.ElectroDmgBonus:
                    stat += .4 * Math.Max(0, base.GetStat(StatType.EnergyRecharge, build) - 1);
                    break;
                case StatType.DefShred when Constellation >= 2:
                    stat += .6;
                    break;
            }

            return stat;
        }
    }
}
