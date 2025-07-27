using TB_Battle.Runtime.Data;
using UnityEngine;

namespace TB_Battle.Runtime.Model.Entity
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
        }

        public virtual void TakeDamage(int damage)
        {
            Health = Mathf.Max(Health - damage, 0);
        }
    }
}
