using Collectibles;
using Player;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private PlayerStats playerData;
    private CircleCollider2D circleCollider;
    [SerializeField] private float pullForce;
    
    private PlayerLevel playerLevel;
    private PlayerCombat playerCombat;
    
    private void Start()
    {
        playerData = GetComponentInParent<PlayerStats>();
        circleCollider = GetComponent<CircleCollider2D>();
        playerLevel = GetComponentInParent<PlayerLevel>();
        playerCombat = GetComponentInParent<PlayerCombat>();
        AdjustMagnetRange();
    }

    private void AdjustMagnetRange()
    {
        circleCollider.radius = playerData.CurrentMagnet;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Experience"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Vector2 forceDirection = (transform.position - other.transform.position).normalized;
            rb.AddForce(forceDirection * pullForce);
        }
        /*
        else if (other.CompareTag("Health Drop"))
        {
            var healthDrop = other.GetComponent<HealthDrop>();
            playerCombat.Heal();
            healthDrop.Collect();
        }
        */
    }
}
