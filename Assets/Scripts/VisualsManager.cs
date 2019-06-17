using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualsManager : MonoBehaviour {

    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;
    //public Camera cam;
    Renderer renderer;

	// Use this for initialization
	void Start () {
        //cam = GetComponent<Camera>();
        //cam.clearFlags = CameraClearFlags.SolidColor;
        renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        renderer.material.SetColor("_Color", Color.Lerp(color1, color2, t));
	}

    public void Bang() {
        /*float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(color1, color2, t);*/
    }
}
