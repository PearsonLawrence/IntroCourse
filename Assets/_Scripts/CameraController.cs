﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject FocusPoint; // Player or object we want to follow

    private Vector3 Offset; // Offset based off of our starting location relative to the focus point

    public float InterpSpeed; // How fast we want to interpulate or move towards a location
	// Use this for initialization
	void Start () {
		
        if(FocusPoint)
        {
            Offset = transform.position - FocusPoint.transform.position;
        }
        else
        {
            Debug.Log("No Focus Point");
        }
	}
	
    public void CamMoveTowards(float mspeed, Vector3 ML)
    {
        transform.position = Vector3.MoveTowards(transform.position, ML + Offset, mspeed * Time.deltaTime);
    }

    public void CamLerpTowards(float mspeed, Vector3 ML)
    {
        transform.position = Vector3.Lerp(transform.position, ML + Offset, mspeed * Time.deltaTime);
    }

	// Update is called once per frame
	void LateUpdate () {
        CamLerpTowards(InterpSpeed, FocusPoint.transform.position);
	}
}
