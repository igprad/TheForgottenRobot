using UnityEngine;
using System.Collections;

public class ScreenResolution : MonoBehaviour {
    public Camera Cam1;

	// Use this for initialization
	void Start () {
        Cam1.aspect = (Screen.currentResolution.width*1.12f / Screen.currentResolution.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
