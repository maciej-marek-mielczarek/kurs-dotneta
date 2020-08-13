using System;

namespace Doppelgänger
{
    internal class Creature
    {
        private const byte MIN_ATTACK = 5;
        private const byte MAX_ATTACK = 20;

        private const byte MIN_SPEED = 1;
        private const byte MAX_SPEED = 10;

        private const byte MIN_MAXHP = 10;
        private const byte MAX_MAXHP = 100;

        private static readonly Random numberGenerator = new Random();

        internal Creature()
        {
            Attack = (byte)numberGenerator.Next(MIN_ATTACK, MAX_ATTACK + 1);
            Speed = (byte)numberGenerator.Next(MIN_SPEED, MAX_SPEED + 1);
            MaxHP = (byte)numberGenerator.Next(MIN_MAXHP, MAX_MAXHP + 1);
        }

        internal Creature(byte attack, byte speed, byte maxHP)
        {
            Attack = attack;
            Speed = speed;
            MaxHP = maxHP;
        }

        internal byte Attack { get; }

        internal byte Speed { get; }

        internal byte MaxHP { get; }
    }
}