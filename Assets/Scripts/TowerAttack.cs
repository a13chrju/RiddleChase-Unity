using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject enemy;
    public float range;
    public bool canAttack = false;
    public float coolDown;
    public Transform shot_point;

    public GameObject arrow;
    public int power;
    public float time;
    public float fieldofViewAngle;
    public float damage;
    private bool isfirstTIme = true;

    void Start()
    {
        time = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
       
            if (enemy != null )
            {
            inRange(this.gameObject.transform, enemy.transform, 35f);
            };


        if (Time.time > time)
        {
            if (enemy != null && canAttack)
            {
                if (isfirstTIme == false)
                {
                     time = Time.time + coolDown;
                     Shot();
                }
                else
                {
                    time = Time.time + coolDown - 0.8f;
                    isfirstTIme = false;
                }
            }
        }


    }


        private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerHealth>().team != GetComponentInParent<PlayerHealth>().team)
            {
                if (enemy != null)
                {
                    if (inRange(this.gameObject.transform, enemy.transform, 35f))
                    {

                    }
                    else
                    {
                        enemy = other.gameObject;
                    }
                }
                else
                {
                    enemy = other.gameObject;
                }

            }
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

    public void Shot()
    {
        Debug.Log("Ratta");
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
