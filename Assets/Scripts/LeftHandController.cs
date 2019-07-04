using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

using Leap;

public class LeftHandController : MonoBehaviour {

    private Controller controller;
    public AudioHelm.HelmController helmController;
    private Scale scale;
    Gestures gestures;

    public FloatEvent frequencyChanged;
    public FloatEvent cutOffChanged;

    private float lastFrequency;

	// Use this for initialization
	void Start () {
        controller = new Controller();
        scale = new Scale();
        scale.setScale("Major Scale");
        gestures = new Gestures();
	}

    Hand getLefttHand(HandList hands)
    {
        if (hands.IsEmpty)
        {
            return null;
        }

        if (hands.Count == 1)
        {
            if (hands[0].IsLeft && hands[0].IsValid)
            {
                return hands[0];
            }
            else
            {
                return null;
            }
        }

        if (hands.Count > 1)
        {
            foreach (Hand hand in hands)
            {
                if (hand.IsLeft && hand.IsValid)
                {
                    return hand;
                }
            }
        }

        return null;
    }


	void Update() {

        if (controller.IsConnected) {

            Frame frame = controller.Frame();
            HandList hands = frame.Hands;
            Hand leftHand = getLefttHand(hands);

            if (leftHand != null)
            {
                Vector position = leftHand.PalmPosition;

                float value = position.x;

                if (value < 0)
                {
                    value = value * -1;
                }

                value = value / 500;

                if (value >= 1)
                {
                    value = 1;
                }

                if (value <= 0)
                {
                    value = 0;
                }

                //Debug.Log("filterCutoff: " + value);
                helmController.SetParameterPercent(AudioHelm.Param.kFilterCutoff, value);
                cutOffChanged.Invoke(position.x);
            }
        }
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
                }
            } else {
                helmController.FrequencyOff(lastFrequency);
            }
        }
    }
}
