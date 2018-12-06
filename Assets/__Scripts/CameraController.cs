using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera cam1 = GetComponent <Camera> ();
        cam1.orthographic = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
