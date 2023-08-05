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
    [SerializeField] private List<Transform> spawnPoints;
    
    private void Start()
    {
        // TODO Assign players to spawn points
        transform.position = spawnPoints[0].position;
    }

    private void FixedUpdate()
    {
        rBody.velocity = new Vector2(joystick.Horizontal * movementSpeed, joystick.Vertical * movementSpeed);
    }
}
