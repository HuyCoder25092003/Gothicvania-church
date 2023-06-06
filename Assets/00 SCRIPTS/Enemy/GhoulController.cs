using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rigi;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Moving();
    }
    void Moving()
    {
        rigi.velocity = transform.right * speed;
    }
    void Flip()
    {
        Quaternion rotation = transform.rotation;
        if (rotation.y == 0)
            rotation.y = 180;
        else rotation.y = 0;
        transform.rotation = rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
            Flip();
    }
}
