using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health, decreaseValue;
    public float insanity;
    public int team;
    public Slider insanitySlider;
    public CanvasGroup canvasG;
    public Animator anim;
    UnityEngine.AI.NavMeshAgent agent;
    public bool isAlive = true;
    public bool isPlayer = false;
    public bool isMonster = false;
    public Text insanityText;
    public float dazedTime;
    public bool isDazed = false;
    private AudioSource Hit;
    public GameObject hitPraticle;

    public bool updateColor = false;
    public bool isProp = false;
    public bool decrease = true;

    public GameObject player;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //canvasG = this.GetComponentInChildren<CanvasGroup>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;

        if (isPlayer) {
            insanitySlider = GameObject.FindGameObjectWithTag("insanity").GetComponent<Slider>();
            insanitySlider.maxValue = insanity;
            insanitySlider.value = health;

            insanityText = GameObject.FindGameObjectWithTag("insText").GetComponent<Text>();
        }

        if(isMonster)
        {
            Hit = this.GetComponentInChildren<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            if (decrease && insanity > 0) insanity = insanity - Time.deltaTime * decreaseValue;
            if (!decrease && insanity <= 100) insanity = insanity + Time.deltaTime * 20;

            insanitySlider.value = insanity;
            insanityText.text = Mathf.Round(insanity).ToString() + "%";
            if (insanity > 80)
            {
                foreach (var item in insanitySlider.GetComponentsInChildren<Image>())
                {
                    item.color = Color.green;
                }
            }
            else if (insanity > 60)
            {
                foreach (var item in insanitySlider.GetComponentsInChildren<Image>())
                {
                    item.color = Color.yellow;
                }
            }
            else if (insanity > 30)
            {
                foreach (var item in insanitySlider.GetComponentsInChildren<Image>())
                {
                    item.color = new Color32(255, 86, 8, 255);
                }
            }
            else
            {
                foreach (var item in insanitySlider.GetComponentsInChildren<Image>())
                {
                   item.color = Color.red;
                }
            }
        }

        if (isMonster && isDazed && Time.time > dazedTime)
        {
            isDazed = false;
            this.GetComponent<MonsterSpawn>().canMove = true;
            agent.isStopped = false;
        }
    }

    public void takeDmg(float dmg)
    {
        GameObject apa = Instantiate(hitPraticle, new Vector3(this.transform.position.x, this.transform.position.y + 5f, this.transform.position.z), Quaternion.identity);
        apa.gameObject.transform.parent = this.transform;

        if (isMonster)
        {
            Hit.Play();
            isDazed = true;
            dazedTime = Time.time + 1.5f;
            this.GetComponent<MonsterSpawn>().canMove = false;
            agent.isStopped = true;

            return;
        }


        health = health - dmg;
        if (!isPlayer && GetComponent<MonsterMelee>())
        {
            this.transform.LookAt(player.transform);
            GetComponent<MonsterMelee>().setEnemy(player);
        }


        Debug.Log(health);

        if (health < 0 && isAlive && !isPlayer)
        {
            this.GetComponent<Loot>().spawn();
            isAlive = false;

            if (isProp) {
                this.GetComponent<BoxExploder>().explode();
            } else
            {
                // this.gameObject.GetComponent<minion_move>().dead();
                Destroy(this.gameObject.GetComponent<MonsterMelee>());
                Destroy(this.gameObject.GetComponent<MonsterAttack>());
                Destroy(this.gameObject.GetComponent<minionRange>());
                agent.isStopped = true;
                this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                // anim.ResetTrigger("shoot");
                anim.SetTrigger("death");
                Debug.Log("die");
                Destroy(this.gameObject, 10f);
            }
            return;
        }

        if (health < 0 && isAlive && isPlayer)
        {
            Debug.Log("DIED! hehe");
            isAlive = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            Destroy(this.gameObject.GetComponent<PlayerAttack>());
            GetComponent<Player>().die();
            anim.ResetTrigger("shoot");
            anim.SetTrigger("die");
            return;
        }
    }
}
