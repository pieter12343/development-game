using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 10;
    private float jump = 0f;
    private float jump_rate = 30f;
    
    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * dir * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Y))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }

}
