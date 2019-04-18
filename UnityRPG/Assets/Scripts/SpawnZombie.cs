using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private float xPos;
    private float zPos;
    private int numberEnemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Zombie").Length < 12)
        {
            SpawnEnemy();
        }


    }

    public void SpawnEnemy()
    {
        xPos = Random.Range(10, 96);
        zPos = Random.Range(39, 92);
        Instantiate(enemy, new Vector3(xPos, 15, zPos), Quaternion.identity);
    }
}
