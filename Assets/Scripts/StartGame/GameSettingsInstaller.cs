using System;
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
        public GameInstaller.Settings GameInstaller;
        
        [Serializable]
        public class PlayerSettings
        {
            public PlayerInputHandler.Settings PlayerInputHandler;
        }
        
        [Serializable]
        public class GunsSettings
        {
            public GunFactory.Settings GunFactory;
        }
        public override void InstallBindings()
        {
            Container.BindInstance(GameInstaller).IfNotBound();
            
            Container.BindInstance(Guns.GunFactory).IfNotBound();
            
            Container.BindInstance(Player.PlayerInputHandler).IfNotBound();
        }
    }
}