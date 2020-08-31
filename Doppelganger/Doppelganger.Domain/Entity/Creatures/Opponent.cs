using Doppelganger.Domain.Common.Creatures;

namespace Doppelganger.Domain.Entity.Creatures
{
    public class Opponent : Creature
    {
        internal Opponent(Ally ally) : base(ally.Attack, ally.Speed, ally.MaxHP, ally.CurrentHP)
        {
        }
        public Opponent()
        {
        }

        public static implicit operator Ally(Opponent opp) => new Ally(opp);
    }
}
