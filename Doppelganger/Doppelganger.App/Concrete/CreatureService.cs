using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common.Creatures;

namespace Doppelganger.App.Concrete
{
    public class CreatureService : ICreatureService
    {
        private List<Creature> _creatures;

        public CreatureService()
        {
            _creatures = new List<Creature>();
        }
        public List<Creature> GetCrts()
        {
            return _creatures;
        }

        public void SetCrts(List<Creature> creatures)
        {
            this._creatures = creatures;
        }
    }
}