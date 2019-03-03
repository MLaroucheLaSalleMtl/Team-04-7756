using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    [SerializeField] private GameObject movePlatform;

    private void OnTriggerStay(Collider other)
    {
        movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
