using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchScene();
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
