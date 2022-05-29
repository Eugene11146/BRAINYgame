using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int Speed = 2;
    [SerializeField] private Rigidbody2D rbEnemy;
    private int _turn = 0;
    private float _currentTime;
    public GameObject PauseMenu;
    public GameObject Target;

    private void UpMove()
    {
        rbEnemy.velocity = Vector2.up * Speed;
    }
    private void DownMove()
    {
        rbEnemy.velocity = Vector2.down* Speed;
    }

    private void LeftMove()
    {
        rbEnemy.velocity = Vector2.left * Speed;
    }
    private void RightMove()
    {
        rbEnemy.velocity = Vector2.right * Speed;
    }
    
    private void Movemnts()
    {
        if(_turn == 0)
        {
            UpMove();
        }
        if (_turn == 1)
        {
            DownMove();
        }
        if (_turn == 2)
        {
            LeftMove();
        }
        if (_turn == 3)
        {
            RightMove();
        }
    }

    private void Chosing()
    {
        _turn = Random.Range(0, 4);
        _currentTime = 1.2f;
    }

    private void TimeToChose()
    {
        _currentTime = (_currentTime) - Time.deltaTime;

        if (_currentTime <= 0)
        {
            Chosing();
        }
    }

    private void Update()
    {
        Movemnts();
        TimeToChose();
        Rotation();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Up")
        {
            _turn = 1;
            _currentTime = 1f;
            Debug.Log(_turn);
        }
        else if (collider.gameObject.tag == "Down")
        {
            _turn = 0;
            _currentTime = 1f;
            Debug.Log(_turn);

        }
        else if (collider.gameObject.tag == "Right")
        {
            _turn = 2;
            _currentTime = 1f;
            Debug.Log(_turn);

        }
        else if (collider.gameObject.tag == "Left")
        {
            _turn = 3;
            _currentTime = 1f;
            Debug.Log(_turn);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Time.timeScale = 0;
            UIScore.HeroScore++;
            PauseMenu.SetActive(true);
        }else
        {
            Chosing();
        }
    }

    private void Rotation()
    {
        Vector2 direction = Target.gameObject.transform.position - transform.position;
        var Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Angle);
    }
}
