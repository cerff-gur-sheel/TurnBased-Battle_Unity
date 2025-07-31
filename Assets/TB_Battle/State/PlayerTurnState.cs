using TB_Battle.Model.Party;

namespace TB_Battle.State
{
    public class PlayerTurnState : ITurnState 
    {
        private IParty _enemyParty;
        private IParty _playerParty;
        
        public void Enter(IParty source, IParty targetParty)
        {
            _playerParty = source; 
            _enemyParty = targetParty;
            // todo: show UI
            
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
