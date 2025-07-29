using System;
using TB_Battle.Data;
using TB_Battle.Model.Entity;
using TB_Battle.Model.Party;

namespace TB_Battle.Model.Action
{
    public sealed class Attack : IAction
    {
        private readonly AttackData _data;

        public string Name => _data.attackName;
        public IEntity Entity { get; }
        public void Execute() => throw new NotImplementedException();
        

        public int Mana => _data.mana;
        public int Energy => _data.energy;

        private int Damage => _data.damage;
        private bool OnlyOneTarget => _data.areaAttack;
        
        public Attack(AttackData data, IEntity entity)
        {
            _data = data;
            Entity = entity;
        }
        
        public void Execute(IEntity target, IParty party = null)
        {
            if (Entity.Mana < Mana || Entity.Energy < Energy)
                throw new InvalidOperationException("Not enough Mana or Energy to execute the action.");
            
            Entity.Mana -= Mana;
            Entity.Energy -= Energy;
         
            if (OnlyOneTarget)
                target.TakeDamage(Damage);
            else
                party?.Entities.ForEach(e => e.TakeDamage(Damage));
            
        }
    }
}
