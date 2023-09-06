using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMeleeRange : MonoBehaviour
{
    private GameObject enemy;
    public bool inSight;
    private bool Chase = false;
    void Start()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (GetComponentInParent<MonsterMelee>() != null)
        {
            if (other.gameObject.tag == "Player")
            {
                RaycastHit hit;
                
                Vector3 posRay = new Vector3(this.transform.position.x, this.transform.position.y + 3f, this.transform.position.z);
                if (inSight && Physics.Raycast(posRay, this.transform.forward, out hit, 50))
                {
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        Chase = true;
                        Debug.Log("I SEE");
                    }
                }
                if (!Chase && inSight) return;

                if (enemy != null)
                {
                    GetComponentInParent<MonsterMelee>().inRange(this.gameObject.transform, enemy.transform, 15f);
                }
                else
                {
                    enemy = other.gameObject;
                    this.transform.LookAt(enemy.transform);
                    GetComponentInParent<MonsterMelee>().setEnemy(enemy);
                }


            }
        }
    }
}
