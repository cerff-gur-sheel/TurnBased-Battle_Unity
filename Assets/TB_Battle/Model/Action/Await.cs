using TB_Battle.Model.Entity;
using TB_Battle.Model.Party;

namespace TB_Battle.Model.Action
{
    /// <summary>
    /// Especial Action : Used when the Entity has no energy to do anything
    /// </summary>
    public class Await : IAction
    {
        public string Name => "WAIT";
        
        public IEntity Entity { get; }
        
        public Await(IEntity entity)
        {
            Entity = entity;
        }
        
        public void Execute()
        {
            // todo: do nothing
            // maybe add mana/energy?
        }

        public void Execute(IEntity target, IParty party = null) => throw new System.NotImplementedException();
    }
}
