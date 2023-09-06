using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject areaToSpawnWithin, PlayerInAreaBounds, particles;
    private Bounds spawnBound, withinBounds;
    public GameObject player;
    private NavMeshAgent navMeshAgent;
    private Vector3 recallPosition, spawnPosition;
    private bool active = false;
    private bool addghostScript = false;

    public float respawnTime = 7;
    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        spawnBound = areaToSpawnWithin.GetComponent<Collider>().bounds;
        withinBounds = PlayerInAreaBounds.GetComponent<Collider>().bounds;
        spawnPosition = RandomPointInBounds(spawnBound);
        recallPosition = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       if (withinBounds.Contains(player.transform.position))
           {
               if (addghostScript) { this.GetComponent<GhostMelee>().enabled = true; addghostScript = false; }
               active = true;
               navMeshAgent.isStopped = false;
               navMeshAgent.SetDestination(player.transform.position);

               if (Time.time > respawnTime)
               {
                   Vector3 posGhost = new Vector3(this.transform.position.x, this.transform.position.y + 0.8f, this.transform.position.z);
                   Instantiate(particles, posGhost, Quaternion.identity);
                   Random.seed = (int)System.DateTime.Now.Ticks;
                   var spawnPosition = RandomPointInBounds(spawnBound);
                   this.transform.position = spawnPosition;
                   Instantiate(particles, spawnPosition, Quaternion.identity);
                   respawnTime = Time.time + 7f;
               }
           } else {
               if(active)
               {
                   addghostScript = true;
                   this.GetComponent<GhostMelee>().enabled = false;
                   Instantiate(particles, this.transform.position, Quaternion.identity);
                   Debug.Log("tja");
                   navMeshAgent.isStopped = true;
                   this.transform.position = recallPosition;
                   active = false;
               }
           }
    }

    public Vector3 RandomPointInBounds(Bounds bounds)
    {
        Vector3 spawn = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
        Debug.Log(spawn);
        return spawn;
    }

}
