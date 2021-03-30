using System;
using Isaac.Player;
using UnityEngine;

namespace Isaac.Enemy.State
{
    //[CreateAssetMenu(fileName = "EnemyAttackState", menuName = "EnemyAttack")]
    public class EnemyAttack : IEnemyState
    {
        private readonly EnemyView _enemy;
        private readonly EnemyStateHandler _enemyStateHandler;
        private readonly Settings _settings;
        private PlayerFacade _player;

        public EnemyAttack(
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
            _enemy.transform.LookAt(_player.transform.position);
            RaycastHit hitInfo;
            if (!Physics.Raycast(_enemy.transform.position, _enemy.transform.TransformDirection(Vector3.forward), out hitInfo, 10)
                || hitInfo.collider.gameObject.name != _player.name)
            {
                _enemyStateHandler.ChangeState(EnemyState.Idle);
            }
        }
        
        [Serializable]
        public class Settings
        {
            public float Speed;
        }
    }
}