using UnityEngine;

namespace TB_Battle.Data
{
    
    [CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/Attack")]
    public class AttackData : ScriptableObject
    {
        public string attackName;
        public bool areaAttack = true;
        public int damage;
        public int energy;
        public int mana;
    }
}
