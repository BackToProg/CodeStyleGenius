using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _template;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Transform _target;

    private void Start()
    {
       var shoot = StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = true;
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timeWaitShooting);

        while (isWork)
        {
            Vector3 bulletDirection = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_template, transform.position + bulletDirection, Quaternion.identity);
            Rigidbody newBulletRb = newBullet.GetComponent<Rigidbody>(); 
            
            newBulletRb.transform.up = bulletDirection;
            newBulletRb.velocity = bulletDirection * _speed;

            yield return waitForSeconds;
        }
    }
}