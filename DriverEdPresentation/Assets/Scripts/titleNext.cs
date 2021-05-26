//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author : Shantel Williams
/// Date : 5/3/2021
/// File Name : titleNext.cs
/// Description:
/// 
/// This file was created to prompt trnsistion and the next scene if player Selected the assigned button.
///
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class titleNext : MonoBehaviour
{
    public Animator transition;// transiton object

    public void nextScene()
    {
        StartCoroutine(LoadFadeScene());
    }

    /// <summary>
    /// Function is called if player Selects the quit button
    /// </summary>
    public void quitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit(); // quits editor application
    }
    
    /// <summary>
    /// Function calls the transition and next scene .
    /// </summary>
  IEnumerator LoadFadeScene()
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads next scene
    }
}
