using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float Bulletspeed = 10;
    public GameObject bullet;
    public float facingDirX = 1;
    public GameObject barrel;

    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        if (dirX == -1 || dirX == 1)
        {
            facingDirX = dirX;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject spawnedBullet = Instantiate(bullet, barrel.transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<bullet>().dirX = facingDirX;
        }

    }

}
