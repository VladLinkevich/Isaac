using System;
using Isaac.Player;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject] Settings _settings = null;

    public override void InstallBindings()
    {   
        // Ой вся прога в одном контейнере
        // Так что все прокидываем в конструкторе 
        // Если монобех то в нем первый метод должен быть Construct
        // P.S.
        // И так сойдет 
        InstallPlayer();
    }

    private void InstallPlayer()
    {
        GameObject player = Instantiate(_settings.Player,
            _settings.PlayerStartPosition.position, 
            _settings.PlayerStartPosition.rotation);

        Container.Bind<PlayerView>().AsSingle()
            .WithArguments(player.GetComponent<CharacterController>());
        
        Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
        Container.Bind<PlayerFacade>().FromComponentOn(player).AsSingle();
    }
    
    [Serializable]
    public class Settings
    {
        public GameObject Player;
        public Transform PlayerStartPosition;
    }
}
