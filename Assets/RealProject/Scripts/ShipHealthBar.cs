using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private Gradient gradient;
    private Image fill;

    private GameObject fillObject;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "Fill")
            {
                fillObject = transform.GetChild(i).gameObject;
                fill = fillObject.GetComponent<Image>();
            }
        }
    }
    public void SetShipMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetShipHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
