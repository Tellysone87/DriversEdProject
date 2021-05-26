//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author : Shantel Williams
/// Date : 5/3/2021
/// File Name : ArrayList.cs
/// Description:
/// 
/// This file was created to display the traffic signa and instruction via an array. 
/// 
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////






using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArraysLists : MonoBehaviour
{

    // Set up Text fields
    public Text displayTitle;
    public Text displayInstruction;
    public RawImage theImages;


    

    // Set up string Arrays
    public string[] title = { "Stop Sign", "Yield Sign", "Traffic Lights" };
    public string[] Instruction = {"A sign telling drivers to stop and wait until they can continue safely.",
        "At a yield sign, drivers must slow down and yield the right-of-way to pedestrians and vehicles that are approaching from another direction.",
        "Red light on: This tells drivers to stop. " +
        "Green light on: This means the driver can start driving or keep driving. " +
        "Yellow light on: This tells drivers to stop when it is safe to, because the light is about to turn red."};

    //public Image sign Photos;
    public Texture[] myTextures = new Texture[3];

    private int currentItem = 0;


    // Start is called before the first frame update
    void Start()
    {
        ShowItems();
    }

    public void ShowItems()
    {
        DisplayItems();
    }

    /// <summary>
    /// Goes forward for the array. Designed for the forward button.
    /// </summary>
    public void GoForward()
    {
        currentItem++;
        if (currentItem > title.Length - 1)
        {
            currentItem = 0;
        }

        DisplayItems();

        Debug.Log(title[currentItem]);
    }

    /// <summary>
    /// Reverses item in the array. Designed for the back button.
    /// </summary>
    public void GoBack()
    {
        currentItem--;
        if (currentItem < 0)
        {
            currentItem = title.Length - 1;
        }

        DisplayItems();

        Debug.Log(title[currentItem]);
    }


    /// <summary>
    /// Function displays the current image  and text in the arrays.
    /// </summary>
    public void DisplayItems()
    {
        displayTitle.text = title[currentItem];
        displayInstruction.text = Instruction[currentItem];
        theImages.texture = myTextures[currentItem];
    }

    /// <summary>
    /// loads next scene
    /// </summary>
    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads next scene
    }
}
