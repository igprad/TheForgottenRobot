using UnityEngine;
using System.Collections;

public class SFXControl : MonoBehaviour {
    public AudioSource bunyi;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySoundHover()
    {
        bunyi.Play();
    }
}
