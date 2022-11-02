using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Enemies : Moving_platForm
{

    private Animator animator;
    public float timer;
    public float timerWait;
    public bool facingleft = true;

    void Start()
    {

        animator = GetComponent<Animator>();
        animator.SetBool("running", true);

    }

    private void Update()
    {
        EnemyAct();
    }
    public void EnemyAct()
    {
        checkDis();
        checkFace();
    }
    public override void checkDis()
    {
        if(Vector2.Distance( transform.position , Points[i].position) <0.2f)
        {
            
            timer += Time.deltaTime;
            if (timer < timerWait)
            {

                animator.SetBool("running",false);

                
                return;
            }
            else if(timer >0)
            {
                animator.SetBool("running", true);
            }    
           
            i++;
            if (i == Points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Points[i].position, Enemies_speed * Time.deltaTime);
        timer = 0;

    }
    public void checkFace()
    {
        if(Vector2.Distance(transform.position, Points[i].position) < 0.2f && facingleft == true)
        {
            Flip();
            facingleft = false;
        }
        if (Vector2.Distance(transform.position, Points[Points.Length-1].position)<0.2f && facingleft ==false)
        {
            Flip();
            facingleft = true;

        }
      
        
    }
    void Flip()
    {
        facingleft = !facingleft;
        Vector3 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }










}
