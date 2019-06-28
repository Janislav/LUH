using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    float moveX;
    float moveZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        moveX = 0.5f * Time.deltaTime + moveX;
        moveZ = 0.5f * Time.deltaTime + moveZ;
        if (moveX > 1) moveX = 0;
        if (moveZ > 1) moveZ = 0;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector3(moveZ, moveX, moveZ);
    }
}
