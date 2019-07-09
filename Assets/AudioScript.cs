using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent (typeof(AudioSource))]
public class AudioScript : MonoBehaviour
{
    public GameObject synth;

    public AudioMixer audioMixer;

    public AudioHelm.HelmController helmController;

    private int indexCounter;

    private AudioSource _audioSource;
    public static float[] _samples = new float[512];
    float[] _freqBand = new float[8];
    float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

    float[] _freqBandHighest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];
    void Start()
    {
        //helmController.GetComponent<AudioSource>;
        _audioSource = this.GetComponent<AudioSource>();
        //helmController.GetComponent<AudioClip>()
        //_audioSource = helmController.GetComponent<AudioSource>();
        Debug.Log("AudioSource: " + _audioSource);
        indexCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {

        GetSpectrumAudioSource();
        MakeFrequencyBand();
        BandBuffer();
        CreatAudioBands();
    }

    void CreatAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (_freqBand[i] > _freqBandHighest[i])
            {
                _freqBandHighest[i] = _freqBand[i];
            }
            _audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);
        }

    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            if (_freqBand[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }
            if (_freqBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }

    }

	public void UpdateSampleArray(float value)
	{
        if (indexCounter == 512) indexCounter = 0;
        float v = value / 200;
        _samples[indexCounter] = v;
        indexCounter++;
	}

	void GetSpectrumAudioSource()
    {
        /*for (int i = 0; i < 512; i++) {
            _samples[i] = Random.Range(-1, 1);
        }*/
        //_audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
        //_audioSource.GetOutputData(_samples, 0);
    }
    void MakeFrequencyBand()
    {
        int count = 0;
        for(int i =0; i<8; i++)
        {
            float average = 0;

            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j<sampleCount; j++)
            {
                average += _samples[count] * (count +1);
                count++;
            }

            average /= count;

            _freqBand[i] = average * 10;
        }
    }
}