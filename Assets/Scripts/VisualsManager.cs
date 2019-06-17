using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualsManager : MonoBehaviour {

    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;

    Renderer renderer;

    private float frequency;
    private float cutOff;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
	}

    Color ColorFabric() {
        //Low freq is dark, high freq is light
        //CutOff not defined currently
        Color color = Color.red;
        return color;
    }
	
	// Update is called once per frame
	void Update () {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        renderer.material.SetColor("_Color", Color.Lerp(color1, color2, t));
	}

    public void OnFrequencyChange(float frequency) {
        this.frequency = frequency;
    }

    public void OnCutOffChanged(float cutOff) {
        this.cutOff = cutOff;
    }

    public void Bang() {
        
    }
}
