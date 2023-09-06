using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject minion;
    public int team;

    void Start()
    {
        //a minion will spawn every 15 seconds starting from 2 seconds.
        InvokeRepeating("spawn_minion", 2.0f, 20f);
        InvokeRepeating("spawn_minion", 2.0f, 20f); 
        InvokeRepeating("spawn_minion", 2.0f, 20f);
        InvokeRepeating("spawn_minion", 2.0f, 20f);
        InvokeRepeating("spawn_minion", 2.0f, 20f);
    }

    void spawn_minion()
    {
        GameObject temp = Instantiate(minion, this.transform.position, this.transform.rotation) as GameObject;
        temp.GetComponent<PlayerHealth>().team = team;
    }
}
