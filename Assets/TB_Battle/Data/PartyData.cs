using System.Collections.Generic;
using UnityEngine;

namespace TB_Battle.Data
{
    [CreateAssetMenu(fileName = "PartyData", menuName = "Scriptable Objects/Party")]
    public class PartyData : ScriptableObject
    {
        public string groupName; 
        public List<EntityData> entities;
    }
}
