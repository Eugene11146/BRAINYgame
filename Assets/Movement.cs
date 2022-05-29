using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D HeroRigidBody;
    private Vector2 moveVectorX;
    private Vector2 moveVectorY;
    [Range (1, 10)]
    public float speed = 1f;
    public GameObject PauseMenu;
    
    void Update()
    {
        Walk();
        Rotation();
    }
    private void Walk()
    {
        moveVectorX.x = Input.GetAxis("Vertical");
        HeroRigidBody.velocity = new Vector2(moveVectorX.x * speed, HeroRigidBody.velocity.y);
        
        moveVectorY.y = Input.GetAxis("Horizontal");
        HeroRigidBody.velocity = new Vector2(moveVectorY.y * speed, HeroRigidBody.velocity.x);
    }

    private void Rotation()
    {
        if(Input.GetMouseButton(0))
        {
            HeroRigidBody.rotation = HeroRigidBody.rotation + 1;
        }
        if (Input.GetMouseButton(1))
        {
            HeroRigidBody.rotation = HeroRigidBody.rotation - 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Time.timeScale = 0;
            UIScore.EnemyScore++;
            PauseMenu.SetActive(true);
        }
    }
}
