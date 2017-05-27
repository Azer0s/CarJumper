using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantVelocity : MonoBehaviour
{
    public Vector2 Velocity = Vector2.zero;
    private Rigidbody2D _body2D;

    public void Awake()
    {
        _body2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        _body2D.velocity = Velocity;
    }
}
