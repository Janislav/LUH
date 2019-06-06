using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;

public class LeftHandController : MonoBehaviour {

    private Controller controller;
    public AudioHelm.HelmController helmController;

    private float time1;
    private float time2;

	// Use this for initialization
	void Start () {
        controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.IsConnected) {
            Frame frame = controller.Frame();
            HandList hands = frame.Hands;
            //PointableList pointables = frame.Pointables;
            //FingerList fingers = frame.Fingers;
            //ToolList tools = frame.Tools;
            Hand leftHand = hands[0];
            if (leftHand.IsLeft) {
                Vector position = leftHand.PalmPosition;
                int note = (int) position.y;
                helmController.NoteOn(note, 1.0f, 0.1f);
                Debug.Log(position);
            }
        }
	}
}
