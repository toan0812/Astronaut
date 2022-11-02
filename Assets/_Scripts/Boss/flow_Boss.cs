using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flow_Boss : MonoBehaviour
{
    [SerializeField] private GameObject Boss;

    private void Update()
    {
        transform.position =  new Vector3(Boss.transform.position.x, transform.position.y, transform.position.z);
    }
}
