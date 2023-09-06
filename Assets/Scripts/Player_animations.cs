using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animations : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    Vector3 previousPos;
    PlayerAttack playerAttack;
    private GameObject enemy;
    private bool inRange = false;
    public float speed;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();

        // arrowdelete = new arrowsfade();
    }



    // Update is called once per frame
    void Update()
    {
        if (playerAttack.enemy != null)
        {
            inRange = playerAttack.inRange(this.transform, playerAttack.enemy.transform, 15f);
            anim.SetBool("inRange", inRange);
            //inRange = this.playerAttack.inRangetest();
        }
        else
        {
            anim.SetBool("inRange", false);
        }



        float movementPerFrame = Vector3.Distance(previousPos, transform.position);
        speed = movementPerFrame / Time.deltaTime;
        anim.SetFloat("Speed", speed);
        previousPos = transform.position;
    }
}
