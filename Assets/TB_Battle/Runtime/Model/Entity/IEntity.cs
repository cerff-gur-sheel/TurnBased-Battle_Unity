namespace TB_Battle.Runtime.Model.Entity
{
    public interface IEntity
    {
        string Name { get; }
        bool IsAlive { get; }
        int Health { get;}
        void TakeDamage(int damage);
    }
}
