using Doppelganger.Domain.Common.Creatures;

namespace Doppelganger.Domain.Entity.Creatures
{
    public class Ally : Creature
    {
        public Ally(Creature cr) : base(cr.Attack, cr.Speed, cr.MaxHP, cr.MaxHP)
        {
        }
        internal Ally(Opponent opp) : base(opp.Attack, opp.Speed, opp.MaxHP, opp.MaxHP)
        {
        }
        public static implicit operator Opponent(Ally ally) => new Opponent(ally);
    }
}
