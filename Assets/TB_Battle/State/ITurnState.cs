using TB_Battle.Controller;
using TB_Battle.Model.Party;

namespace TB_Battle.State
{
    public interface ITurnState
    {
        void Enter(CombatController controller, IParty source, IParty targetParty);
        void Execute();
        void Exit();
    }
}