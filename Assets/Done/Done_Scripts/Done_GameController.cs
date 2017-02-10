using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject btnPlayAgain;

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
    public GUIText bombtext;
	public GUIText liveText;
	
	private bool gameOver;
	private bool restart;
    private int bomb;
	private int score;
	private int live;
	private Done_PlayerController playerController;
	
	void Start ()
	{
		btnPlayAgain.SetActive(false);

		GameObject playerControllerObject = GameObject.FindGameObjectWithTag ("Player");


		if (playerControllerObject != null)
		{
			playerController = playerControllerObject.GetComponent <Done_PlayerController>();
		}
		if (playerController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}


		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		live = playerController.Live;
		UpdateLive (live);
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

    public void UpdateBomb(int bomb) {
        bombtext.text = "Bomb: " + bomb;
    }

	public void UpdateLive(int live) {
		liveText.text = "Live: " + live;
	}
	
	public void GameOver ()
	{
		btnPlayAgain.SetActive(true);
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}