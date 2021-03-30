using System;
using Isaac.Bullet;
using Isaac.Enemy.State;
using Isaac.Gun;
using Isaac.Player;
using Zenject;


namespace Isaac.StartGame
{
    // Опа а что это тут нас
    //[CreateAssetMenu(menuName = "Isaac/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public PlayerSettings Player;
        public GunsSettings Guns;
        public BulletsSettings Bullets;
        public EnemySettings Enemy;
        public GameInstaller.Settings GameInstaller;
        
        [Serializable]
        public class PlayerSettings
        {
            public PlayerInputHandler.Settings PlayerInputHandler;
            public PlayerView.Settings PlayerView;
        }
        
        [Serializable]
        public class GunsSettings
        {
            public GunFactory.Settings GunFactory;
        }
        
        [Serializable]
        public class BulletsSettings
        {
            public BulletFactory.Settings BulletFactory;
            public BulletPool.Settings BulletPool;
        }
        
        [Serializable]
        public class EnemySettings
        {
            public EnemyIdle.Settings EnemyIdle;
            public EnemyAttack.Settings EnemyAttack;
        }
        public override void InstallBindings()
        {
            Container.BindInstance(GameInstaller).IfNotBound();
            
            Container.BindInstance(Player.PlayerInputHandler).IfNotBound();
            Container.BindInstance(Player.PlayerView).IfNotBound();
            
            Container.BindInstance(Guns.GunFactory).IfNotBound();

            Container.BindInstance(Bullets.BulletFactory).IfNotBound();
            Container.BindInstance(Bullets.BulletPool).IfNotBound();
            
            Container.BindInstance(Enemy.EnemyIdle).IfNotBound();
            Container.BindInstance(Enemy.EnemyAttack).IfNotBound();
        }
    }
}