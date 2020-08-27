using Doppelganger.Domain.Common.Creatures;
using System.Collections.Generic;

namespace Doppelganger.App.Managers
{
    public class CreatureService : ICreatureService
    {
        private List<Creature> creatures;

        public CreatureService()
        {
            creatures = new List<Creature>();
        }
        public List<Creature> GetCrts()
        {
            return creatures;
        }

        public void SetCrts(List<Creature> creatures)
        {
            this.creatures = creatures;
        }
    }
}