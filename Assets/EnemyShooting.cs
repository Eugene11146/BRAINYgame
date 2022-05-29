using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BarrelEnemy;
    public float BulletVelocity = 1f;
    public GameObject Hero;
    private float _currentTime= 1;

    private RaycastHit2D _rayHit;


    void Update()
    {
        _currentTime = (_currentTime) - Time.deltaTime;
       
        _rayHit = Physics2D.Raycast(BarrelEnemy.transform.position, Hero.transform.position, 1001, 1);
        
        if ( _rayHit.collider == null)
        {
            Shoot();
        }
        else if (_rayHit.collider.gameObject.tag == "Finish")
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_currentTime <= 0)
        {
            GameObject newBullet = Instantiate(Bullet, transform.position, transform.rotation);

            Vector2 ShootVector = Hero.transform.position - newBullet.transform.position;

            newBullet.GetComponent<Rigidbody2D>().velocity = ShootVector * BulletVelocity;

            _currentTime = 1f;
        }
    }
}
