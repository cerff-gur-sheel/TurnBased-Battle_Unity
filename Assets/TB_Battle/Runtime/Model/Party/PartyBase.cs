using System.Collections.Generic;
using System.Linq;
using TB_Battle.Runtime.Data;
using TB_Battle.Runtime.Model.Entity;

namespace TB_Battle.Runtime.Model.Party
{
    public abstract class PartyBase : IParty
    {
        private readonly PartyData _data;

        public string GroupName => _data.groupName;
        public List<IEntity> Entities { get; }

        public bool IsGroupAlive => Entities.All(entity => entity.IsAlive);

        protected PartyBase(PartyData data)
        {
            _data = data;
            Entities = BuildEntities(_data.entities);
        }

        private List<IEntity> BuildEntities(IEnumerable<EntityData> data)
        {
            return data.Select(CreateEntity).ToList();
        }

        protected abstract IEntity CreateEntity(EntityData data);
    }
}
