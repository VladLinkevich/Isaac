using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace Isaac.StartGame
{
    // Опа а что это тут нас
    //[CreateAssetMenu(menuName = "Isaac/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameInstaller.Settings GameInstaller;
        public override void InstallBindings()
        {
            Container.BindInstance(GameInstaller).IfNotBound();
        }
    }
}