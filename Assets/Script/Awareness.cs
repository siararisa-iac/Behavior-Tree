using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awareness : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private float detectRange = 3.0f;

    public bool IsEnemyAround()
    {
        //Check each enemies if they are near detectRange
        for(int i = 0; i < enemies.Count; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < detectRange)
            {
                Debug.Log("Near an enemy");
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        IsEnemyAround();
    }
}
