using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{                                                   //https://www.youtube.com/watch?v=xenW67bXTgM&list=PLABNi09_T100WLygZj4cwADID6OIpat_6&index=5&t=785s
    public float speed;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Speed not found");

        }
        
    }
}
