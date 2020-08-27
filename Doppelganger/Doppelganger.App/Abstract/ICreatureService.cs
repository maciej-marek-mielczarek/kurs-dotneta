using System.Collections.Generic;
using Doppelganger.Domain.Common.Creatures;

namespace Doppelganger.App.Abstract
{
    public interface ICreatureService
    {
        List<Creature> GetCrts();
        void SetCrts(List<Creature> creatures);
    }
}