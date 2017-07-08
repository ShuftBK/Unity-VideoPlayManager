using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer videoImage;
    public VideoPlayer videoImage_rev;
    public GameObject debugUI;
    [Range(-5.0f, 5.0f)]
    public float SpeedControl = 1.0f;

    public Texture VideoRenderTexture_rev;

    public float LPF = 2000;
    float v1frame;
    float v1time;

    float starttime;

    // Use this for initialization
    void Start()
    {
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (videoImage.frame <= LPF)
        {
            SpeedControl = (float)(1 + 0.1 * (Time.time - starttime));
            v1frame = SpeedControl;
            v1time = Time.time;
        }
        else
        {
            SpeedControl = v1frame - (float)(1 + 0.1 * (Time.time - v1time));
        }

        if (SpeedControl <= 0)
        {
            videoImage_rev.GetComponent<VideoPlayer>().Play();
            GetComponent<RawImage>().enabled = false;
            SpeedControl = 0;
            videoImage.Stop();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (videoImage.isPlaying == true)
                videoImage.Pause();
            else
                videoImage.Play();
        }
        videoImage.playbackSpeed = SpeedControl;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            videoImage.frame++;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            videoImage.StepForward();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            videoImage.frame--;
        }

        debugUI.GetComponent<Text>().text = "Frame : " + videoImage.frame.ToString() + "\n" + "Frame Rate : " + videoImage.frameRate.ToString() + "\n" + "Frame Count : " + videoImage.frameCount.ToString() + "\n" + "Frame Rate : " + videoImage.frameRate.ToString() + "\n" + "time Count : " + videoImage.time.ToString() + "\n" + "Frame Rate : " + videoImage.timeSource.ToString();
    }
}
