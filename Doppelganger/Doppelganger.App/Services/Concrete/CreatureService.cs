using System;
using System.Collections.Generic;
using Doppelganger.App.Services.Abstract;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Creatures;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Services.Concrete
{
    public class CreatureService : ICreatureService
    {
        private List<Creature> _creatures;

        public CreatureService()
        {
            _creatures = new List<Creature>();
        }

        private void VerifyId(int creatureId)
        {
            if (!(creatureId >= 0 && creatureId < _creatures.Count && _creatures[creatureId] != null))
            {
                throw new ArgumentException("There is no creature with id " + creatureId + ".");
            }
        }

        public bool IsCreatureFriendly(int creatureId)
        {
            VerifyId(creatureId);
            return _creatures[creatureId] is Ally;
        }

        public byte GetCreatureAttackById(int creatureId)
        {
            VerifyId(creatureId);
            return _creatures[creatureId].Attack;
        }

        public byte GetCreatureSpeedById(int creatureId)
        {
            VerifyId(creatureId);
            return _creatures[creatureId].Speed;
        }

        public byte GetCreatureMaxHPById(int creatureId)
        {
            VerifyId(creatureId);
            return _creatures[creatureId].MaxHP;
        }

        public byte GetCreatureCurrentHPById(int creatureId)
        {
            VerifyId(creatureId);
            return _creatures[creatureId].CurrentHP;
        }

        public bool IsCreatureDead(int creatureId)
        {
            VerifyId(creatureId);
            return _creatures[creatureId].CurrentHP <= 0;
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
            VerifyId(chosenAlly);
            for (int i = 0; i < _creatures.Count; i++)
            {
                if (i == chosenAlly)
                {
                    _creatures[i] = new Ally(_creatures[i]);
                }
            }
        }

        public void RegisterHit(byte damage, int creatureId)
        {
            VerifyId(creatureId);
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
            VerifyId(chosenOppId);
            if (IsCreatureFriendly(chosenOppId))
            {
                throw new ArgumentException(
                    "The creature with selected id is already friendly and as such is not a valid target for switching bodies with.");
            }
            // ReSharper disable once PossibleNullReferenceException
            float previousAllysHPPercent = _creatures.Find(cr => cr is Ally).CurrentHP
                                           // ReSharper disable once PossibleNullReferenceException
                                           / (float) _creatures.Find(cr => cr is Ally).MaxHP;
            float previousOppsHPPercent = _creatures[chosenOppId].CurrentHP / (float) _creatures[chosenOppId].MaxHP;
            bool leftOldAlly = false, assumedNewShape = false;
            for (int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; creatureId++)
            {
                if (!leftOldAlly && _creatures[creatureId] is Ally)
                {
                    Opponent oldAlly = (Ally) _creatures[creatureId];
                    oldAlly.CurrentHP = (byte) Math.Ceiling(oldAlly.MaxHP * previousOppsHPPercent);
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