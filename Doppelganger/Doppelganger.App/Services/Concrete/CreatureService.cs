using System;
using System.Collections.Generic;
using Doppelganger.App.Services.Abstract;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Creatures;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Services.Concrete.Concrete
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

        public void GenerateNewCrts()
        {
            _creatures = new List<Creature>();
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                _creatures.Add(new Opponent());
            }
        }

        public void MakeGivenCreatureFriendly(int chosenAlly)
        {
            for (int i = 0; i < _creatures.Count; i++)
            {
                if (i == chosenAlly)
                {
                    _creatures[i] = new Ally(_creatures[i]);
                }
            }
        }

        public void ClearCrts()
        {
            _creatures = new List<Creature>();
        }

        public void RegisterHit(byte damage, int creatureId)
        {
            if (damage < _creatures[creatureId].CurrentHP)
            {
                _creatures[creatureId].CurrentHP -= damage;
            }
            else
            {
                _creatures[creatureId].CurrentHP = 0;
            }
        }

        public void SwitchBodiesWith(int chosenOppId)
        {
            // ReSharper disable once PossibleNullReferenceException
            float previousAllysHPPercent = _creatures.Find(cr => cr is Ally).CurrentHP
                                           // ReSharper disable once PossibleNullReferenceException
                                           / (float) _creatures.Find(cr => cr is Ally).MaxHP;
            bool leftOldAlly = false, assumedNewShape = false;
            for (int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; creatureId++)
            {
                if (!leftOldAlly && _creatures[creatureId] is Ally)
                {
                    Opponent oldAlly = (Ally) _creatures[creatureId];
                    _creatures[creatureId] = oldAlly;
                    leftOldAlly = true;
                }

                if (!assumedNewShape && creatureId == chosenOppId)
                {
                    Ally newAlly = (Opponent) _creatures[creatureId];
                    newAlly.CurrentHP = (byte) Math.Ceiling(newAlly.MaxHP * previousAllysHPPercent);
                    _creatures[creatureId] = newAlly;
                    assumedNewShape = true;
                }

                if (assumedNewShape && leftOldAlly)
                {
                    break;
                }
            }
        }
    }
}