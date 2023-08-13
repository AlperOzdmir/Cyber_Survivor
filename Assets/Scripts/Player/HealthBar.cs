using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Transform healthBar;
    
        public void UpdateBar(float currentValue, float maxValue)
        {
            var percentage = currentValue / maxValue;
            healthBar.localScale = new Vector3(percentage, 1, 1);
        }
    }
}
