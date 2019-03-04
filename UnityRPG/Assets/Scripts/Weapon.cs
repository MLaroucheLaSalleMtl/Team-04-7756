using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private AttackControl attackControl;
    
    // Start is called before the first frame update
    void Start()
    {
        attackControl = GameObject.FindObjectOfType<AttackControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            attackControl.SwingSword();
        }
    }

}
