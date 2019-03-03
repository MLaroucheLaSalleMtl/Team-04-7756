using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimForCamera : MonoBehaviour {

    private Camera cam;
    [SerializeField] private Transform target;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(pos);
        target.position = ray.GetPoint(100);
	}
}
