using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BarrelHero;
    [Range (10,30)]
    public float BulletVelocity = 1f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(Bullet, transform.position, transform.rotation);
            Vector2 ShootVector = BarrelHero.transform.position - newBullet.transform.position;
            newBullet.GetComponent<Rigidbody2D>().velocity = ShootVector * BulletVelocity;
        }
    }
}
