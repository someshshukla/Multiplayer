using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    RectTransform HealthUI;

    void OnEnable()
    {
        GetComponent<NetworkHealthState>().HealthPoint.OnValueChanged += HealthChanged;
    }

    void OnDisable()
    {
        GetComponent<NetworkHealthState>().HealthPoint.OnValueChanged -= HealthChanged;
    }

    private void HealthChanged(int previousValue, int newValue)
    {
        HealthUI.transform.localScale = new Vector3(newValue / 100f, 0.3f, 1);
    }
}
