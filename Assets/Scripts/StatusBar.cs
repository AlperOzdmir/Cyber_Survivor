using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private Transform statusBar;
    
    public void UpdateBar(float currentValue, float maxValue)
    {
        var percentage = currentValue / maxValue;
        statusBar.localScale = new Vector3(percentage, 1, 1);
    }
}
