using TB_Battle.Data;
using TB_Battle.Model.Entity;
using TB_Battle.Model.Party;

namespace TB_Battle.Model.Action
{
    public sealed class Attack : IAction
    {
        private readonly AttackData _data;

        public string Name => _data.attackName;

        private int Mana => _data.mana;
        private int Energy => _data.energy;
        
        private int Damage => _data.damage;
        public bool OnlyOneTarget => _data.areaAttack;
        
        public Attack(AttackData data)
        {
            _data = data;
        }

        public void Execute(IEntity source, IParty party, int target = -10)
        {
            if (source.Mana < Mana || source.Energy < Energy)
                return;

            source.Mana -= Mana;
            source.Energy -= Energy;

            if (OnlyOneTarget) 
                party.Entities[target].TakeDamage(Damage);
            else 
                party.Entities.ForEach(e => e.TakeDamage(Damage));
        }
    }
}
