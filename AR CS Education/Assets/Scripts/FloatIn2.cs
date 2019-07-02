using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatIn2 : MonoBehaviour {

    // Use this for initialization

    private float start;
    private float end;
    private float startTime;
    public float distance;
    public float duration;

    // Use this for initialization
    void Start()
    {
        start = this.transform.position.y;
        end = start + distance;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        transform.position = new Vector3(this.transform.position.x, Mathf.SmoothStep(start, end, t), this.transform.position.z);
    }
}
