namespace Doppelgänger
{
    internal class Ally : Creature
    {
        internal byte CurrentHP { get; set; }
        internal Ally(Creature cr) : base(cr.Attack, cr.Speed, cr.MaxHP)
        {
            CurrentHP = cr.MaxHP;
        }
    }
}