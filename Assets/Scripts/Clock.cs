using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Clock : MonoBehaviour {

    public int bpm;
    public UnityEvent b_Event;

	// Use this for initialization
	void Start () {
        float invertedValue = bpm / 60;
        float intervall = 1 / invertedValue;
        InvokeRepeating("Bang", 0.0f, intervall);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Bang() {
        b_Event.Invoke();
    }
}
