using System.Collections.Generic;
using TB_Battle.Model.Entity;

namespace TB_Battle.Model.Party
{
    public interface IParty
    {
        string GroupName { get; }
        List<IEntity> Entities { get; }
        bool IsGroupAlive { get; }
    }
}
