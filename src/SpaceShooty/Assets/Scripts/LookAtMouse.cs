using System;
using System.Collections;
using System.Collections.Generic;
using QGame;
using UnityEngine;

public class LookAtMouse : QScript
{
    private Camera _mainCamera;
    public float MaxRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    protected override void OnUpdate()
    {
        var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, MaxRotationSpeed);
    }
}
