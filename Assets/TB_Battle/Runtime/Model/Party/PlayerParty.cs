using TB_Battle.Runtime.Data;
using TB_Battle.Runtime.Model.Entity;

namespace TB_Battle.Runtime.Model.Party
{
    public class PlayerParty : PartyBase
    {
        public PlayerParty(PartyData data) : base(data) {}

        protected override IEntity CreateEntity(EntityData data)
        {
            return new Hero(data);
        }
    }
}
