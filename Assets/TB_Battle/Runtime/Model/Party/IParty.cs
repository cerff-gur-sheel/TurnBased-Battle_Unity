using System.Collections.Generic;
using TB_Battle.Runtime.Model.Entity;

namespace TB_Battle.Runtime.Model.Party
{
    public interface IParty
    {
        string GroupName { get; }
        List<IEntity> Entities { get; }
        bool IsGroupAlive { get; }
    }
}
