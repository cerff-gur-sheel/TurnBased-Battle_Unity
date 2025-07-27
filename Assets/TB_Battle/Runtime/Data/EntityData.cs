using UnityEngine;

namespace TB_Battle.Runtime.Data
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/EntityData")]
    public class EntityData : ScriptableObject
    {
        public string entityName;
        public int life;
    }
}
