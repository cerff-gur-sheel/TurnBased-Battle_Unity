using TB_Battle.Controller;
using TB_Battle.Model.Entity;

namespace TB_Battle.State
{
    public interface ITurnState
    {
        void Enter(CombatController controller, IEntity entity);
        void ExecuteAttack(IEntity target);
        void Exit();
    }
}