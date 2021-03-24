using DG.Tweening;
using Isaac.Bullet;
using Isaac.Player;
using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class BasicGun : MonoBehaviour, IGun
    {
        [SerializeField] private Vector3 localPositionOnPlayer;

        [SerializeField] private float maxShootDelay;
        [SerializeField] private float lifeTime;
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        
        private PlayerShootHandler _playerShoot;
        private IPool _bulletPool;

        private float _lastShootTime;
        
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

        public IPool BulletPool
        {
            get => _bulletPool;
            private set => _bulletPool = value;
        }
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _playerShoot.SetGun(this);
                transform.SetParent(other.gameObject.transform);
                
                gameObject.transform.localPosition = localPositionOnPlayer;
                transform.rotation = new Quaternion(0,0,0,0);
                
                // лучше пока отключить, ибо хз на что он может наткнуться во время игры
                GetComponent<BoxCollider>().enabled = false;
            }
        }

        public virtual void Shoot(Transform at)
        {
            if (Time.realtimeSinceStartup - _lastShootTime > MaxShootDelay) 
            {
                _lastShootTime = Time.realtimeSinceStartup;
                Fire(at);
            }
        }

        public virtual void Fire(Transform at)
        {
            GameObject bullet = _bulletPool.GetObject();

            bullet.transform.position = at.position;
            
            bullet.transform
                .DOMoveX(10f, LifeTime)
                .OnComplete(() => _bulletPool.Destroy(bullet));
        }

        public void Throw()
        {
            Destroy(this.gameObject);
        }
    }
}