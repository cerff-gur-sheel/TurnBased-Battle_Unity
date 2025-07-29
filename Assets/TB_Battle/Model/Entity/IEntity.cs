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
        int Mana { get; set; }
        int Energy { get; set; }
        List<Attack> Attacks { get; }
        /// <summary>
        /// Wait to next turn
        /// </summary>
        IAction Await { get; }
    }
}
