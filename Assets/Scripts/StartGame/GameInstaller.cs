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

    // Ой вся прога в одном контейнере
    // Так что все прокидываем в конструкторе 
    // Если монобех то в нем первый метод должен быть Construct
    // P.S.
    // И так сойдет 
    public override void InstallBindings()
    {
        InstallPlayer();

        Container.Bind<IGunFactory>().To<GunFactory>().AsSingle();
        Container.BindInterfacesTo<GunSpawner>().AsSingle();


        //GameObject gun = Container.InstantiatePrefab(_settings.Gun,
        //    new Vector3(5f, 0f, 5f), 
        //    Quaternion.identity, null);
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
