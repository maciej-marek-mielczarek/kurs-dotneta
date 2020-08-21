using System;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.Domain.Common.Creatures
{
    public class Creature
    {
        private static readonly Random NumberGenerator = new Random();

        public Creature()
        {
            Attack = (byte)NumberGenerator.Next(BalanceSettings.MinAttack, BalanceSettings.MaxAttack + 1);
            Speed = (byte)NumberGenerator.Next(BalanceSettings.MinSpeed, BalanceSettings.MaxSpeed + 1);
            MaxHP = (byte)NumberGenerator.Next(BalanceSettings.MinHP, BalanceSettings.MaxHP + 1);
        }

        internal Creature(byte attack, byte speed, byte maxHP, byte currentHP)
        {
            Attack = attack;
            Speed = speed;
            MaxHP = maxHP;
            CurrentHP = currentHP;
        }

        public byte Attack { get; }

        public byte Speed { get; }

        public byte MaxHP { get; }

        public byte CurrentHP { get; set; }
    }
}
