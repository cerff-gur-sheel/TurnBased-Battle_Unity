using System.Collections.Generic;
using UnityEngine;

namespace TB_Battle.Data
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/EntityData")]
    public class EntityData : ScriptableObject
    {
        public string entityName;
        public int life;
        public List<AttackData> attacks;
    }
}
