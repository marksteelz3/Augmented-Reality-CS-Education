using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public static Manager instance = null;
	public GameObject startMenu;
	public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    public GameObject step4;
    public GameObject step5;
	public GameObject exampleMenu;
	public GameObject handleImage;
    public GameObject hammerHeadImage;
    public GameObject knifeBladeImage;
	public GameObject knifeButtonImage;
    public GameObject knifeButtonImage2;
    public GameObject hammerImage;
    public GameObject knifeImage;
    public GameObject scissorsImage;
	public GameObject grabbedObject;
	public int step = 0;
	public AudioClip[] aud;

    private AudioSource audSource;
    private bool objectGrabbed;

	void Awake(){
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        audSource = this.GetComponent<AudioSource>();
        objectGrabbed = false;
	}

	void Update(){
		if (grabbedObject != null && objectGrabbed){
			grabbedObject.transform.position = Input.mousePosition;
			if (Input.GetMouseButtonDown(0)){
                if (step == 7)
                {
                    audSource.clip = aud[step];
                    audSource.Play();
                    step++;
                }
                else if (step == 8)
                {
                    audSource.clip = aud[step];
                    audSource.Play();
                    step++;
					handleImage.SetActive(false);
					hammerHeadImage.SetActive(false);
					hammerImage.SetActive(true);
                }
                else if (step == 9)
                {
                    audSource.clip = aud[step];
                    audSource.Play();
                    step++;
                }
                else if (step == 10)
                {
                    audSource.clip = aud[step];
                    audSource.Play();
                    step++;
                    handleImage.SetActive(false);
                    knifeBladeImage.SetActive(false);
                    knifeImage.SetActive(true);
                }
                else if (step == 11)
                {
                    step++;
                }
                else if (step == 12)
                {
                    audSource.clip = aud[step-1];
                    audSource.Play();
                    knifeButtonImage.SetActive(false);
                    knifeButtonImage2.SetActive(false);
                    scissorsImage.SetActive(true);
                }
				grabbedObject = null;
				objectGrabbed = false;
			}
		}
	}

	public void nextStep(){
		if (step == 0){
            audSource.clip = aud[step];
            audSource.Play();
			step++;
			step1.SetActive(true);
			startMenu.SetActive(false);
		}
        else if (step == 1)
        {
            audSource.clip = aud[step];
            audSource.Play();
            step++;
            step2.SetActive(true);
            step1.SetActive(false);
        }
        else if (step == 2)
        {
            audSource.clip = aud[step];
            audSource.Play();
            step++;
            step3.SetActive(true);
            step2.SetActive(false);
        }
        else if (step == 3)
        {
            audSource.clip = aud[step];
            audSource.Play();
            step++;
            step4.SetActive(true);
            step3.SetActive(false);
        }
        else if (step == 4)
        {
            audSource.clip = aud[step];
            audSource.Play();
            step++;
            step5.SetActive(true);
            step4.SetActive(false);
        }
        else if (step == 5)
        {
            audSource.clip = aud[step];
            audSource.Play();
            step++;
            exampleMenu.SetActive(true);
            step5.SetActive(false);
        }
	}

	public void copyObject(){
        if (step == 6){
            audSource.clip = aud[step];
            audSource.Play();
            step++;
            handleImage.SetActive(true);
            grabbedObject = handleImage;
            objectGrabbed = true;
		}
        else if (step == 8)
        {
            hammerHeadImage.SetActive(true);
            grabbedObject = hammerHeadImage;
            objectGrabbed = true;
        }
		else if (step == 9){
            handleImage.SetActive(true);
            grabbedObject = handleImage;
            objectGrabbed = true;
		}
        else if (step == 10)
        {
            knifeBladeImage.SetActive(true);
            grabbedObject = knifeBladeImage;
            objectGrabbed = true;
        }
        else if (step == 11)
        {
            knifeButtonImage.SetActive(true);
            grabbedObject = knifeButtonImage;
            objectGrabbed = true;
        }
        else if (step == 12)
        {
            knifeButtonImage2.SetActive(true);
            grabbedObject = knifeButtonImage2;
            objectGrabbed = true;
        }
	}

}
