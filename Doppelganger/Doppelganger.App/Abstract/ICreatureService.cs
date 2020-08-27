using Doppelganger.Domain.Common.Creatures;
using System.Collections.Generic;

namespace Doppelganger.App.Managers
{
    public interface ICreatureService
    {
        List<Creature> GetCrts();
        void SetCrts(List<Creature> creatures);
    }
}