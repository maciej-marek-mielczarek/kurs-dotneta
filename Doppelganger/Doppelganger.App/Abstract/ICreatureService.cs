using System.Collections.Generic;
using Doppelganger.Domain.Common.Creatures;

namespace Doppelganger.App.Abstract
{
    public interface ICreatureService
    {
        List<Creature> GetCrts();
        void GenerateNewCrts();
        void MakeAllHostileExcept(int chosenAlly);
        void ClearCrts();
        void RegisterHit(byte oppsStrike, int creatureId);
        void SwitchBodiesWith(int chosenOppId);
    }
}