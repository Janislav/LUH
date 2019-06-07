using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;

public class LeftHandController : MonoBehaviour {

    private Controller controller;
    public AudioHelm.HelmController helmController;
    public int bpm;

    private float lastFrequency;

	// Use this for initialization
	void Start () {
        controller = new Controller();
        float invertedValue = bpm / 60;
        float intervall = 1 / invertedValue;
        Debug.Log("Intervall :" + intervall);
        InvokeRepeating("Bang", 0.0f, intervall);
	}

    void Bang() {
        if (controller.IsConnected)
        {
            Frame frame = controller.Frame();
            HandList hands = frame.Hands;
            //PointableList pointables = frame.Pointables;
            //FingerList fingers = frame.Fingers;
            //ToolList tools = frame.Tools;
            Hand leftHand = hands[0];
            if (leftHand.IsLeft) {
                helmController.FrequencyOff(lastFrequency);
                Vector position = leftHand.PalmPosition;
                int note = (int)position.y;
                helmController.FrequencyOn(position.y);
                //helmController.NoteOn(note, 1.0f, 0.1f);
                //helmController.NoteOn(note + 3, 1.0f, 0.1f);
                lastFrequency = position.y;
                //Debug.Log(position);
            } else {
                helmController.FrequencyOff(lastFrequency);
            }
        }
    }
}
