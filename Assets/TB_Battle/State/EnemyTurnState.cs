using TB_Battle.Controller;
using TB_Battle.Model.Entity;
using TB_Battle.Model.Party;

namespace TB_Battle.State
{
    public class EnemyTurnState 
    {
        private CombatController _controller;
        private IEntity _source;
        private IParty _targetParty;
        
        public void Enter(CombatController controller, IEntity source, IParty targetParty)
        {
            _controller = controller;
            _source = source; 
            _targetParty = targetParty;
            // todo: activate UI
            
            var target = _controller.Player.Entities[0];
            ExecuteAttack(); // using for test
            Exit();
        }

        private void ExecuteAttack()
        {
            _source.Attacks[0].Execute(_source, _targetParty, 0);
        }

        public void Exit()
        {
            _controller.ToggleTurn();
        }
    }
}
