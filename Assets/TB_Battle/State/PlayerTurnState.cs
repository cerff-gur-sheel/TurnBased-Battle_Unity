using TB_Battle.Controller;
using TB_Battle.Model.Entity;

namespace TB_Battle.State
{
    public class PlayerTurnState : ITurnState
    {
        private CombatController _controller;
        private IEntity _player;
        
        public void Enter(CombatController controller, IEntity entity)
        {
            _controller = controller;
            _player = entity;
            // todo: activate UI

            // using for test (target will be selected on UI
            var target = _controller.Enemy.Entities[0];
            ExecuteAttack(target); 
            Exit();
        }

        public void ExecuteAttack(IEntity target)
        {
            
        }

        public void Exit()
        {
            _controller.ToggleTurn();   
        }
    }
}