using TB_Battle.Data;
using TB_Battle.Model.Entity;

namespace TB_Battle.Model.Party
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
