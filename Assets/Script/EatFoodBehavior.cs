using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFoodBehavior : MonoBehaviour
{
    //References to the attached monobehaviours
    private PlayerHunger hunger;
    private Awareness awareness;
    private Inventory inventory;

    private Sequence rootNode;
    private ActionNode actionCheckHunger;
    private Selector selectorInventory;
    private ActionNode actionCheckMeat, actionCheckVegetable, actionCheckFruit;
    private Inverter inverterEnemies;
    private ActionNode actionCheckEnemies;
    private ActionNode actionEatFood;

    private void Awake()
    {
        //Get components
        hunger = GetComponent<PlayerHunger>();
        awareness = GetComponent<Awareness>();
        inventory = GetComponent<Inventory>();
        InitializeTree();
    }

    private void Update()
    {
        rootNode.Evaluate();
    }

    private void InitializeTree()
    {
        //Initializing the leaf nodes
        actionCheckHunger = new ActionNode(CheckHunger);
        actionCheckMeat = new ActionNode(CheckForMeat);
        actionCheckVegetable = new ActionNode(CheckForVegetable);
        actionCheckFruit = new ActionNode(CheckForFruit);
        actionCheckEnemies = new ActionNode(CheckEnemies);
        actionEatFood = new ActionNode(Eat);

        //Attach the 3 action nodes to the selector
        //Create a List of Nodes for the initialization of the selector
        List<Node> selectorChildren = new();
        selectorChildren.Add(actionCheckMeat);
        selectorChildren.Add(actionCheckVegetable);
        selectorChildren.Add(actionCheckFruit);
        //Initialize the selector
        selectorInventory = new Selector(selectorChildren);

        //Initialie the inverter
        inverterEnemies = new Inverter(actionCheckEnemies);

        //ATTACH all the nodes to the root node
        List<Node> wholeSequence = new();
        wholeSequence.Add(actionCheckHunger);
        wholeSequence.Add(selectorInventory);
        wholeSequence.Add(inverterEnemies);
        wholeSequence.Add(actionEatFood);
        rootNode = new Sequence(wholeSequence);
    }

    private NodeState CheckHunger()
    {
        /*
        if (hunger.IsHungry())
        {
            return NodeState.Success;
        }
        else
        {
            return NodeState.Failure;
        }*/
        return (hunger.IsHungry() ? NodeState.Success : NodeState.Failure); 
    }

    private NodeState CheckForMeat() { return CheckInventory("Meat"); }
    private NodeState CheckForVegetable() { return CheckInventory("Vegetable"); }
    private NodeState CheckForFruit() { return CheckInventory("Fruit"); }

    private NodeState CheckInventory(string itemName)
    {
        return (inventory.ContainsItem(itemName) ? NodeState.Success : NodeState.Failure);
    }

    private NodeState CheckEnemies() { return awareness.IsEnemyAround() ? NodeState.Success : NodeState.Failure; }
    private NodeState Eat()
    {
        //PLay like an animation or a sound effect
        hunger.IncreaseHunger(20);
        return NodeState.Success;
    }
}
