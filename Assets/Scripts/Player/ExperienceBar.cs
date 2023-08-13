using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

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
