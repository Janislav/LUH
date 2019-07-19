using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startscale, _scaleMultiplier;
    public bool _useBuffer;
    Material _material;
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioScript._audioBandBuffer[_band] * _scaleMultiplier) + _startscale, transform.localScale.z);
            Color _color = new Color(AudioScript._audioBandBuffer[_band], AudioScript._audioBandBuffer[_band], AudioScript._audioBandBuffer[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
        if (!_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioScript._audioBand[_band] * _scaleMultiplier) + _startscale, transform.localScale.z);
            Color _color = new Color(AudioScript._audioBand[_band], AudioScript._audioBand[_band], AudioScript._audioBand[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
    }
}
