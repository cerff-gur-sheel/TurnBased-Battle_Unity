using TB_Battle.Data;
using TB_Battle.Model.Entity;

namespace TB_Battle.Model.Action
{
    public sealed class Attack : IAction
    {
        private readonly AttackData _data;

        public string Name => _data.attackName;
        
        public Attack(AttackData data)
        {
            _data = data;
        }

        public void Execute(IEntity source, IEntity target = null)
        {
            target?.TakeDamage(Damage);
        }

        public int Damage => _data.damage;
        public bool OnlyOneTarget => _data.areaAttack;
    }
}
