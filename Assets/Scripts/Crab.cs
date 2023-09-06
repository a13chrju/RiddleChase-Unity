using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Crab : MonoBehaviour
{
    // Start is called before the first frame update
    private bool activeScript = true;
    public GameObject Spider;
    public Transform crabSpawnPoint, crabWalkTo;
    private NavMeshAgent SpiderAgent;
    GameObject PS;

    void Start()
    {
        SpiderAgent = Spider.GetComponent<NavMeshAgent>();
        PS = GameObject.FindGameObjectWithTag("PlayerStatus");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && activeScript)
        {
            activeScript = false;
            SpiderAgent.enabled = false;
            Spider.transform.position = crabSpawnPoint.position;
            SpiderAgent.enabled = true;
            SpiderAgent.SetDestination(crabWalkTo.position);
            StartCoroutine(PS.GetComponent<PlayerStatus>().playIntenseMusic());
        }
    }
}
