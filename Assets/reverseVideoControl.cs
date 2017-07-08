using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class reverseVideoControl : MonoBehaviour
{

    public VideoPlayer videoImage;
    public VideoPlayer videoImage_rev;
    [Range(-5.0f, 5.0f)]
    public float SpeedControl = 1.0f;

    public float LPF = 2000;
    float v1frame;
    float v1time;

    float starttime;
    // Use this for initialization
    void Start()
    {
        videoImage_rev.frame = (long)videoImage_rev.frameCount - 2941;
        videoImage_rev.Pause();
    }

    public void playingvideo()
    {
        videoImage_rev.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
