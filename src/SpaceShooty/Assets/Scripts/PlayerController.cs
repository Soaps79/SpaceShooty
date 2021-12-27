using System;
using System.Collections;
using System.Collections.Generic;
using QGame;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : QScript
{
    private Rigidbody2D _rigidBody;

    public GameObject BulletPrefab;
    public float BulletSpeed;

    public float Speed;
    public float FireDelay;
    [SerializeField]
    private float _elapsedSinceFire;
    private bool _isInFireDelay;

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

        if (_isInFireDelay)
        {
            _elapsedSinceFire += Time.deltaTime;
            if (_elapsedSinceFire > FireDelay)
                _isInFireDelay = false;
        }

        if (Input.GetMouseButton(1) && !_isInFireDelay)
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        var bullet = GameObject.Instantiate(BulletPrefab, transform.position, transform.rotation);
        var rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.up * BulletSpeed);
        _isInFireDelay = true;
        _elapsedSinceFire = 0.0f;
    }


}
