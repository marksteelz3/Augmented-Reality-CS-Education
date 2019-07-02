using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScissor : MonoBehaviour {

    public GameObject scissors;
    public Vector3 adjustment;
	public bool isCopy;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other != null && other.tag == "Knife" && StepTracker.instance.step == 11 && isCopy)
        {
            //Step 9
            StepTracker.instance.objectGrabbed = false;
            scissors.SetActive(true);
            GameObject sub = Instantiate(scissors, this.gameObject.transform.position + adjustment, scissors.transform.rotation);
            scissors.SetActive(false);
            StepTracker.instance.currAud = StepTracker.instance.step + 3;
            StepTracker.instance.step++;
            StepTracker.instance.click("nextPart");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
	}
}
