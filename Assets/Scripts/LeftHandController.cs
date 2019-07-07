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

    private LeapAPI leapAPI;

    private float lastFrequency;
    private int lastNote = 0;

	// Use this for initialization
	void Start () {
        controller = new Controller();
        scale = new Scale();
        scale.setScale("CMajor");
        gestures = new Gestures();
        leapAPI = new LeapAPI();
	}

	void Update() {
        if (controller.IsConnected) {

            Frame frame = controller.Frame();
            HandList hands = frame.Hands;
            Hand leftHand = leapAPI.GetLeftHand(hands);


            if (leftHand != null)
            {
                Vector position = leftHand.PalmPosition;

                float value = position.x;

                if (value < 0)
                {
                    value = value * -1;
                }

                value = value / 300;

                if (value >= 1)
                {
                    value = 1;
                }

                if (value <= 0)
                {
                    value = 0;
                }

                helmController.SetParameterPercent(AudioHelm.Param.kFilterCutoff, value);
                cutOffChanged.Invoke(position.x);
            }
        }
	}

	public void Bang() {
        if (controller.IsConnected) {
            Frame frame = controller.Frame();
            HandList hands = frame.Hands;
            Hand leftHand = leapAPI.GetLeftHand(hands);
            if (leftHand != null) {
                Vector position = leftHand.PalmPosition;
                if(gestures.isFist(leftHand)) {
                    helmController.NoteOn(lastNote, 1, 1);
                } else {
                    int note = scale.generateNote((int)position.y) + 40;
                    int noteInKey = scale.getNextNoteInKey(note);
                    helmController.NoteOn(noteInKey, 1, 1);
                    lastNote = noteInKey;
                }
            }
        }
    }
}
