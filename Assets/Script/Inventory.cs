using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
public class Inventory : MonoBehaviour
{
    public List<string> items;

    public bool ContainsItem(string id)
    {
        if (items.Contains(id)) Debug.Log("found item " + id);
        return items.Contains(id);
    }

    [Task]
    public void CheckInventory(string item)
    {
        Task.current.Complete(ContainsItem(item));
    }
}
