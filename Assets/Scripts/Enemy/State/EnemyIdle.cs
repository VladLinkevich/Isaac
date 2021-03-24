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
            Debug.Log("Enter");

            //throw new System.NotImplementedException();
        }

        public void ExitState()
        {
            Debug.Log("Exit");

            //throw new System.NotImplementedException();
        }

        public void Update()
        {
            Debug.Log("Update");
            //throw new System.NotImplementedException();
        }
    }
}