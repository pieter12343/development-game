using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public Transform[] patrol_points;
    public float moveSpeed;
    public int patrolDestination;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    private void Update()
    {
        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }


            if (patrolDestination == 0 || patrolDestination == 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrol_points[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrol_points[0].position) < 0.2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1 || patrolDestination == 4)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrol_points[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrol_points[1].position) < 0.2f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 0;
                }
            }
            
        }
    }
}
