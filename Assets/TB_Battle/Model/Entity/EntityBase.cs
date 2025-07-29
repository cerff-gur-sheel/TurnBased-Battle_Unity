using System.Collections.Generic;
using TB_Battle.Data;
using TB_Battle.Model.Action;
using UnityEngine;

namespace TB_Battle.Model.Entity
{
    public abstract class EntityBase : IEntity
    {
        private readonly EntityData _data;

        public string Name => _data.entityName;
        public int Health { get; private set; }

        public bool IsAlive => Health > 0;

        protected EntityBase(EntityData data)
        {
            _data = data;
            Health = data.life;
            Attacks = new List<Attack>();
            foreach (var attackData in data.attacks) Attacks.Add(new Attack(attackData));
        }

        public virtual void TakeDamage(int damage)
        {
            Health = Mathf.Max(Health - damage, 0);
        }

        public List<Attack> Attacks { get; }
    }
}
