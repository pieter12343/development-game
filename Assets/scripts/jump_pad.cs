using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_pad : MonoBehaviour
{
    public float bounce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce);
        }
    }
}
