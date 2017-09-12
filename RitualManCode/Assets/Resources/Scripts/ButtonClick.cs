using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    // Handles all behaviors of clicking buttons in the game

    public void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void clickStart()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void clickContinue()
    {
        SceneManager.LoadScene("_Scene");
    }

    public void clickQuit()
    {
        Application.Quit();
    }

    public void playAgain()
    {
        SceneManager.LoadScene("Main Screen");
    }
}