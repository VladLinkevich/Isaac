using System;
using System.ComponentModel;
using Isaac.Gun;
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
        
        GameObject gun = Instantiate(_settings.Gun,
            new Vector3(5f, 0f, 5f), 
            Quaternion.identity);

        Container.Bind<IGun>().To<DefaultGun>().FromComponentOn(gun).AsSingle();
        Container.Bind<DetectPlayer>().FromComponentOn(gun).AsSingle();

    }

    private void InstallPlayer()
    {
        GameObject player = Instantiate(_settings.Player,
            _settings.PlayerStartPosition.position, 
            _settings.PlayerStartPosition.rotation);

        Container.Bind<PlayerView>().AsSingle()
            .WithArguments(player.GetComponent<CharacterController>());
        
        Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
        
        Container.Bind<PlayerShootHandler>().AsSingle();
        Container.Bind<PlayerFacade>().FromComponentOn(player).AsSingle();
    }
    
    [Serializable]
    public class Settings
    {
        public GameObject Player;
        public Transform PlayerStartPosition;
        public GameObject Gun;
    }
}
