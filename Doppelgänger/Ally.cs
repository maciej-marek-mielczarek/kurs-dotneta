namespace Doppelgänger
{
    internal class Ally : Creature
    {
        internal Ally(Creature cr) : base(cr.Attack, cr.Speed, cr.MaxHP, cr.MaxHP)
        {
        }
    }
}