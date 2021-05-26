//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author : Shantel Williams
/// Date : 5/3/2021
/// File Name : VideoManager.cs
/// Description:
/// 
/// This file was created to called next scene after my video is finished playing.
///
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    VideoPlayer video;

    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>(); // Grabs videoPlayer
        Debug.Log(video.frameCount); // displays the video frames in total. Read only
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(video.frameCount);
        if (video.frame == 78) // if video is at the last frame then.....
        {
            SceneManager.LoadScene("TitleScreen"); // Loads next scene
        }
    }
}
