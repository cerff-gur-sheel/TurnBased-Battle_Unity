using TB_Battle.Runtime.Data;
using TB_Battle.Runtime.Model.Party;

namespace TB_Battle.Runtime.Controller
{
    public class CombatController
    {
        public enum Turn
        {
            Player,
            Enemy
        }

        public Turn currentTurn;
        
        private IParty player;
        private IParty enemy;

        private void Initialize(PartyData playerData, PartyData enemyData)
        {
            player = new PlayerParty(playerData);
            enemy = new EnemyParty(enemyData);
        }

        private void CombatLoop()
        {
            if (player.IsGroupAlive && enemy.IsGroupAlive)
            {
                // todo: play combat
            }
        }
        
    }
}