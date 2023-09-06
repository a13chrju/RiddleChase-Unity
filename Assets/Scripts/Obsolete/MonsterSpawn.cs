using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float CantSpawnRange;
    UnityEngine.AI.NavMeshAgent agent;
    public bool canSeePlayer = false;
    public float dangerTime = 3f;
    public Animator anim;
    Vector3 previousPos;
    public float speed;
    public AudioSource mosnter3d;
    public bool canMove = true, respawn = false, respawingBetween = false;
    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        mosnter3d = this.GetComponent<AudioSource>();
        anim.speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (TooFarAway() || respawn) {
            float x = player.transform.position.x + Random.Range(-200, 200);
            float y = 0;
            float z = player.transform.position.z + Random.Range(-200, 200);
            Vector3 pos = new Vector3(x, y, z);
            if (!TooClose(pos, player.transform)) {
                {
                    respawn = false;
                    transform.position = pos;
                    mosnter3d.volume = 1f;
                };

            }
        }else
        {
            if (Approching())
            {
              //  Debug.Log(40);
            }
        }

        Vector3 fwd = this.transform.TransformDirection(Vector3.forward);
    
        Vector3 posRay = new Vector3(this.transform.position.x, this.transform.position.y+ 3f, this.transform.position.z);
        // Debug.DrawRay(posRay, fwd * 50, Color.red);
        RaycastHit hit;
        /*  if (Physics.Raycast(posRay, fwd, out hit, 50))
          {
              if (hit.collider.gameObject.tag == "Player")
              {
                  dangerTime = Time.time + 3f;
                  canSeePlayer = true;
                  Debug.Log("I SEE YOU");
              }
          }*/

        Vector3 direction = player.transform.position - transform.position;

        if (Physics.Raycast(posRay, direction, out hit, 50) && canMove)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                dangerTime = Time.time + 3f;
                canSeePlayer = true;
                agent.isStopped = false;
            }
        }

        if (canSeePlayer && Time.time < dangerTime)
        {
            agent.SetDestination(player.transform.position);
            respawingBetween = true;
        } else
        {
            canSeePlayer = false;
            agent.isStopped = true;
            if (respawingBetween && Time.time > dangerTime + 3f)
            {
                respawingBetween = false;
                StartCoroutine(transformChange());
            }
        }

        float movementPerFrame = Vector3.Distance(previousPos, transform.position);
        speed = movementPerFrame / Time.deltaTime;

        if (previousPos != transform.position) { anim.SetFloat("SpeedM", speed);  }

        previousPos = transform.position;
    }

    IEnumerator transformChange()
    {
        StartCoroutine(FadeA.StartFade(mosnter3d, 2f, 0f));
        yield return new WaitForSeconds(3f);
        respawn = true;
    }

    public bool TooClose(Vector3 pos, Transform Player)
    {
        if ((Vector3.Distance(pos, Player.position) < CantSpawnRange))
        {
            return true;
        }
        return false;
    }

    public bool TooFarAway()
    {
        if ((Vector3.Distance(this.transform.position, player.transform.position) > 190))
        {
            return true;
        }
        return false;
    }

    public bool Approching()
    {
        if ((Vector3.Distance(this.transform.position, player.transform.position) < 40))
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, player.transform.position, out hit, 50))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    agent.SetDestination(player.transform.position);
                    agent.isStopped = false;
                }
            }

            return true;
        }
        return false;
    }
}
