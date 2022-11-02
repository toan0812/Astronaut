using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private List<GameObject> poolObjects = new List<GameObject>();
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private int amountBullet;
    private void Start()
    {
        for (int i=0; i < amountBullet; i++)
        {
            GameObject obj = Instantiate(BulletPrefab);
            obj.SetActive(false);
            poolObjects.Add(obj);

        }
    }

    public GameObject GetPoolObject()
    {
        for(int i = 0; i<poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }
}
