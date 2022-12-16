using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_damage : MonoBehaviour
{
    public Rigidbody2D rd2D;
    public int damage;
    public player_health playerhealth;
    public player_movement player_Movement;

    public Animator animator;
    public float timer = 0.5f;
    public bool isHit;
    public GameObject mushroom;
    public bool death = false;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_Movement.KBCounter = player_Movement.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                player_Movement.KnockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                player_Movement.KnockFromRight = false;
            }
            playerhealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            rd2D.constraints = RigidbodyConstraints2D.FreezeAll;
            isHit = true;
            animator.SetBool("takeDamage", true);
            
        }
    }
    private void Update()
    {
        if (isHit)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                death = true;
            }
            if (death == true)
            {
                animator.SetBool("takeDamage", true);
                Destroy(gameObject);
                score1.scoreValue += 10;
            }
        }
    }
}