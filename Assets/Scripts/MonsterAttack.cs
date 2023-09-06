using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float range;
    public bool canAttack = false;
    public float coolDown;
    public Transform shot_point;

    public GameObject arrow;
    public int power;
    private Animator anim;
    private Animation anima;
    public float time;
    public float fieldofViewAngle;
    public float damage;
    private bool isfirstTIme = true;
    private bool isinRange = false;
    public float waitTime;


    Vector3 previousPos;
    public float speed;

    UnityEngine.AI.NavMeshAgent agent;


    PlayerAttack playerAttack;
    public bool hoverPlayer;
    public float x, y, z;


    public bool firstWait = true;

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
                Debug.Log("AAAAA");
                if (isfirstTIme == false)
                {
                    Debug.Log("BBB");
                  
            
                        time = Time.time + coolDown;
                        if (this.GetComponent<Rigidbody>().velocity.x == 0)
                        {
                            anim.SetTrigger("shoot");
                            Shot();
                        }
                   
                }
                else
                {
                    time = Time.time + coolDown - 0.8f;
                    isfirstTIme = false;
                }
            }
        }


        anim.SetFloat("animSpeed", (1 / coolDown) * 3);


        if (enemy != null)
        {
            isinRange = inRange(this.transform, enemy.transform, 15f);
            anim.SetBool("inRange", isinRange);
            //inRange = this.playerAttack.inRangetest();
        }
        else
        {
            anim.SetBool("inRange", false);
        }

        if (isinRange && enemy != null && this.GetComponent<PlayerHealth>().isAlive)
        {
            // anim.SetBool("idle2", true);s
            this.transform.LookAt(enemy.transform);
            agent.isStopped = true;
        }

        if (enemy != null && !isinRange && this.GetComponent<PlayerHealth>().isAlive)
        {
            if (Time.time > waitTime)
            {
                agent.isStopped = false;
                agent.SetDestination(enemy.transform.position);
                firstWait = true;
            }
        }

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

    public void Shot()
    {
      
        GameObject temp = Instantiate(arrow, shot_point.position, this.transform.rotation) as GameObject;
        projectile newProejctile = temp.GetComponent<projectile>();

        if (arrow != null)
        {
            newProejctile.Seek(enemy.transform, enemy, damage, this.gameObject);
        }
        // temp.GetComponent<Rigidbody>().AddForce(this.transform.forward * power, ForceMode.Impulse);
    }

    public void canShot()
    {
        canAttack = false;
    }
}
