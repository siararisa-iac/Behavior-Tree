using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class PlayerHunger : MonoBehaviour
{
    [SerializeField]
    private float maxHunger = 100;
    private float hunger;

    //Declaration of the delegate signature
    public delegate void HungerDelegate(float current, float max);
    //Create a delegate of the type given above
    public static HungerDelegate OnHungerUpdate;

    public float Hunger
    {
        // Make sure to limit the value of hunger to 0 - maxHunger
        get { return Mathf.Clamp(hunger, 0, maxHunger); }
    }

    // This is a shortcut to
    //public float MaxHunger { get { return maxHunger; } }
    public float MaxHunger => maxHunger;

    [SerializeField]
    private float hungerDecreaseRate = 5.0f;

    [SerializeField]
    private void Start()
    {
        hunger = maxHunger;
    }

    private void Update()
    {
        hunger -= Time.deltaTime * hungerDecreaseRate;
        // Call all the functions subscribed to the delegate
        OnHungerUpdate?.Invoke(Hunger, maxHunger);
        // This is the same as
        //if(OnHungerUpdate != null)
        //{
        //    OnHungerUpdate(Hunger, MaxHunger);
        //}
    }

    public void IncreaseHunger(float value)
    {
        hunger += value;
    }

    public bool IsHungry()
    {
        return (Hunger <= (maxHunger / 2));
    }

    [Task]
    public void CheckHunger()
    {
        if (IsHungry())
        {
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }
    }

    [Task]
    private void Eat()
    {
        IncreaseHunger(20);
        Task.current.Succeed();
    }
}
