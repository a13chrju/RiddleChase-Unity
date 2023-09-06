using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minion_move : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] path_indexes;
    private int index = 0;
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    public GameObject indicator;
    public Rigidbody rg;
    public bool isAlive = true;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        rg = this.GetComponent<Rigidbody>();
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
       // indicator.SetActive(true);

        if (this.GetComponent<PlayerHealth>().team == 2)
        {
            index = path_indexes.Length -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // anim.SetBool("run", true);

        if (isAlive) { agent.SetDestination(path_indexes[index].position); } else { agent.isStopped = true; };


        if (Vector3.Distance(path_indexes[index].position, this.transform.position) < 10f)
        {

            if (this.GetComponent<PlayerHealth>().team == 2)
            {
                if (index > 0)
                {
                    index--;
                }
                else
                {
                    Destroy(this.gameObject);
                    return;
                }
            }
            else { 
                if (index < path_indexes.Length - 1)
                {
                    index++;
                }
                else
                {
                    Destroy(this.gameObject);
                    return;
                }
            }
       
        } 
    }

    public void dead()
    {
        isAlive = false;
    }
}
