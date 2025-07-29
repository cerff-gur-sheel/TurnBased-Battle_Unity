using TB_Battle.Model.Entity;
using TB_Battle.Model.Party;

namespace TB_Battle.Model.Action
{
    public interface IAction
    {
        string Name { get; }
        void Execute(IEntity source, IParty party, int target = -10);
    }
}
