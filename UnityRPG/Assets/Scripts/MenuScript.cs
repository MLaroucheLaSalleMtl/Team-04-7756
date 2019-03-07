using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private string difficulties;
    private AsyncOperation async;
    [SerializeField] GameObject SettingPanel;
    [SerializeField] private Dropdown diffDropdown;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(difficulties);
        PreLoadScene();
    }

    public void PreLoadScene()
    {
        if (async == null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync("SampleTerrain");
            async.allowSceneActivation = false;
            //if (difficulties == "Easy")
            //{                
            //    async = SceneManager.LoadSceneAsync("Easy");
            //    async.allowSceneActivation = false;
            //}
            //if (difficulties == "Medium")
            //{                
            //    async = SceneManager.LoadSceneAsync("Medium");
            //    async.allowSceneActivation = false;
            //}
            //if (difficulties == "Hard")
            //{                
            //    async = SceneManager.LoadSceneAsync("Hard");
            //    async.allowSceneActivation = false;
            //}
        }
    }

    public void StartGame()
    {
        async.allowSceneActivation = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SetDifficulties()
    {
        if (diffDropdown.value == 0)
        {
            this.difficulties = "Easy";
        }
        if (diffDropdown.value == 1)
        {
            this.difficulties = "Medium";
        }
        if (diffDropdown.value == 2)
        {
            this.difficulties = "Hard";
        }
        
    }
}
