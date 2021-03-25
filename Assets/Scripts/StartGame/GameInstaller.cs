using System;
using Isaac.Bullet;
using Isaac.Enemy;
using Isaac.Enemy.State;
using Isaac.Gun;
using Isaac.Player;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;
using EnemyFacade = Isaac.Enemy.EnemyFacade;
using EnemySpawner = Isaac.Enemy.EnemySpawner;
using EnemyView = Isaac.Enemy.EnemyView;
using PlayerFacade = Isaac.Player.PlayerFacade;
using PlayerInputHandler = Isaac.Player.PlayerInputHandler;
using PlayerShootHandler = Isaac.Player.PlayerShootHandler;

namespace Isaac.StartGame
{
    public class GameInstaller : MonoInstaller
    {
        [Inject] Settings _settings = null;

        // Ой вся прога в одном контейнере P.S. И так сойдет 
        // Так что все прокидываем в конструкторе 
        // Если монобех то в нем первый метод должен быть Construct
        public override void InstallBindings()
        {
            InstallPlayer();
            InstallGunFactory();
            InstallBulletFactory();
            InstallEnemy();
        }

        private void InstallEnemy()
        {
            Container.BindFactory<EnemyFacade, EnemyFacade.Factory>()
                .FromPoolableMemoryPool<EnemyFacade, EnemyFacadePool>(poolBinder => poolBinder
                    .WithInitialSize(5)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<EnemyInstaller>(_settings.EnemyPrefab)
                    .UnderTransformGroup("Enemies"));

            Container.BindInterfacesTo<EnemySpawner>().AsSingle();

        }

        private void InstallPlayer()
        {
            GameObject player = Instantiate(_settings.Player,
                _settings.PlayerStartPosition.position,
                _settings.PlayerStartPosition.rotation);

            Container.Bind<PlayerView>().AsSingle()
                .WithArguments(player.GetComponent<CharacterController>());

            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerRotationHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerHealthObserver>().AsSingle();

            Container.Bind<PlayerShootHandler>().AsSingle();
            Container.Bind<PlayerFacade>().FromComponentOn(player).AsSingle();
        }

        private void InstallGunFactory()
        {
            Container.Bind<IGunFactory>().To<GunFactory>().AsSingle();
            Container.BindInterfacesTo<GunSpawner>().AsSingle();
        }

        private void InstallBulletFactory()
        {
            Container.Bind<IBulletFactory>().To<BulletFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BulletPool>().AsSingle();
        }
        
        [Serializable]
        public class Settings
        {
            public GameObject Player;
            public Transform PlayerStartPosition;
            public GameObject EnemyPrefab;
        }

        class EnemyFacadePool : MonoPoolableMemoryPool<IMemoryPool, EnemyFacade>
        {
        }
    }
}
