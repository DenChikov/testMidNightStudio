using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public void ChangeScene(int sceneId)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneId);
    }
    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
