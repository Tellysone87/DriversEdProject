///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////  Author: Shantel Williams
////  Date : 4/1/2021
////  File Name: Dialogue.cs
////
////  Description : This script wa created to display speech text across game Screen. 
////  It takes and array of snetences to display direction to the player.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Takes the speech object on which the text will display
    public string[] sentences; // Array if Sentences
    private int index; // Array I ndex  
    public float typingSpeed; // speed in which sneces will display across board

    public GameObject continueButton; // Button to press when wanting to continue
    public GameObject Canvas; // Which canvas for speech
    public Animator anim; // Animator to use. I used this to play the beginning camera animation
    

    private void Start()
    {
        StartCoroutine(Type());
    }

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads next scene
    }

    private void Update()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// Checking to see if there are more sentences in the array, If this case is true, The continue button will be present to press//
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true); // display continue button
        }

    }
    IEnumerator Type()
    {
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// this condition give a typing animation when displaying the text. Just a little neat animation. //
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);  // Displays text letter by letter determined by typing speed.

        }
    }

    public void NextSentence() 
    {

        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            Canvas.SetActive(false);
            anim.Play("CameraZoom");
            textDisplay.text = "";
            nextScene();
        }
    }
}


