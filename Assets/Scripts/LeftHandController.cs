using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;

public class LeftHandController : MonoBehaviour {

    private Controller controller;
    public AudioHelm.HelmController helmController;
    public int bpm;
    private Scale scale;

    private float lastFrequency;

	// Use this for initialization
	void Start () {
        controller = new Controller();
        float invertedValue = bpm / 60;
        float intervall = 1 / invertedValue;
        Debug.Log("Intervall :" + intervall);
        scale = new Scale();
        scale.setScale("Major Scale");
        InvokeRepeating("Bang", 0.0f, intervall);
	}

    void Update() {
        if (controller.IsConnected) {
            Frame frame = controller.Frame();
            HandList hands = frame.Hands;
            //PointableList pointables = frame.Pointables;
            //FingerList fingers = frame.Fingers;
            //ToolList tools = frame.Tools;
            Hand leftHand = hands[0];
            if (leftHand.IsLeft)
            {
                Vector position = leftHand.PalmPosition;
                float value = position.x;

                if (value < 0) {
                    value = value * -1;
                }

                value = value / 100;

                if (value >= 1) {
                    value = 1;
                }
                if (value <= 0) {
                    value = 0;
                }
                Debug.Log("CrossMode: " + value);
                helmController.SetParameterPercent(AudioHelm.Param.kFilterCutoff, value);
            }
        }
    }

	void Bang() {
        if (controller.IsConnected) {
            Frame frame = controller.Frame();
            HandList hands = frame.Hands;
            //PointableList pointables = frame.Pointables;
            //FingerList fingers = frame.Fingers;
            //ToolList tools = frame.Tools;
            Hand leftHand = hands[0];
            if (leftHand.IsLeft) {
                helmController.FrequencyOff(lastFrequency);
                Vector position = leftHand.PalmPosition;
                //int note = (int)position.y;
                int freq = scale.approxByScale(position.y);
                Debug.Log("Freq: " + freq);
                helmController.FrequencyOn(freq);
                lastFrequency = freq;
            } else {
                helmController.FrequencyOff(lastFrequency);
            }
        }
    }
}
