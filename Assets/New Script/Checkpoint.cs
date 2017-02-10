using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    private int tempCounter = 0;

    public AudioSource checkPointSound;
	public LevelManager levelManager;
    public static bool cekAlive = false;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
            if (cekAlive == true)
            {
                checkPointSound.Play();
                cekAlive = false;
            }
			levelManager.currentCheckpoint = gameObject;
		}
	}

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            Checkpoint.cekAlive = true;
        }
    }
}
