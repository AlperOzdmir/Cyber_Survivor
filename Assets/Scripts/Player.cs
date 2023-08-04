using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Rigidbody2D rBody;

    [Header("Related Objects")]
    [SerializeField] private GridManager gridManager;
    
    private void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        transform.position = gridManager.GetCenterPosition();
    }

    private void FixedUpdate()
    {
        rBody.velocity = new Vector2(joystick.Horizontal * movementSpeed, joystick.Vertical * movementSpeed);
    }
}
