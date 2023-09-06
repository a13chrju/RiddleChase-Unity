using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    Vector3 previousPos;
    Transform MainCamera;
    PlayerAttack playerAttack;
    public bool hoverPlayer;
    private GameObject enemy;
    private bool inRange = false;
    public bool stopWait = false;
    public float speed;
    public GameObject DeadText;

    public GameObject particlesHealth;
    Animator animDead;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
      //  playerAttack = GetComponent<PlayerAttack>();
      //  MainCamera = Camera.main.transform;
        // arrowdelete = new arrowsfade();
       // DeadText.SetActive(true);
       // animDead = DeadText.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
             /*   if (hit.collider.gameObject.tag == "enemy")
                {
                    enemy = hit.collider.gameObject;
                    this.transform.LookAt(hit.collider.gameObject.transform);
                    playerAttack.setEnemy(enemy);
                } else if (hit.collider.gameObject.tag == "read")
                {
                    return; 
                }
                else if (hit.collider.gameObject.tag == "lootItem")
                {
                    enemy = hit.collider.gameObject;
                    this.transform.LookAt(hit.collider.gameObject.transform);
                    playerAttack.setEnemy(enemy);
                    return;
                }
                else
                {
                    playerAttack.setEnemy(null);
                    agent.isStopped = false;
                    enemy = null;
                    this.GetComponent<PlayerAttack>().canShot();
                }*/

                agent.SetDestination(hit.point);
            }
        }
    }

    [System.Obsolete]
    public void healthParticles(bool show)
    {
        if (show)
        {
            particlesHealth.GetComponent<ParticleSystem>().emissionRate = 10;
        } else
        {
            particlesHealth.GetComponent<ParticleSystem>().emissionRate = 0;
        }
    }

    public void die () {
       /* animDead.SetTrigger("dead");
        Debug.LogWarning("died");
        agent.Stop();
        agent.ResetPath();
        agent.velocity = Vector3.zero;*/
        Destroy(this);
    }
}
