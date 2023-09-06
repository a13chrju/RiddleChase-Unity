using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minion_attack : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    Vector3 previousPos;
    PlayerAttack playerAttack;
    public bool hoverPlayer;
    public float x, y, z;
    private GameObject enemy;
    private bool inRange = false;
    public float speed;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();

        // arrowdelete = new arrowsfade();
    }

 

    // Update is called once per frame
    void Update()
    {

        if (enemy != null)
        {
            inRange = this.GetComponent<PlayerAttack>().inRange(this.transform, enemy.transform, 15f);
            anim.SetBool("inRange", inRange);
            //inRange = this.playerAttack.inRangetest();
        }
        else
        {
            anim.SetBool("inRange", false);
        }

        if (inRange && enemy != null)
        {
           // anim.SetBool("idle2", true);
            this.transform.LookAt(enemy.transform);
            agent.isStopped = true;
        }

        if (enemy != null && !inRange)
        {
            agent.isStopped = false;
           // agent.SetDestination(enemy.transform.position);
        }

 /*       if (previousPos != transform.position && !inRange)
        {
            anim.SetBool("idle2", false);
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }*/
        if (enemy == null)
        {
            agent.isStopped = false;
        }


        // float speed = (previousPos = transform.position).magnitude;
        // anim.SetFloat("Speed", speed);
        float movementPerFrame = Vector3.Distance(previousPos, transform.position);
        speed = movementPerFrame / Time.deltaTime;
        anim.SetFloat("Speed", speed);
        previousPos = transform.position;
    }

    public void setEnemy(GameObject enemy)
    {
        this.enemy = enemy;
        this.GetComponent<PlayerAttack>().setEnemy(enemy);
    }

}
