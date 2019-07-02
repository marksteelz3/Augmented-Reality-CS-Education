using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTracker : MonoBehaviour {

	public static StepTracker instance = null;
	public int step;

	public GameObject start;
	public GameObject nextStep;
	public GameObject hammer;
    public GameObject knife;
    public GameObject knifeBlade;
    public GameObject hammerHead;
    public GameObject handle;
    public GameObject scissors;
	public GameObject handleChars;
    public GameObject knifeChars;
    public GameObject hammerChars;
    public GameObject scissorChars;
	public GameObject slideSpots;
	public GameObject slideSpot1;
    public GameObject slideSpot2;
    public GameObject slideSpot3;
    public GameObject slideSpot4;
    public GameObject slideSpot5;
	public GameObject nextStepBlock;
	public GameObject adjustFloor;

	public float dropInterval;
	public Vector3 nextStepPos;
	public GameObject prevSlide;
	public GameObject controller;
	public GameObject freeObjects;
	public GameObject setPos;
	public GameObject posSet;
	public AudioClip[] aud;
	public int currAud;
	public bool objectGrabbed;
	private AudioSource audSource;
	private float clipLength;
	private bool audPlaying;
	void Awake () {
		if (instance == null){
			instance = this;
		}
		else if (instance != this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		audSource = this.GetComponent<AudioSource>();
		objectGrabbed = false;
	}

    public void setPosition()
    {
        start.transform.SetParent(freeObjects.transform);
		nextStep.transform.SetParent(freeObjects.transform);
		hammer.transform.SetParent(freeObjects.transform);
		knife.transform.SetParent(freeObjects.transform);
		knifeBlade.transform.SetParent(freeObjects.transform);
		hammerHead.transform.SetParent(freeObjects.transform);
		handle.transform.SetParent(freeObjects.transform);
		scissors.transform.SetParent(freeObjects.transform);
		handleChars.transform.SetParent(freeObjects.transform);
		Rigidbody knifeBody = knife.AddComponent<Rigidbody>();
        Rigidbody knifeBladeBody = knifeBlade.AddComponent<Rigidbody>();
        Rigidbody handleBody = handle.AddComponent<Rigidbody>();
        Rigidbody hammerHeadBody = hammerHead.AddComponent<Rigidbody>();
		knifeBody.useGravity = false;
        knifeBladeBody.useGravity = false;
        handleBody.useGravity = false;
        hammerHeadBody.useGravity = false;

		slideSpot2.SetActive(false);
        slideSpot3.SetActive(false);
        slideSpot4.SetActive(false);
        slideSpot5.SetActive(false);
		start.SetActive(false);
		adjustFloor.SetActive(false);
		hammer.SetActive(false);
		knife.SetActive(false);
		knifeBlade.SetActive(false);
		hammerHead.SetActive(false);
		handle.SetActive(false);
		scissors.SetActive(false);
		handleChars.SetActive(false);
		setPos.SetActive(false);
		posSet.SetActive(false);
		nextStepPos = nextStepBlock.transform.position;
    }
	
	public void startTutorial (){
		if (start != null){
			audSource.clip = aud[currAud];
			audSource.Play();
            nextStepBlock.transform.position = nextStepPos;
            slideSpot2.SetActive(true);
		}
	}

    public void nextPart()
    {
		if (step == 2){
            slideSpot3.SetActive(true);
		}
        if (step == 3)
        {
            handleChars.SetActive(true);
            slideSpot4.SetActive(true);
        }
        if (step == 4)
        {
            slideSpot5.SetActive(true);
        }
        if (step == 6)
        {
            handleChars.SetActive(false);
            start.SetActive(false);
            handle.SetActive(true);
        }
        if (step == 8)
        {
            hammerHead.SetActive(true);
            handle.SetActive(false);
        }
        if (step == 9)
        {
            hammerHead.SetActive(false);
            handle.SetActive(true);
        }
        if (step == 10)
        {
            knifeBlade.SetActive(true);
            handle.SetActive(false);
        }
        if (step == 11)
        {
            knifeBlade.SetActive(false);
            knife.SetActive(true);
			knifeChars.SetActive(false);
        }
        audSource.clip = aud[currAud];
		clipLength = audSource.clip.length;
        audSource.Play();
		nextStepBlock.transform.position = nextStepPos;
    }

	public void celebrate(){
		audSource.clip = aud[1];
		audSource.Play();
		Invoke("nextPart",2);
	}

	public void lowerFloor(){
		slideSpots.transform.position = slideSpots.transform.position + new Vector3(0,dropInterval,0);
	}

    public void click(string method)
    {
        Invoke(method, 1);
    }
}
