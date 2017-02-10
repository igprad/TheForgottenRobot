using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private UnitySampleAssets._2D.PlatformerCharacter2D playerController;

	// Use this for initialization
	void Start () {
		playerController = FindObjectOfType<UnitySampleAssets._2D.PlatformerCharacter2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
        CoreGame.health = 100;
		Debug.Log ("Player Respawn");
		playerController.transform.position = currentCheckpoint.transform.position;
	}
}
