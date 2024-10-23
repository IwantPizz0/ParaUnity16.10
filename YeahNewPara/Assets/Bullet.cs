using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlayerController _)) 
            Destroy(gameObject);
    }
}
