using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerData;
        
        private float currentMovementSpeed;
        
        [Header("Movement")]
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private Rigidbody2D rBody;

        [Header("Related Objects")]
        [SerializeField] private List<Transform> spawnPoints;
    
        [HideInInspector]
        public Vector2 movementDirection = Vector2.zero;
    
        private void Start()
        {
            // TODO Assign players to spawn points - online feature
            transform.position = spawnPoints[0].position;
            currentMovementSpeed = playerData.movementSpeed;
        }

        private void FixedUpdate()
        {
            rBody.velocity = new Vector2(joystick.Horizontal * currentMovementSpeed, joystick.Vertical * currentMovementSpeed);
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
        
        // For slow down or speed up effects
        public void SetMovementSpeed(float speed)
        {
            currentMovementSpeed = speed;
        }
    }
}
