using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowsfade : MonoBehaviour {

    // Use this for initialization
    float TimetoDie;
    public GameObject me;


	void Start () {
        TimetoDie = Time.time + 2f;

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > TimetoDie && me != null)
        {        
            Destroy(this.me);
        }
        me.transform.position = new Vector3(me.transform.position.x, me.transform.position.y - Time.deltaTime *1f, me.transform.position.z);
	}
}
