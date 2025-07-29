using System.Collections.Generic;
using TB_Battle.Model.Action;

namespace TB_Battle.Model.Entity
{
    public interface IEntity
    {
        string Name { get; }
        bool IsAlive { get; }
        int Health { get;}
        void TakeDamage(int damage);
        List<Attack> Attacks { get; }
    }
}
