namespace Doppelgänger
{
    internal class Opponent : Creature
    {

        internal Opponent(Creature cr) : base(cr.Attack, cr.Speed, cr.MaxHP, cr.MaxHP)
        {
        }

        //public static implicit operator Ally(Opponent opp) => new Ally(opp);
    }
}