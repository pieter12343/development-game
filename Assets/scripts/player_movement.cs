using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce;
    public float groundCheckLength;

    private Rigidbody2D rb2D;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");

        transform.Translate(transform.right * dir * speed * Time.deltaTime);

        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, groundCheckLength);

        if (hit.collider != null)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        if (dir > 0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (dir < 0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        Debug.DrawRay(transform.position, -transform.up * groundCheckLength, Color.red);
    }
}