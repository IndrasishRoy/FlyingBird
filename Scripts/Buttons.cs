using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameScene()
    {
        Debug.Log("Interacted!");
        SceneManager.LoadScene(1);
    }
}
