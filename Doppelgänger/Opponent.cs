namespace Doppelgänger
{
    internal class Opponent : Creature
    {
        internal byte CurrentHP { get; set; }
        internal Opponent(Creature cr) : base(cr.Attack, cr.Speed, cr.MaxHP)
        {
            CurrentHP = cr.MaxHP;
        }

        //public static implicit operator Ally(Opponent opp) => new Ally(opp);
    }
}