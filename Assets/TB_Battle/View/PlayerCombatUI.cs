using TB_Battle.Controller;
using TB_Battle.Data;
using UnityEngine;

namespace TB_Battle.View
{
    public class PlayerCombatUI : MonoBehaviour
    {
        [SerializeField] private PartyData playerGroup;
        [SerializeField] private PartyData enemyGroup;
        
        private CombatController _controller;

        private void Start()
        {
            _controller.Initialize(
                playerGroup, 
                enemyGroup, 
                CombatController.Turn.Player);
        }

        private void AttackButton(AttackData attack) { }
        
        private void DefendButton() { }
    }
}
