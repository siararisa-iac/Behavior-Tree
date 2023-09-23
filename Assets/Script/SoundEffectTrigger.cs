using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectTrigger : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerHunger.OnHungerUpdate += CheckHunger;
    }
    private void CheckHunger(float current, float max)
    {
        if(current < (max / 2))
        {
            Debug.Log("Play sound effect");
        }
    }

}
