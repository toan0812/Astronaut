using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platForm : MonoBehaviour
{
    public float Enemies_speed;
    public int StartingPoint;
    public Transform[] Points;
    public int i = 0;

    void Start()
    {
        transform.position = Points[StartingPoint].position;
    }


    void Update()
    {
        checkDis();
      
    }

    public virtual void checkDis()
    {
        if (Vector2.Distance(transform.position, Points[i].position) < 0.02f)
        {
            i++;
            if (i == Points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Points[i].position, Enemies_speed * Time.deltaTime);
    }
   





}
