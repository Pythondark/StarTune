using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public void SetHealthBar(float currentValue, float maxValue)
    {
        GetComponent<Slider>().value = Mathf.Clamp(currentValue / maxValue, 0, 1);
    }
}
