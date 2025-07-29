using TB_Battle.Controller;
using TB_Battle.Model.Entity;

namespace TB_Battle.State
{
    public class EnemyTurnState : ITurnState
    {
        private CombatController _controller;
        private IEntity _enemy;
        
        public void Enter(CombatController controller, IEntity entity)
        {
            _controller = controller;
            _enemy = entity;
            // todo: activate UI
            
            var target = _controller.Player.Entities[0];
            ExecuteAttack(target); // using for test
            Exit();
        }

        public void ExecuteAttack(IEntity target)
        {
            _enemy.Attacks[0].Execute(target);
        }

        public void Exit()
        {
            _controller.ToggleTurn();
        }
    }
}
