using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float Speed = 15f;
    public float lifeTime = 3;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = 1f;

        transform.Translate(transform.right * dirX * Speed * Time.deltaTime);
    }
}
