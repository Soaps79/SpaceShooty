using System;
using System.Collections;
using System.Collections.Generic;
using QGame;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : QScript
{
    private Rigidbody2D _rigidBody;

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    protected override void OnUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidBody.AddForce(new Vector2(0,1) * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidBody.AddForce(new Vector2(-1, 0) * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidBody.AddForce(new Vector2(0, -1) * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidBody.AddForce(new Vector2(1, 0) * Speed);
        }
    }


}
