//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author : Shantel Williams
/// Date : 5/3/2021
/// File Name : ScoreManager.cs
/// Description:
/// 
/// This file ws create to increment the score counter when the function is called by a StopSignHandler object.
///
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Variables for this class
    /// </summary>
    public Text scoreText;

    private int score = 0;

    public string UserDidStopped;

    public void Update()
    {
        if(score == 2)// This is the current max score
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads next scene which is the You Win scene
        }
    }

    /// <summary>
    /// This function actually increments the score. 
    /// </summary>
    public void IncrementScore()
    {
        score = score +1;
        scoreText.text = score.ToString();
        Debug.Log("Recognizing these points + / " + score);
    }

    /// <summary>
    /// This fucnction checks to see if player stops. I ended up not using this fuction. It is used in StopSignHandler functions.
    ///// </summary>
    //public string TheyStopped(string playMove)
    //{
    //    UserDidStopped = playMove;
    //    return UserDidStopped;
    //}
}
