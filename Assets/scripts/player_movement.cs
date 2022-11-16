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

        if (Input.GetButtonDown("Jump"))
        {
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, groundCheckLength);
        if (hit.collider != null)
        {
            Debug.Log("hit object = " + hit.collider.gameObject.name);
        }
        else
        {
            Debug.Log("hit nothing");
        }

        Debug.DrawRay(transform.position, -transform.up * groundCheckLength, Color.red);
    }
}
