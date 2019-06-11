using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;

public class LeftHandController : MonoBehaviour {

    private Controller controller;
    public AudioHelm.HelmController helmController;
    private Scale scale;
    Gestures gestures;

    private float lastFrequency;

	// Use this for initialization
	void Start () {
        controller = new Controller();
        scale = new Scale();
        scale.setScale("Major Scale");
        gestures = new Gestures();
	}

	public void Bang() {
        if (controller.IsConnected) {
            Frame frame = controller.Frame();
            HandList hands = frame.Hands;
            Hand leftHand = hands[0];
            if (leftHand.IsLeft) {
                helmController.FrequencyOff(lastFrequency);
                Vector position = leftHand.PalmPosition;
                if(!gestures.isFist(leftHand)) {
                    int freq = scale.approxByScale(position.y);
                    helmController.FrequencyOn(freq);
                    lastFrequency = freq;
                } else {
                    helmController.FrequencyOn(lastFrequency);
                }
            } else {
                helmController.FrequencyOff(lastFrequency);
            }
        }
    }
}
