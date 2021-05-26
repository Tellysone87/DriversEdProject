//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author : Shantel Williams
/// Date : 5/3/2021
/// File Name : YouWinVideoManager.cs
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

public class YouWinVideoManager : MonoBehaviour
{
    VideoPlayer video;

    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();// grabs video player
        Debug.Log(video.frameCount); // displasy frames in total to the console. read only
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(video.frameCount);
        if (video.frame == 80) // if the vidoe is at the last frame then....
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// Loads next scene
        }
    }
}
