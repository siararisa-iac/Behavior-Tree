using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    [SerializeField]
    private Image hungerFill;
    [SerializeField]
    private Text hungerText;

    private void OnEnable()
    {
        PlayerHunger.OnHungerUpdate += UpdateHunger;
    }
   
    private void UpdateHunger(float current, float max)
    {
        hungerFill.fillAmount = current / max;
        hungerText.text = $"{current:0}/{max}";
    }
}
