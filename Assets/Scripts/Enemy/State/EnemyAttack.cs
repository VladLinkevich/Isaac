using Isaac.Player;
using UnityEngine;

namespace Isaac.Enemy.State
{
    public class EnemyAttack : IEnemyState
    {
        private readonly EnemyView _enemy;
        private readonly EnemyStateHandler _enemyStateHandler;
        private PlayerFacade _player;

        public EnemyAttack(
            EnemyView enemy,
            EnemyStateHandler enemyStateHandler)
        {
            _enemy = enemy;
            _enemyStateHandler = enemyStateHandler;
        }
        
        public void Initialize()
        {
            // Плохо да очень плохо, НО дедлайн через 4 часа сказал что так можно
            _player = GameObject.Find("Player(Clone)").GetComponent<PlayerFacade>();
        }

        public void EnterState()
        {
            
        }

        public void ExitState()
        {
            
        }

        public void FixedUpdate()
        {
            
        }
    }
}