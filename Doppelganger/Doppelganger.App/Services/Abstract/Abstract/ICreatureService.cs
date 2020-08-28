using System.Collections.Generic;
using Doppelganger.Domain.Common.Creatures;

namespace Doppelganger.App.Services.Abstract.Abstract
{
    public interface ICreatureService
    {
        List<Creature> GetCrts();
        void GenerateNewCrts();
        void MakeGivenCreatureFriendly(int chosenAlly);
        void ClearCrts();
        void RegisterHit(byte damage, int creatureId);
        void SwitchBodiesWith(int chosenOppId);
    }
}