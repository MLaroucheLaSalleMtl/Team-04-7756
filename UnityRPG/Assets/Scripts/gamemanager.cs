using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    private AsyncOperation async;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject MaskPanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PausePanel.SetActive(true);
        MaskPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        PausePanel.SetActive(false);
        MaskPanel.SetActive(true);
    }

    public void ReturnToMenu()
    {
        async = SceneManager.LoadSceneAsync(0);
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel")){
            PauseGame();
        }
    }
}
