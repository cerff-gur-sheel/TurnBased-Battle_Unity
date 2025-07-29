using TB_Battle.Data;
using TB_Battle.Model.Entity;

namespace TB_Battle.Model.Party
{
    public class EnemyParty : PartyBase
    {
        public EnemyParty(PartyData data) : base(data) {}

        protected override IEntity CreateEntity(EntityData data)
        {
            return new Enemy(data);
        }
    }
}
