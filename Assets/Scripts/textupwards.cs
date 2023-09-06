using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textupwards : MonoBehaviour
{
    // Start is called before the first frame update
    public float respawn;
    public Vector3 respawnPosition;
    void Start()
    {
        respawn = Time.time + 4f;
        respawnPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > respawn)
        {
            respawn = Time.time + 4f;
            this.transform.position = respawnPosition;
        }

        this.transform.Translate(Vector3.up * Time.deltaTime, Space.Self);

    }
}
