using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class troll : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    private Animator anim;
    public Transform patrol1;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.SetDestination(patrol1.position);
        anim.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
