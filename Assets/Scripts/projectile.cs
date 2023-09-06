using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private Transform enemyPosition;
    public float speed = 20;
    private GameObject enemy;
    private float dmg;
    private GameObject playerWhoShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Seek(Transform target, GameObject enemy, float dmg, GameObject playerWhoShot)
    {
        this.enemy = enemy;
        enemyPosition = target;
        this.dmg = dmg;
        this.playerWhoShot = playerWhoShot;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyPosition == null)
        {
            Destroy(gameObject);
            return;
        }


        Vector3 dir = new Vector3(enemyPosition.position.x, enemyPosition.position.y + 2f, enemyPosition.position.z) - transform.position;
        float distancePerFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distancePerFrame)
        { //hit
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
    }

     void HitTarget()
    {
        enemy.GetComponent<PlayerHealth>().takeDmg(dmg);
        Destroy(gameObject);
    }
}
