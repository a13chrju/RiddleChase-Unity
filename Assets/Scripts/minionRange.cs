using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionRange : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject enemy;
    void Start()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (GetComponentInParent<MonsterAttack>() != null) { 
        if (other.gameObject.tag == "Player")
        {
 
                if (enemy != null)
                {
                    if (GetComponentInParent<MonsterAttack>().inRange(this.gameObject.transform, GetComponentInParent<MonsterAttack>().enemy.transform, 15f))
                    {

                    }
                    else
                    {
                        enemy = other.gameObject;
                        this.transform.LookAt(enemy.transform);
                        GetComponentInParent<MonsterAttack>().setEnemy(enemy);
                    }
                }
                else
                {
                    enemy = other.gameObject;
                    this.transform.LookAt(enemy.transform);
                    GetComponentInParent<MonsterAttack>().setEnemy(enemy);
                }

         
        }
    }
    }
}
