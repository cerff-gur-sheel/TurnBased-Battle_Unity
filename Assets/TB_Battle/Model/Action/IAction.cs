using TB_Battle.Model.Entity;

namespace TB_Battle.Model.Action
{
    public interface IAction
    {
        string Name { get; }
        void Execute(IEntity source, IEntity target = null);
    }
}
