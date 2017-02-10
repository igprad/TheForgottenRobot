using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public int hit;
	public GameObject explosion;
	public GameObject playerExplosion;
    public GameObject itemBomb;
	public GameObject itemPowerUp;
    public AudioSource playerExplose;
	public int scoreValue;
	private Done_GameController gameController;
	private int counter = 0;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
        

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

        
	}

	void OnTriggerEnter (Collider other)
	{
		
		if (other.tag == "Boundary" || other.tag == "Enemy"||other.tag=="EnemyWithBomb")
		{
			return;
		}



		if (other.tag == "Bullet") {
			counter++;
			Destroy (other.gameObject);
		}
		if (counter == hit) {
			
			if (explosion != null) {
				Instantiate (explosion, transform.position, transform.rotation);
				if (this.tag == "EnemyWithBomb") {
					Instantiate (itemBomb, transform.position, transform.rotation);
				}
				if (this.tag == "EnemyWithPowerUp") {
					Instantiate (itemPowerUp, transform.position, transform.rotation);
				}
				gameController.AddScore (scoreValue);
				Destroy (gameObject);
                playerExplose.Play();
			}
		}
	

        if (other.tag == "Bomb")
        {

            Collider[] nearObjects = Physics.OverlapSphere(transform.position, 4f);

            foreach (Collider enemy in nearObjects)
            {
                if (enemy.tag != "Player" && enemy.tag != "Boundary")
                {
                    
                    Instantiate(explosion, enemy.transform.position, enemy.transform.rotation);
                    Destroy(enemy.gameObject);
                    
                }
                if (enemy.tag == "Enemy"||enemy.tag=="EnemyWithBomb") {
                    gameController.AddScore(scoreValue-10);
                }
            }
			Destroy (other.gameObject);
			Destroy (gameObject);
        }
		
	}
}