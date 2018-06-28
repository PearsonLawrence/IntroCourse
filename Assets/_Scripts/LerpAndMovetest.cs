using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAndMovetest : MonoBehaviour {

    public bool doLerp;
    public float speed;
    public GameObject movepoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(doLerp)
        {
            transform.position = Vector3.Lerp(transform.position, movepoint.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movepoint.transform.position, speed * Time.deltaTime);
        }

	}
}
