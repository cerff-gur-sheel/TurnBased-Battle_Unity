using System.Diagnostics.CodeAnalysis;
using TB_Battle.Data;
using TB_Battle.Model.Party;
using TB_Battle.State;

namespace TB_Battle.Controller
{
    public class CombatController
    {
        public enum Turn
        {
            Player,
            Enemy
        }

        private static Turn _currentTurn;

        private static IParty Player { get; set; }
        private static IParty Enemy { get; set; }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")] 
        public static ITurnState CurrentTurnState { get; private set; }
        
        internal static void Initialize(PartyData playerData, PartyData enemyData, Turn initialTurn)
        {
            _currentTurn = initialTurn;
            Player = new PlayerParty(playerData);
            Enemy = new EnemyParty(enemyData);
        }

        internal static void CombatLoop()
        {
            if (!Player.IsGroupAlive || !Enemy.IsGroupAlive) return;

            CurrentTurnState = _currentTurn == Turn.Player
                ? CurrentTurnState = new PlayerTurnState()
                : CurrentTurnState = new EnemyTurnState();

            var source = _currentTurn == Turn.Player ? Player : Enemy; 
            var target = _currentTurn == Turn.Player ? Enemy : Player; 
            CurrentTurnState.Enter(source, target);
        }

        public static void ToggleTurn()
        {
            _currentTurn = _currentTurn == Turn.Player ? Turn.Enemy : Turn.Player;
            CombatLoop();
        }
    }
}
