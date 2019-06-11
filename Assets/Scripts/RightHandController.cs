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
        
        if (controller.IsConnected) {
            Frame frame = controller.Frame();
            HandList hands = frame.Hands;
            //PointableList pointables = frame.Pointables;
            //FingerList fingers = frame.Fingers;
            //ToolList tools = frame.Tools;
            Hand rightHand = hands[1];
            if (rightHand.IsRight) {
                Vector position = rightHand.PalmPosition;

                float value = position.y;

                if (value < 0) {
                    value = value * -1;
                }

                value = value / 500;

                if (value >= 1) {
                    value = 1;
                }
                if (value <= 0) {
                    value = 0;
                }

                Debug.Log("filterCutoff: " + value);
                helmController.SetParameterPercent(AudioHelm.Param.kFilterCutoff, value);
            }
        }
	}
}
