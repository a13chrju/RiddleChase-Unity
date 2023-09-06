using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMelee : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public bool canAttack = false;
    public float coolDown;

    public int power;
    private Animator anim;
    private Animation anima;
    public float time;
    public float fieldofViewAngle;
    public float damage;
    private bool isfirstTIme = true;
    private bool isinRange = false;
    public float meleeRange;

    public AudioSource attack;


    Vector3 previousPos;
    public float speed;

    UnityEngine.AI.NavMeshAgent agent;


    PlayerAttack playerAttack;
    public bool hoverPlayer;
    public float x, y, z;


    public bool firstWait = false;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        time = Time.time;
        anim = this.GetComponent<Animator>();
        anima = this.GetComponent<Animation>();
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > time)
        {
            if (enemy != null && canAttack && enemy.GetComponent<PlayerHealth>().isAlive)
            {
                Debug.Log("aaaa");
                time = Time.time + coolDown;
                if (isinRange)
                {

                    anim.SetTrigger("attack");
                    melee();
                }
            }
        }

        if (enemy != null)
        {
            isinRange = inRange(this.transform, enemy.transform, meleeRange);
        }

        if (enemy && !enemy.GetComponent<PlayerHealth>().isAlive)
        {
            agent.isStopped = true;
        }

        if (isinRange && enemy != null && this.GetComponent<PlayerHealth>().isAlive)
        {
            // anim.SetBool("idle2", true);s
            this.transform.LookAt(enemy.transform);
           // agent.isStopped = true;
        }

        if (enemy != null && !isinRange && this.GetComponent<PlayerHealth>().isAlive)
        {
                agent.isStopped = false;
                agent.SetDestination(enemy.transform.position);
        }

        if (enemy == null)
        {
            agent.isStopped = true;
        }


        // float speed = (previousPos = transform.position).magnitude;
        // anim.SetFloat("Speed", speed);
        float movementPerFrame = Vector3.Distance(previousPos, transform.position);
        speed = movementPerFrame / Time.deltaTime;
        anim.SetFloat("Speed", speed);
        previousPos = transform.position;

    }

    public bool inRange(Transform player, Transform Enemy, float range)
    {
        if ((Vector3.Distance(player.position, Enemy.position) < range))
        {
            canAttack = true;
            return true;
        }
        canAttack = false;
        return false;
    }


    public void setEnemy(GameObject Enemy)
    {
        isfirstTIme = true;
        this.enemy = Enemy;
    }

    public void melee()
    {
        if (!attack.isPlaying)
        {
            attack.Play();
        }
        enemy.GetComponent<PlayerHealth>().takeDmg(damage);

    }

    public void canShot()
    {
        canAttack = false;
    }
}
