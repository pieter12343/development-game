using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_damage : MonoBehaviour
{
    public int damage;
    public player_health playerhealth;
    public player_movement player_Movement;


    public int maxHealth = 10;
    public int health;

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
            Destroy(gameObject);
        }
    }
}
