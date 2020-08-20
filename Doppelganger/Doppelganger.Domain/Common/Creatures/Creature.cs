using System;

namespace Doppelganger.Domain.Common.Creatures
{
    public class Creature
    {
        private const byte MIN_ATTACK = 5;
        private const byte MAX_ATTACK = 20;

        private const byte MIN_SPEED = 1;
        private const byte MAX_SPEED = 10;

        private const byte MIN_MAXHP = 10;
        private const byte MAX_MAXHP = 99;

        private static readonly Random numberGenerator = new Random();

        public Creature()
        {
            Attack = (byte)numberGenerator.Next(MIN_ATTACK, MAX_ATTACK + 1);
            Speed = (byte)numberGenerator.Next(MIN_SPEED, MAX_SPEED + 1);
            MaxHP = (byte)numberGenerator.Next(MIN_MAXHP, MAX_MAXHP + 1);
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
