using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	public GameObject objectHeld;

    private void OnTriggerEnter(Collider other){
		if (other != null){
			objectHeld = other.gameObject;
		}
	}
}
