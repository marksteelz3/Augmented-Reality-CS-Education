using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSubClass : MonoBehaviour {

	public GameObject hammer;
	public GameObject knife;
	public Vector3 adjustment;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other != null && other.tag == "HammerHead" && StepTracker.instance.step == 8){
            //Step 9
            StepTracker.instance.objectGrabbed = false;
			hammer.SetActive(true);
			GameObject sub = Instantiate(hammer,this.gameObject.transform.position + adjustment, hammer.transform.rotation);
			hammer.SetActive(false);
            StepTracker.instance.currAud = StepTracker.instance.step + 3;
            StepTracker.instance.step++;
            StepTracker.instance.click("nextPart");
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
        else if (other != null && other.tag == "KnifeBlade" && StepTracker.instance.step == 10)
        {
            //Step 11
            StepTracker.instance.objectGrabbed = false;
            knife.SetActive(true);
            GameObject sub = Instantiate(knife, this.gameObject.transform.position + adjustment, knife.transform.rotation);
			sub.GetComponent<CreateScissor>().isCopy = true;
            knife.SetActive(false);
            StepTracker.instance.currAud = StepTracker.instance.step + 3;
            StepTracker.instance.step++;
            StepTracker.instance.click("nextPart");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
	}
}
