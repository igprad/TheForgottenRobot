using UnityEngine;
using System.Collections;

public class Done_UINav : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playAgain() {
        Application.LoadLevel("Done_Main");
    }
}
