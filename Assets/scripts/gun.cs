using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float Bulletspeed = 10;
    public GameObject bullet;

    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");

        transform.Translate(transform.right * dirX * Bulletspeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

}
