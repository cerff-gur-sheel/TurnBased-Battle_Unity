using TB_Battle.Data;
using TB_Battle.Model.Party;

namespace TB_Battle.Controller
{
    public abstract class CombatController
    {
        public enum Turn
        {
            Player,
            Enemy
        }

        private Turn _currentTurn;
        
        public IParty Player { get; private set; }
        public IParty Enemy { get; private set; }

        
        public void Initialize(PartyData playerData, PartyData enemyData, Turn initialTurn)
        {
            _currentTurn = initialTurn;
            Player = new PlayerParty(playerData);
            Enemy = new EnemyParty(enemyData);
            CombatLoop();
        }

        private void CombatLoop()
        {
            if (!Player.IsGroupAlive || !Enemy.IsGroupAlive) return;
            if (_currentTurn == Turn.Player)
            {
                
            }
        }

        public void ToggleTurn()
        {
            _currentTurn = _currentTurn == Turn.Player ? Turn.Enemy : Turn.Player;
            CombatLoop();
        }
    }
}
