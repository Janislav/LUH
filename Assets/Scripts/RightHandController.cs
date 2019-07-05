using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Leap;

public class RightHandController : MonoBehaviour {

    private Controller controller;
    public AudioHelm.HelmController helmController;
    Gestures gestures;
    private LeapAPI leapAPI;
    public Text console;
    private int state;

	// Use this for initialization
	void Start () {
        controller = new Controller();
        gestures = new Gestures();
        leapAPI = new LeapAPI();
        state = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.IsConnected) {
            Frame frame = controller.Frame();
            HandList hands = frame.Hands;

            Hand rightHand = leapAPI.GetRightHand(hands);

            if(rightHand != null) {
                
                Debug.Log("Right hand entered the room");
                Debug.Log("Current Mode: " + state);
                Vector position = rightHand.PalmPosition;

                float value = position.y;

                if (value < 0) {
                    value = value * -1;
                }

                value = value / 300;

                if (value >= 1) {
                    value = 1;
                }

                if (value <= 0) {
                    value = 0;
                }

                if (gestures.isPointer(rightHand)) {
                    Debug.Log("Reverb: " + value);
                    console.text = "Reverb Mode";
                    helmController.SetParameterValue(AudioHelm.Param.kReverbDryWet, value);
                    return;
                }

                if (gestures.isPeace(rightHand)) {
                    console.text = "Modulation Mode";
                    Debug.Log("Modulation: " + value);
                    helmController.SetParameterPercent(AudioHelm.Param.kMonoLfo1Tempo, value);
                    return;
                }

                console.text = "Right hand no mode";
            }
        }
	}
}
