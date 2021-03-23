using DG.Tweening;
using Isaac.Bullet;
using Isaac.Player;
using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    public abstract class BasicGun : MonoBehaviour, IGun
    {
        [SerializeField] private Vector3 localPositionOnPlayer;

        [SerializeField] private float maxShootDelay;
        [SerializeField] private float lifeTime;
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        
        private PlayerShootHandler _playerShoot;
        private IPool _bulletPool;
        
        [Inject]
        private void Construct(PlayerShootHandler playerShootHandler,
            IPool bulletPool)
        {
            _playerShoot = playerShootHandler;
            _bulletPool = bulletPool;
        }
        
        #region Getter/Setter
        public float MaxShootDelay
        {
            get => maxShootDelay;
            private set => maxShootDelay = value;
        }
        public float LifeTime
        {
            get => lifeTime;
            private set => lifeTime = value;
        }
        public float Speed
        {
            get => speed;
            private set => speed = value;
        }
        public float Damage
        {
            get => damage;
            private set => damage = value;
        }
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("touch");
            if (other.gameObject.CompareTag("Player"))
            {
                _playerShoot.SetGun(this);
                transform.SetParent(other.gameObject.transform);
                transform.localPosition = localPositionOnPlayer;
            }
        }

        public virtual void Shoot(Transform at)
        {
            Debug.Log($"fex");
            GameObject bullet = _bulletPool.GetObject();

            bullet.transform.position = at.position;
            
            bullet.transform
                .DOMoveX(10f, LifeTime)
                .OnComplete(() => _bulletPool.Destroy(bullet));
        }

        public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}