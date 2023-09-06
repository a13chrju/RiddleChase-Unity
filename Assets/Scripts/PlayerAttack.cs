using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
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

    public AudioSource Arrow, footsteps;



    Vector3 previousPos;
    public float speed;

    UnityEngine.AI.NavMeshAgent agent;


    PlayerAttack playerAttack;
    public bool hoverPlayer;
    public float x, y, z;


  

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        time = Time.time;
        anim = this.GetComponent<Animator>();
        anima = this.GetComponent<Animation>();
       //  anim.updateMode = AnimatorUpdateMode.UnscaledTime;
       //  anim.SetFloat("animSpeed", (1 / coolDown) * 3);
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Time.time > time)
        {
            if (enemy != null && canAttack && enemy.GetComponent<PlayerHealth>().isAlive)
            {
                if (isfirstTIme == false)
                {
                    Vector3 direction = enemy.transform.position - transform.position;
                    float angle = Vector3.Angle(direction, transform.forward);

                    Vector3 posRay = new Vector3(this.transform.position.x, this.transform.position.y + 0.8f, this.transform.position.z);
                    RaycastHit hit;

                    if (Physics.Raycast(posRay, direction, out hit, 500))
                    {
                        Debug.Log(hit.collider.tag);
                        if (angle < fieldofViewAngle * 0.5f && (hit.collider.tag == "enemy" || hit.collider.tag == "lootItem"))
                        {
                            Debug.Log("sky");
                            time = Time.time + coolDown;
                            if (this.GetComponent<Rigidbody>().velocity.x == 0)
                            {
                                anim.SetTrigger("shoot");
                                Shot();
                            }
                        }

                    }
                }
                else
                {
                    time = Time.time + coolDown - 0.8f;
                    isfirstTIme = false;
                }
            }
        }


        if (enemy != null)
        {
            isinRange = inRange(this.transform, enemy.transform, 25f);
            anim.SetBool("inRange", isinRange);
            //inRange = this.playerAttack.inRangetest();
        }
        else
        {
            anim.SetBool("inRange", false);
        }

        if (isinRange && enemy != null)
        {
            // anim.SetBool("idle2", true);
            this.transform.LookAt(enemy.transform);
            agent.isStopped = true;
        }

        if (enemy != null && !isinRange)
        {
            agent.isStopped = false;
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

        if (speed > 0.5 && !footsteps.isPlaying)
        {
            footsteps.volume = Random.Range(0.07f, 0.1f);
            footsteps.pitch = Random.Range(0.8f, 1.1f);
            footsteps.Play();
        }

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
        Arrow.Play();
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
