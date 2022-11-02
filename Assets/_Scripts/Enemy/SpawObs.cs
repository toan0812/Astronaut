using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawObs : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float timeToSpawn;
    private PoolObject pool;
    [SerializeField] Transform ShootPoint;
    public bool ObsSpawn = false;
    void Start()
    {

        pool = GetComponent<PoolObject>();
    }

    // Update is called once per frame
    void Update()
    {

            timer += Time.deltaTime;
            if (timer < timeToSpawn) return;
            GameObject Obs = pool.GetPoolObject();
            if (Obs != null)
            {
                Obs.transform.position = ShootPoint.position;
                Obs.SetActive(true);
            }
            timer = 0f;
    }
}
