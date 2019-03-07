using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlescript : MonoBehaviour {

    [SerializeField] private Vector3 speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(speed * Time.deltaTime);
	}
}
