using System.Collections.Generic;
using UnityEngine;

namespace TB_Battle.Runtime.Data
{
    [CreateAssetMenu(fileName = "PartyData", menuName = "Scriptable Objects/PartyData")]
    public class PartyData : ScriptableObject
    {
        public string groupName; 
        public List<EntityData> entities;
    }
}
