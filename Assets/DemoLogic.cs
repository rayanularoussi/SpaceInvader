using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoLogic : MonoBehaviour
{
    public void ConsoleTest()
    {
        Debug.Log("ConsoleTest Invoked");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
