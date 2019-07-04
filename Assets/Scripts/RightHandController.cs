using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Leap;

public class RightHandController : MonoBehaviour {

    private Controller controller;
    public AudioHelm.HelmController helmController;
    Gestures gestures;

    public Text console;

    private int state;

    Hand getRightHand(HandList hands)
    {
        if (hands.IsEmpty)
        {
            return null;
        }

        if (hands.Count == 1)
        {
            if(hands[0].IsRight && hands[0].IsValid) {
                return hands[0];
            } else {
                return null;
            }
        }

        if(hands.Count > 1) {
            foreach(Hand hand in hands) {
                if(hand.IsRight && hand.IsValid) {
                    return hand;
                }
            }
        }

        return null;
    }

	// Use this for initialization
	void Start () {
        controller = new Controller();
        gestures = new Gestures();
        state = 0;
        helmController.SetParameterValue(AudioHelm.Param.kArpOn, 1);
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.IsConnected) {
            Frame frame = controller.Frame();
            HandList hands = frame.Hands;

            Hand rightHand = getRightHand(hands);

            if(rightHand != null) {
                
                Debug.Log("Right hand entered the room");
                Debug.Log("Current Mode: " + state);
                Vector position = rightHand.PalmPosition;

                float value = position.y;

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
                
                //Reverb
                if(state == 0) {
                    Debug.Log("Reverb: " + value);
                    helmController.SetParameterValue(AudioHelm.Param.kMonoLfo1Tempo, value);
                    //helmController.SetParameterPercent(AudioHelm.Param.kDelayFeedback, value);
                }

                //Arp
                if(state == 1) {
                    Debug.Log("Arp: " + value);
                    helmController.SetParameterPercent(AudioHelm.Param.kArpTempo, value);
                }

                if(gestures.isPointer(rightHand)) {
                    if(state != 0) {
                        console.text = "Reverb Mode";
                    }
                    state = 0;
                }

                if(gestures.isPeace(rightHand)) {
                    if (state != 1) {
                        console.text = "Arp Mode";
                    }
                    state = 1;
                }
            }
        }
	}
}
