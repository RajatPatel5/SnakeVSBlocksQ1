using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolCoin : MonoBehaviour
{
    public GameObject prefab;
    public int amount;
    public GameObject[] prefabs;
    private int index;

    void Awake()
    {
        prefabs = new GameObject[amount];

        for (int i = 0; i < amount; i++)
        {
            prefabs[i] = Instantiate(prefab, new Vector2(0, 15), Quaternion.identity);
            prefabs[i].SetActive(false);
        }
    }

    public GameObject GetObjectCoin()
    {
        index++;
        if (index >= amount)
        {
            index = 0;
        }
        prefabs[index].SetActive(true);

        return prefabs[index];
    }
}
