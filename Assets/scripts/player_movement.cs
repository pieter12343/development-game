using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce;
    public float groundCheckLength;

    private Rigidbody2D rb2D;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    bool facingRight;

    public float Bulletspeed = 10;
    public GameObject bullet;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");

        transform.Translate(transform.right * dirX * Bulletspeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }

        float dir = Input.GetAxis("Horizontal");
        if (KBCounter <= 0)
        {
            transform.Translate(transform.right * dir * speed * Time.deltaTime);
        }
        else
        {
            if (KnockFromRight == true)
            {
                rb2D.velocity = new Vector2(KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rb2D.velocity = new Vector2(-KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }

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
            transform.localScale = new Vector2(0.2f, 0.2f);
            facingRight = true;
        }
        else if (dir < 0f)
        {
            transform.localScale = new Vector2(-0.2f, 0.2f);
            facingRight = false;
        }
        Debug.DrawRay(transform.position, -transform.up * groundCheckLength, Color.red);
    }
    private void Flip()
    {
        if (facingRight != true)
        {
            transform.Rotate(0f, 180f, 0f);
        }
        else
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }
}