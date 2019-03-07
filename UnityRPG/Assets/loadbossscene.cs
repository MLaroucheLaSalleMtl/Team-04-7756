using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadbossscene : MonoBehaviour
{
    private AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (async == null)
            {
                Scene currentScene = SceneManager.GetActiveScene();
                async = SceneManager.LoadSceneAsync("Terrain");
                async.allowSceneActivation = true;
            }
        }
    }
}
