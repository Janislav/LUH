using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;

public class RightHandController : MonoBehaviour {

    private Controller controller;
    public AudioHelm.HelmController helmController;

	// Use this for initialization
	void Start () {
        controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
