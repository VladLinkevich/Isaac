using UnityEngine;

namespace Isaac.Enemy.State
{
    public class EnemyIdle : IEnemyState
    {
        private readonly EnemyView _enemy;
        private readonly EnemyStateHandler _enemyStateHandler;

        public EnemyIdle(
            EnemyView enemy,
            EnemyStateHandler enemyStateHandler)
        {
            _enemy = enemy;
            _enemyStateHandler = enemyStateHandler;
        }
        public void EnterState()
        {

        }

        public void ExitState()
        {
        }

        public void Update()
        {

        }
    }
}