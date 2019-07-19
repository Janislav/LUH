using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualsManager : MonoBehaviour {

    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public GameObject pointLight;

    private Color tempColor;
    private bool toogle;

    public float duration = 1.0F;

    Renderer renderer;

    private float frequency;
    private float cutOff;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        toogle = true;
	}

    Color ColorFabric() {
        //Low freq is dark, high freq is light
        //CutOff not defined currently

        int cc1 = (int) frequency;
        int cc2 = ((int) cutOff) + 100;

        if(cc1 < 0) {
            cc1 = 0;
        }

        if(cc1 >= 255) {
            cc1 = 255;
        }

        if (cc2 < 0) {
            cc2 = 0;
        }

        if (cc2 >= 255) {
            cc2 = 255;
        }

        int cc3 = Random.Range(cc1, cc2);

        Color color = new Color32((byte) cc1, (byte) cc2, (byte) cc3, 255);
        return color;
    }
	
	// Update is called once per frame
	void Update () {
        float t = Mathf.PingPong(Time.time, duration) / duration;

        if (toogle)
        {
            color1 = ColorFabric();
            toogle = false;
        }
        else
        {
            color2 = ColorFabric();
            toogle = true;
        }
        renderer.material.color = Color.Lerp(color1, color2, t);
	}

    public void OnFrequencyChange(float frequency) {
        Debug.Log("Got fr for: " + this.gameObject.name);
        this.frequency = frequency;
    }

    public void OnCutOffChanged(float cutOff) {
        this.cutOff = cutOff;
    }

    public void Bang() {
        if(pointLight != null) {
            if (pointLight.GetComponent<Light>().enabled)
                pointLight.GetComponent<Light>().enabled = false;
            else
                pointLight.GetComponent<Light>().enabled = true;
        }
    }
}
