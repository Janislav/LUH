using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (Light))]

public class LightBu : MonoBehaviour
{


    public int _band;
    public float _minIntensity, _maxIntensity;
    Light _light;
    // Start is called before the first frame update
    void Start()
    {

        _light = GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {

       this._light.intensity = (AudioScript._audioBandBuffer[_band] * (_maxIntensity - _minIntensity)) + _minIntensity;
 
    }
}
