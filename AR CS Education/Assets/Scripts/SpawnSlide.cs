using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlide : MonoBehaviour {

    public GameObject slide1;
	public GameObject slide2;
    public GameObject slide3;
    public GameObject slide4;
    public GameObject slide5;

    private bool inContact = false;

    void Start(){
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(false);
        slide4.SetActive(false);
        slide5.SetActive(false);
    }

	void OnTriggerEnter(Collider other){
		if (other.tag == "MLSpatialMapper" && inContact == false){
            inContact = true;
            if (StepTracker.instance.step == 0)
            {
                slide1.SetActive(true);
                GameObject slide = Instantiate(slide1, this.gameObject.transform.position, slide1.transform.rotation);
                slide1.SetActive(false);
                StepTracker.instance.prevSlide = slide;
                StepTracker.instance.currAud = StepTracker.instance.step + 3;
                StepTracker.instance.step++;
                StepTracker.instance.click("startTutorial");
            }
			else if (StepTracker.instance.step == 1){
                StepTracker.instance.prevSlide.SetActive(false);
                slide2.SetActive(true);
                GameObject slide = Instantiate(slide2,this.gameObject.transform.position,slide2.transform.rotation);
                slide2.SetActive(false);
                StepTracker.instance.prevSlide = slide;
                StepTracker.instance.currAud = StepTracker.instance.step + 3;
                StepTracker.instance.step++;
                StepTracker.instance.click("nextPart");
			}
            else if (StepTracker.instance.step == 2)
            {
                StepTracker.instance.prevSlide.SetActive(false);
                slide3.SetActive(true);
                GameObject slide = Instantiate(slide3, this.gameObject.transform.position, slide3.transform.rotation);
                slide3.SetActive(false);
                StepTracker.instance.prevSlide = slide;
                StepTracker.instance.currAud = StepTracker.instance.step + 3;
                StepTracker.instance.step++;
                StepTracker.instance.click("nextPart");
            }
            else if (StepTracker.instance.step == 3)
            {
                StepTracker.instance.prevSlide.SetActive(false);
                slide4.SetActive(true);
                GameObject slide = Instantiate(slide4, this.gameObject.transform.position, slide4.transform.rotation);
                slide4.SetActive(false);
                StepTracker.instance.prevSlide = slide;
                StepTracker.instance.currAud = StepTracker.instance.step + 3;
                StepTracker.instance.step++;
                StepTracker.instance.click("nextPart");
                
            }
            else if (StepTracker.instance.step == 4)
            {
                StepTracker.instance.prevSlide.SetActive(false);
                slide5.SetActive(true);
                GameObject slide = Instantiate(slide5, this.gameObject.transform.position, slide5.transform.rotation);
                slide5.SetActive(false);
                StepTracker.instance.prevSlide = slide;
                StepTracker.instance.currAud = StepTracker.instance.step + 3;
                StepTracker.instance.step++;
                StepTracker.instance.start.SetActive(true);
                StepTracker.instance.click("nextPart");
            }
            //transform.position = StepTracker.instance.nextStepPos;
            Destroy(other.gameObject);
            inContact = false;
            if (StepTracker.instance.step == 5){
                this.gameObject.SetActive(false);
            }
		}
	}
}
