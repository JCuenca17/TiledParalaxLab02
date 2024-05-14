using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip Sound;
    public float Speed;
    private Rigidbody2D Rb;
    private Vector2 Direction;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    void FixedUpdate()
    {
        Rb.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerController player = collision.GetComponent<PlayerController>();
        EnemyController enemy = collision.GetComponent<EnemyController>();
        if (player != null)
        {
            player.Hit();
        }
        if (enemy != null)
        {
            enemy.Hit();
        }
        DestroyBullet();

    }
}
