using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxExploder : MonoBehaviour
{
    private GameObject before;
    private Transform beforePosition;
    public GameObject after, spawned;
    public GameObject player;
    public bool isNotDestroyed = true;
    // Start is called before the first frame update
    void Start()
    {
        before = this.gameObject;
        beforePosition = this.gameObject.transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void explode()
    {
        if (isNotDestroyed)
        {
            this.GetComponent<Loot>().spawn();
            Destroy(before);
            isNotDestroyed = false;
            Vector3 direction = after.transform.position - player.transform.position;
            spawned = Instantiate(after, beforePosition.position, Quaternion.identity);
           spawned.GetComponentInChildren<Rigidbody>().AddForce(player.transform.forward * 300f, ForceMode.Force);
        }
    }
}
