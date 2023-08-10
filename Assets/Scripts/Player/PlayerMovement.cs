using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed;
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private Rigidbody2D rBody;
        [SerializeField] private CapsuleCollider2D collider;

        [Header("Related Objects")]
        [SerializeField] private List<Transform> spawnPoints;
    
        [HideInInspector]
        public Vector2 movementDirection = Vector2.zero;
    
        private void Start()
        {
            // TODO Assign players to spawn points - online feature
            transform.position = spawnPoints[0].position;
        }

        private void FixedUpdate()
        {
            rBody.velocity = new Vector2(joystick.Horizontal * movementSpeed, joystick.Vertical * movementSpeed);
            if (rBody.velocity.x != 0 || rBody.velocity.y != 0)
            {
                movementDirection = rBody.velocity.normalized;
            }
        }
    
        // Will be used for area happenings (earthquake etc.)
        private Vector2 GetPlayersTilePosition()
        {
            var playersPosition = transform.position;
            var playersTilePosition = new Vector2(Mathf.RoundToInt(playersPosition.x), Mathf.RoundToInt(playersPosition.y));
            Debug.Log(playersTilePosition);
            return playersTilePosition;
        }
    }
}
