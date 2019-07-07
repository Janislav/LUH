using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instaniate512cube : MonoBehaviour
{
    public float _maxScale;
    public GameObject _samplecubePrefab;
    GameObject[] _sampelCube = new GameObject[256];
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<256; i++)
        {
            GameObject _insttanceSampleCube = (GameObject)Instantiate(_samplecubePrefab);
            _insttanceSampleCube.transform.position = this.transform.position;
            _insttanceSampleCube.transform.parent = this.transform;
            _insttanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -1.40625f * i,0);
            _insttanceSampleCube.transform.position = Vector3.forward * 50;
            _sampelCube[i] = _insttanceSampleCube;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i < 256; i++)
        {
            if(_sampelCube != null)
            {
                _sampelCube[i].transform.localScale = new Vector3(10, (AudioScript._samples[i] * _maxScale ) + 2  , 10);
            }
        }
    }
}
