using Isaac.Enemy;
using Isaac.Enemy.State;
using Zenject;

namespace Isaac.StartGame
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            
            Container.BindInterfacesAndSelfTo<EnemyStateHandler>().AsSingle();

            Container.Bind<EnemyAttack>().AsSingle();
            Container.Bind<EnemyIdle>().AsSingle();
        }
    }
}