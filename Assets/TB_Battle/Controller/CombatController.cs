using TB_Battle.Data;
using TB_Battle.Model.Party;
using TB_Battle.State;

namespace TB_Battle.Controller
{
    public static class CombatController
    {
        public enum Turn
        {
            Player,
            Enemy
        }

        private static Turn _currentTurn;

        private static IParty Player { get; set; }
        private static IParty Enemy { get; set; }
        
        internal static void Initialize(PartyData playerData, PartyData enemyData, Turn initialTurn)
        {
            _currentTurn = initialTurn;
            Player = new PlayerParty(playerData);
            Enemy = new EnemyParty(enemyData);
        }

        private static void CombatLoop()
        {
            if (!Player.IsGroupAlive || !Enemy.IsGroupAlive) return;
            if (_currentTurn == Turn.Player)
            {
                
            }
            else
            {
                
            }
        }

        public static void ToggleTurn()
        {
            _currentTurn = _currentTurn == Turn.Player ? Turn.Enemy : Turn.Player;
            CombatLoop();
        }
    }
}
