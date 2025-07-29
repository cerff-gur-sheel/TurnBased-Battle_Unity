using TB_Battle.Controller;
using TB_Battle.Model.Party;

namespace TB_Battle.State
{
    public class PlayerTurnState : ITurnState 
    {
        private CombatController _controller;
        private IParty _enemyParty;
        private IParty _playerParty;
        
        public void Enter(CombatController controller, IParty source, IParty targetParty)
        {
            _controller = controller;
            _playerParty = source; 
            _enemyParty = targetParty;
        }

        public void Execute()
        {
            // todo: show UI
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}