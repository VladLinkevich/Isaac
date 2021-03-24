using UnityEngine;
using Zenject;

namespace Isaac.Enemy
{
    public class EnemySpawner : IInitializable
    {
        private readonly EnemyFacade.Factory _enemyFactory;

        public EnemySpawner(EnemyFacade.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }
        
        public void Initialize()
        {
            EnemyFacade facade = _enemyFactory.Create();
            facade.Position = new Vector3(0, 0, 3);
            EnemyFacade facade2 = _enemyFactory.Create();
            facade2.Position = new Vector3(0, 0, -3);
        }
    }
}