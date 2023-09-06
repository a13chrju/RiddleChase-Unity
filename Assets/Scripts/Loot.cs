using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coin, potion, key;
    public float popSpeed;
    private Vector3 gameo;

    public bool spawnKey;
    void Start()
    {
        gameo = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 2f, this.gameObject.transform.position.z);
    }

    public void spawn()
    {
        if (spawnKey)
        {
            createObject();
            return;
        }
        createObject();
        createObject();
        createObject();
        createObject();
    }

    public void createObject()
    {
        GameObject toInstanciate = getGameobject();

        GameObject monkey = Instantiate(toInstanciate, gameObject.transform.position, Quaternion.identity);
        monkey.GetComponent<Rigidbody>().AddForce(monkey.transform.up * popSpeed, ForceMode.Force);
    }

    GameObject getGameobject (){

        if (spawnKey) return key;

        var rand = Random.Range(1, 4);

        switch(rand)
        {
            case 1: return coin;
            case 2: return potion;
            default: return coin;
        }
    }
}
