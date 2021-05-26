//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author : Shantel Williams
/// Date : 5/3/2021
/// File Name : StopSignHandler.cs
/// Description:
/// 
/// This file ws create to check if player Stops Completely at the posted stop signs. If the player succeds they will recieve one point toward the final score. If the fail to stop
/// They will not recieve any points on their score. This Class borrows functions and valuse from the CarController.cs file. 
///
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;


public class StopSignHandler : MonoBehaviour
{
   
    /// <summary>
    /// Attributes needed for this Class.
    /// </summary>
    public bool stopped = false;
    public string UserDidStopped;
    public TextMeshProUGUI Warning;
    ScoreManager scoremanager;


    private void Start()
    {
        Warning.enabled = false;
        scoremanager = GameObject.FindObjectOfType<ScoreManager>();
    }


    /// <summary>
    /// Update function to check if the car is on the trigger collider and came to a complete stop. A few debug strings are there as well becasue of problems.
    /// </summary>
    void Update()
    {
        if (stopped && UserDidStopped == "true")
        {
            scoremanager.IncrementScore();
            stopped = false;
            Warning.enabled = false;
            Debug.Log("Stopped");
        }


    }


    /// <summary>
    /// My on trigger events to check for the trigger collision and the players car. 
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            Warning.enabled = true;
            UserStopped();
            Debug.Log("Touching");
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            
            UserRanSign();
            Warning.enabled = false;
            Debug.Log("left Area!");

        }
    }

    /// <summary>
    /// Function to set stopped to true
    /// </summary>
    public void UserStopped()
    {
        stopped = true;
    }

    /// <summary>
    ///fuction to say user ran stop sign
    /// </summary>
    public void UserRanSign()
    {
        stopped = false;
    }

    /// <summary>
    /// function used to get true or false from CarController. It returns true or false in string type. 
    /// </summary>
    public string TheyStopped(string playMove)
    {
        UserDidStopped = playMove;
        return UserDidStopped;
    }

}
