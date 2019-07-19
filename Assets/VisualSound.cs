using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualSound : MonoBehaviour
{
    private const int SAMPLE_SIZE = 1024;



    public float rmsValue;

    public float dbValue;

    public float pitchValue;

    private int indexCounter = 0;

    public float backgroundIntensity;

    public Material backgroundMaterial;

    public Color minColor;

    public Color maxColor;

 

  public float maxVisualScale = 25.0f;

    public float visualModifier = 50.0f;

    public float smoothSpeed = 10.0f;

    public float keepPercentage = 0.5f;



    private AudioSource source;

    private float[] samples;

    private float[] spectrum;

    private float sampleRate;



    private Transform[] visualList;

    private float[] visualScale;

    private int amVisual = 64;



    private void Start()
    {



        source = GetComponent<AudioSource>();

        samples = new float[SAMPLE_SIZE];

        spectrum = new float[SAMPLE_SIZE];

        sampleRate = AudioSettings.outputSampleRate;



        //SpawnLine();

        SpawnCircle();



    }



    private void SpawnCircle()
    {



        visualScale = new float[amVisual];

        visualList = new Transform[amVisual];



        //Vector3 center = Vector3.zero;



        float radius = 10.0f;



        for (int i = 0; i < amVisual; i++)
        {



            float ang = i * 1.0f / amVisual;

            ang = ang * Mathf.PI * 2;



            //float x = center.x + Mathf.Cos(ang) * radius;
            float x = this.transform.position.x + Mathf.Cos(ang) * radius;

            //float y = center.y + Mathf.Sin(ang) * radius;
            float y = this.transform.position.y + Mathf.Sin(ang) * radius;



            Vector3 pos = this.transform.position + new Vector3(x, 0, y);

            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;

            go.transform.position = pos;

            go.transform.rotation = Quaternion.LookRotation(Vector3.forward, pos);

            visualList[i] = go.transform;



        }



    }





    private void SpawnLine()
    {





        visualScale = new float[amVisual];

        visualList = new Transform[amVisual];



        for (int i = 0; i < amVisual; i++)
        {



            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;

            visualList[i] = go.transform;

            visualList[i].position = Vector3.right * i;



        }



    }



    private void Update()
    {



        AnalyzeSound();

        UpdateVisual();

        UpdateBackground();



    }





    private void UpdateBackground()
    {





        backgroundIntensity -= Time.deltaTime * smoothSpeed;

        if (backgroundIntensity < dbValue/40)

            backgroundIntensity = dbValue/40;





        backgroundMaterial.color = Color.Lerp(maxColor, minColor, -backgroundIntensity);



    }



    private void UpdateVisual()
    {



        int visualIndex = 0;

        int spectrumIndex = 0;

        int averageSize = (int)((SAMPLE_SIZE * keepPercentage) / amVisual);



        while (visualIndex < amVisual)
        {



            int j = 0;

            float sum = 0;

            while (j < averageSize)
            {



                sum += spectrum[spectrumIndex];

                spectrumIndex++;

                j++;



            }



            float scaleY = sum / averageSize * visualModifier*5;

            visualScale[visualIndex] -= Time.deltaTime * smoothSpeed;

            if (visualScale[visualIndex] < scaleY)
            {



                visualScale[visualIndex] = scaleY;

            }



          /*  if (visualScale[visualIndex] > maxVisualScale)
            {

                visualScale[visualIndex] = maxVisualScale;

            }*/



            //visualList[visualIndex].localScale = Vector3.one + Vector3.up * visualScale[visualIndex];
            visualList[visualIndex].localScale = Vector3.up + new Vector3(0,scaleY,0);

            visualIndex++;



        }





    }

    public void UpdateSampleArray(float value)
    {
        if (indexCounter == SAMPLE_SIZE) indexCounter = 0;
        float v = value;
        samples[indexCounter] = v;
        spectrum[indexCounter] = v;
        indexCounter++;
    }

    private void AnalyzeSound()
    {





        //source.GetOutputData(samples, 0);



        //get the RMS



        int i = 0;

        float sum = 0;

        for (; i < SAMPLE_SIZE; i++)
        {

            sum = samples[i] * samples[i];





        }

        rmsValue = Mathf.Sqrt(sum / SAMPLE_SIZE);



        //get the db value



        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);



        //get the Sound Spectrum



        //source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);





    }
}
