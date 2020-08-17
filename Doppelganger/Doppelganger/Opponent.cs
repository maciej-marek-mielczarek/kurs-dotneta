namespace Doppelganger
{
    internal class Opponent : Creature
    {

        internal Opponent(Creature cr) : base(cr.Attack, cr.Speed, cr.MaxHP, cr.MaxHP)
        {
        }
        internal Opponent(Ally ally) : base(ally.Attack, ally.Speed, ally.MaxHP, 0)
        {
        }
        public static implicit operator Ally(Opponent opp) => new Ally(opp);
    }
}
