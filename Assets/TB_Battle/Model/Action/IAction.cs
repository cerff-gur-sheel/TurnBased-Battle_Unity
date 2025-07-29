using TB_Battle.Model.Entity;
using TB_Battle.Model.Party;

namespace TB_Battle.Model.Action
{
    public interface IAction
    {
        string Name { get; }
        IEntity Entity { get; }
        void Execute();
        void Execute(IParty party) => Execute(null, party);
        void Execute(IEntity target, IParty party = null);
    }
}
