using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void LoadSceneByIndex(int i)
    {
        Debug.Log("reset time");
        //Time.timeScale = 1.0f;
        SceneManager.LoadScene(i);
    }
}
