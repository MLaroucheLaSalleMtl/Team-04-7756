using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    private AsyncOperation async;
    private bool isPaused = false;
    public bool isGainXP = false;
    [SerializeField] private Player tp;
    [SerializeField] private Enemy en;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject MaskPanel;
    [SerializeField] private GameObject GameoverPanel;

    // Start is called before the first frame update
    void Start()
    {
        tp = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        en = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
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
        isPaused = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PausePanel.SetActive(false);
        MaskPanel.SetActive(true);
    }

    public void ReturnToMenu()
    {
        async = SceneManager.LoadSceneAsync(0);
        async.allowSceneActivation = true;
    }

    public void Restart()
    {
        tp.Health = 500;
        tp.Mana = 200f;
        tp.Stamina = 100f;
        PausePanel.SetActive(false);
        RestartGame();
        async.allowSceneActivation = true;
        Time.timeScale = 1;
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
        PausePanel.SetActive(false);
        MaskPanel.SetActive(true);
    }

    public void RestartGame()
    {
        if (async == null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync(currentScene.buildIndex);
        }
    }

    public void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        GameoverPanel.SetActive(true);
    }

    //public void GainXP()
    //{
    //    tp.experience++;
    //    isGainXP = false;
    //}

    //public void LevelUp()
    //{
    //    tp.maxHp += 25;
    //    tp.maxMana += 20;
    //    tp.Health = tp.maxHp;
    //    tp.Damage += 10;
    //    tp.Level++;
    //}

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
        if (Input.GetButton("Cancel") && isPaused == false && tp.gameover == false){
            PauseGame();
            isPaused = true;
        }
        //if (Input.GetButton("Cancel") && isPaused == true)
        //{
        //    ResumeGame();
        //}
        
        if(tp.gameover)
        {
            GameOver();
        }

        //if (tp.experience != 0 && tp.experience % 10 == 0)
        //{
        //    LevelUp();
        //}
        //if (isGainXP)
        //{
        //    GainXP();
        //}
        //Debug.Log(tp.experience);
    }
}
