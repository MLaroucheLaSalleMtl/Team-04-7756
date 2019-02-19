using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PreLoadScene();
    }

    public void PreLoadScene()
    {
        if (async == null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
            async.allowSceneActivation = false;
        }
    }

    public void StartGame()
    {
        async.allowSceneActivation = true;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
