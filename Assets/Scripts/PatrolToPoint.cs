using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolToPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Transform patrolPoint;
    void Start()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Troll")
        {
            agent.SetDestination(patrolPoint.position);
        }
    }
}
