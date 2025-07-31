using System;
using System.Linq;
using TB_Battle.Model.Action;
using TB_Battle.Model.Entity;
using TB_Battle.Model.Party;
using Random = System.Random;

namespace TB_Battle.State
{
    public class EnemyTurnState : ITurnState
    {
        private IParty _enemyParty;
        private IParty _playerParty;
        
        public void Enter(IParty source, IParty targetParty)
        {
            _enemyParty = source;
            _playerParty = targetParty; 
        }
        
        private static IAction SelectAction(IEntity entity)
        {
            var validAttacks = entity.Attacks
                .Where(a => entity.Energy >= a.Energy && entity.Mana >= a.Mana)
                .ToList();

            if (validAttacks.Count == 0)
                return entity.Await; // too tired to execute any attack
            
            var randomIndex = UnityEngine.Random.Range(0, validAttacks.Count);
            return validAttacks[randomIndex];
        }
        
        private static IEntity SelectTarget(IParty target)
        {
            if (!target.IsGroupAlive)
                throw new InvalidOperationException("Cannot select a target from a dead party.");

            var aliveEntities = target.Entities.Where(e => e.IsAlive).ToList();
            if (aliveEntities.Count == 0)
                throw new InvalidOperationException("No alive entities to select.");

            var random = new Random();
            return aliveEntities[random.Next(aliveEntities.Count)];
        }
        
        private void ExecuteAction(IAction action, IEntity target)
        {
            action.Execute(target);
            Exit();
        }

        private void ExecuteAction(IAction action, IParty target)
        {
            action.Execute(target);
            Exit();
        }
        
        public void Execute()
        {
            foreach (var entity in _enemyParty.Entities)
            {
                var action = SelectAction(entity);
                if (action is Await)
                {
                    action.Execute(entity);
                    break;
                }
                var target = SelectTarget(_playerParty);
                ExecuteAction(action, target);
            }
        }
        
        public void Exit()
        {
        }
    }
}
