using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class ExperienceBar : MonoBehaviour
    {
        private Slider experienceBar;
    
        private void Awake()
        {
            experienceBar = GetComponent<Slider>();
        }
    
        public void UpdateBar(int currentExperience, int experienceToNextLevel)
        {
            experienceBar.value = currentExperience;
            experienceBar.maxValue = experienceToNextLevel;
        }
    }
}
