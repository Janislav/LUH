using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

using Leap;

[System.Serializable] public class FrequencyChanged : UnityEvent<float> { }

public class LeftHandController : MonoBehaviour {

    private Controller controller;
    public AudioHelm.HelmController helmController;
    private Scale scale;
    Gestures gestures;

    public FrequencyChanged frequencyChanged;

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
                    frequencyChanged.Invoke(freq);
                } else {
                    helmController.FrequencyOn(lastFrequency);
                    //changedLength.Invoke(lastFrequency);
                }
            } else {
                helmController.FrequencyOff(lastFrequency);
                // TODO: send some off event here
                //changedLength.Invoke(lastFrequency);
            }
        }
    }
}
