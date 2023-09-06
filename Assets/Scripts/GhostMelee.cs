using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMelee : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float coolDown;
    public GameObject particles;

    public int power;
    private Animator anim;
    private Animation anima;
    private float time;
    public float damage;
    private bool isfirstTIme = true;
    public float meleeRange;

    public AudioSource attack;


    Vector3 previousPos;
    private float speed;

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

    void Update()
    {

        if (Time.time > time)
        {
            if (enemy != null && enemy.GetComponent<PlayerHealth>().isAlive)
            {
                time = Time.time + coolDown;
                if (inRange(this.transform, enemy.transform, meleeRange))
                {

                    anim.SetTrigger("attack");
                    melee();
                }
            }
        }

        if (enemy && !enemy.GetComponent<PlayerHealth>().isAlive)
        {
            Destroy(GetComponent<Ghost>());
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
            return true;
        }
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
        Instantiate(particles, enemy.transform.position, Quaternion.identity);
        enemy.GetComponent<PlayerHealth>().takeDmg(damage);

    }
}
