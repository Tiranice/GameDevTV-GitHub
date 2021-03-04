using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurretPrototype.Turret
{
    public class TurretStooting : MonoBehaviour
    {
        #region Inspector Fields

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _firedFrom;
        [SerializeField] private Transform _bulletTemplate;
        [SerializeField] private Transform _bulletParent;
        [Range(0.5f, 10.0f)]
        [SerializeField] private float _shotCooldown = 2.0f;
        [Range(0.1f, 50.0f)]
        [SerializeField] private float _shotPower = 30.0f;

        #endregion

        #region Properties

        public bool ShouldShoot { get; set; } = true;

        #endregion

        #region Unity Messages

        private void Start()
        {
            StartCoroutine(ShootBullet());
        }

        #endregion

        #region Private Methods

        public  IEnumerator ShootBullet()
        {
            while (ShouldShoot)
            {
                var bullet = Instantiate(original: _bulletPrefab,
                                         position: _bulletTemplate.position,
                                         rotation: _bulletTemplate.rotation
                                         );

                bullet.transform.SetParent(_bulletParent);

                if (bullet.TryGetComponent(out Rigidbody rigidbody))
                    rigidbody.velocity = _shotPower * _firedFrom.forward;

                yield return new WaitForSeconds(_shotCooldown);
            }
        }

        #endregion
    }
}