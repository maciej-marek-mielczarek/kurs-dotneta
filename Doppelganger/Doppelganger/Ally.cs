using System;

namespace Doppelganger
{
    internal class Ally : Creature
    {
        internal Ally(Creature cr) : base(cr.Attack, cr.Speed, cr.MaxHP, cr.MaxHP)
        {
        }
        internal Ally(Opponent opp) : base(opp.Attack, opp.Speed, opp.MaxHP, opp.MaxHP)
        {
        }
        public static implicit operator Opponent(Ally ally) => new Opponent(ally);
    }
}
