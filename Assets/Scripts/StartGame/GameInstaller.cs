using System;
using Isaac.Gun;
using Isaac.Player;
using UnityEngine;
using Zenject;
using PlayerFacade = Isaac.Player.PlayerFacade;
using PlayerInputHandler = Isaac.Player.PlayerInputHandler;
using PlayerShootHandler = Isaac.Player.PlayerShootHandler;

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

    private void InstallGunFactory()
    {
        Container.Bind<IGunFactory>().To<GunFactory>().AsSingle();
        Container.BindInterfacesTo<GunSpawner>().AsSingle();
    }
    
    [Serializable]
    public class Settings
    {
        public GameObject Player;
        public Transform PlayerStartPosition;
    }
}
