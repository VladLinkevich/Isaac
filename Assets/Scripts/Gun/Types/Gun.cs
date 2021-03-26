using DG.Tweening;
using Isaac.Bullet;
using Isaac.Player;
using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Gun : MonoBehaviour, IGun
    {
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private Vector3 localPositionOnPlayer;

        [SerializeField] private float maxShootDelay;
        [SerializeField] private float range;
        [SerializeField] private float speed;
        [SerializeField] private float damage;

        private PlayerShootHandler _playerShoot;
        private IPool _bulletPool;

        private float _lifeTime;
        private float _lastShootTime;

        [Inject]
        private void Construct(
            PlayerShootHandler playerShootHandler,
            IPool bulletPool)
        {
            _playerShoot = playerShootHandler;
            _bulletPool = bulletPool;

            _lifeTime = range / speed;
        }

        #region Getter/Setter

        public float MaxShootDelay
        {
            get => maxShootDelay;
            private set => maxShootDelay = value;
        }

        public float Range
        {
            get => range;
            private set => range = value;
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
                transform.rotation = new Quaternion(0, 0, 0, 0);

                // лучше пока отключить, ибо хз на что он может наткнуться во время игры
                boxCollider.enabled = false;
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
            Bullet.Bullet bullet = _bulletPool.GetObject();
            
            bullet.StartShooting(bulletSpawnPoint.position, at.rotation);

            //Vector3 endPoint = FindEndPoint(bulletSpawnPoint.position,
            //    at.rotation);

            // bullet.transform
            //     .DOMove(endPoint, _lifeTime)
            //     .OnComplete(() => _bulletPool.Destroy(bullet));
        }

        public void Throw()
        {
            Destroy(this.gameObject);
        }

        // Считает конечную точку пули  (О—, о—)
        //                                nice
        // загружаем стартовую точку + угол в который должен лететь патрон
        private Vector3 FindEndPoint(Vector3 position, Quaternion rotation)
        {
            Vector3 endPoint = new Vector3(
                position.x + (Mathf.Cos(Mathf.Deg2Rad * rotation.eulerAngles.y) * range),
                position.y,
                position.z - (Mathf.Sin(Mathf.Deg2Rad * rotation.eulerAngles.y) * range)
            );

            return endPoint;
        }
    }
}