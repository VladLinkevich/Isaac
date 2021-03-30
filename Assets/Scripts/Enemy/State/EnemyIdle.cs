using System;
using Isaac.Player;
using UnityEngine;
using Zenject;

namespace Isaac.Enemy.State
{
    public class EnemyIdle : IEnemyState
    {
        private readonly EnemyView _enemy;
        private readonly EnemyStateHandler _enemyStateHandler;
        private readonly Settings _settings;
        private PlayerFacade _player;

        public EnemyIdle(
            EnemyView enemy,
            EnemyStateHandler enemyStateHandler,
            Settings settings)
        {
            _enemy = enemy;
            _enemyStateHandler = enemyStateHandler;
            _settings = settings;
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
        
        [Serializable]
        public class Settings
        {
            public float Speed;
        }

    }
}