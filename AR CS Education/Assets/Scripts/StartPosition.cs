using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {

	public Transform controller;

	// Use this for initialization
	void Start () {
		transform.position = controller.forward + controller.forward;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
