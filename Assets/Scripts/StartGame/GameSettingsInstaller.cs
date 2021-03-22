using System;
using System.Collections;
using System.Collections.Generic;
using Isaac.Player;
using UnityEngine;
using Zenject;


namespace Isaac.StartGame
{
    // Опа а что это тут нас
    //[CreateAssetMenu(menuName = "Isaac/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public PlayerSettings Player;
        public GameInstaller.Settings GameInstaller;
        
        [Serializable]
        public class PlayerSettings
        {
            public PlayerInputHandler.Settings PlayerInputHandler;
        }
        public override void InstallBindings()
        {
            Container.BindInstance(GameInstaller).IfNotBound();
            
            Container.BindInstance(Player.PlayerInputHandler).IfNotBound();
        }
    }
}