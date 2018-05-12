
using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(AudioSource))]

public class AudioRecorder : MonoBehaviour
{
    public enum RecordingState { Stop = 0, Prepare, Sleep, Record }

    public GameObject BubblePrefabRef;
    public float soundThreshold;

    GameObject SpawnedBubble;
    int frequency = 44100;
    int timeForRecording = 600;
    float currentFrameAverage;

    private AudioSource _sourceRecording;
    private RecordingState _state = RecordingState.Stop;
    private float[] _clipSampleData = new float[1024];
    private float _time = 0f;
    private int _frequency = 16000;
    private string _micName; //name of the mic

    public bool NearLips;

    void Awake() //Awake is called when the script instance is being loaded. it is used to initialize anything
    {
        _sourceRecording = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartRecording();
        SpawnedBubble = Instantiate(BubblePrefabRef, gameObject.transform.position, gameObject.transform.rotation);
    }

    void Update()
    {
        currentFrameAverage = 0f;

        if (_state != RecordingState.Stop)
        {
            currentFrameAverage = GetCurrentFrameAverage();

            if (_state == RecordingState.Sleep)
            {
                //Debug.Log(currentFrameAverage);
                if (currentFrameAverage > soundThreshold) //if player voice value exceeds a certain value
                {
                    _state = RecordingState.Record;
                }
            }
            if (_state == RecordingState.Record)
            {
              if (SpawnedBubble.GetComponent<BubbleSizeBehavior>().Detached)
              {
                    if (NearLips)
                    {
                        SpawnedBubble = Instantiate(BubblePrefabRef, gameObject.transform.position, gameObject.transform.rotation); //spawns bubble at location
                        SpawnedBubble.GetComponent<BubbleSizeBehavior>().BlowStick = gameObject;
                        //stop recording immediately after 1 bubble spawn
                    }

                }
                if (NearLips)
                {
                    if (!SpawnedBubble.GetComponent<BubbleSizeBehavior>().Detached)
                    {
                        SpawnedBubble.GetComponent<BubbleSizeBehavior>().IncreaseSizeOnAction();
                    }
                }

              StopRecording();
            }
        }
    }

    public bool StartRecording()
    {
        if (Microphone.devices.Length < 1) //checks if microphone connected
        {
            Debug.LogWarning("Microphone was not found");
            return false;
        }

        _micName = Microphone.devices[0]; //sets the mic name

        _frequency = Mathf.Clamp(frequency, 100, 44100);

        _sourceRecording.clip = Microphone.Start(_micName, false, timeForRecording, _frequency); //records from microphone and store it as audio clip
        while (Microphone.GetPosition(_micName) <= 0) { }
        _state = RecordingState.Sleep;
        _sourceRecording.Play();
        return true;
    }

    public void StopRecording()
    {
        if (Microphone.devices.Length < 1)
            return;

        _state = RecordingState.Stop; //reset the state of recording

        Microphone.End(_micName);
        _sourceRecording.Stop();
        if (_sourceRecording.clip != null) //if there is some audio in the clip then destroy it
            Destroy(_sourceRecording.clip);
        StartRecording(); //starts recording again
    }

    public float GetCurrentFrameAverage() //calculates the average of the sounddata
    {
        if (_sourceRecording != null)
        {
            _sourceRecording.GetSpectrumData(_clipSampleData, 0, FFTWindow.Rectangular); //Provides a block of the currently playing audio source's spectrum dat
            foreach (var v in _clipSampleData)
                currentFrameAverage += Mathf.Abs(v);
            currentFrameAverage = currentFrameAverage / _clipSampleData.Length * 1000;
            return currentFrameAverage;
        }
        return 0f;
    }
}
