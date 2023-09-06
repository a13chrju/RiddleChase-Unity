using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCrab : MonoBehaviour
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
    public float time;
    public AudioSource mosnter3d, attack;
    public bool canMove = true, respawn = false, respawingBetween = false;

    private bool canAttack = false;
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
        if (!player.GetComponent<Player>())
        {
            agent.isStopped = true;
            Debug.Log("EEE"); Destroy(this);
        }
        float movementPerFrame = Vector3.Distance(previousPos, transform.position);
        speed = movementPerFrame / Time.deltaTime;

        if (previousPos != transform.position) { anim.SetFloat("SpeedM", speed); }
        previousPos = transform.position;

        Vector3 posRay = new Vector3(this.transform.position.x, this.transform.position.y + 3f, this.transform.position.z);
        RaycastHit hit;
        Vector3 direction = player.transform.position - transform.position;
        Vector3 posPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 3f, player.transform.position.z);

        Debug.DrawLine(posRay, posPlayer, Color.red);
        if (Physics.Raycast(posRay, direction, out hit, 50))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                agent.SetDestination(player.transform.position);
            }
        }


        if (canAttack)
        {
            if (Time.time > time && player.GetComponent<PlayerHealth>().isAlive)
            {
                anim.SetTrigger("attack");
                melee();
            }
        }
    }


    public void melee()
    {
        if (!attack.isPlaying)
        {
            attack.Play();
        }
        player.GetComponent<PlayerHealth>().takeDmg(400);

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


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canAttack = true;
            this.transform.LookAt(player.transform);
        }
    }
}

