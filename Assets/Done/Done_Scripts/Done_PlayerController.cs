using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	private bool isShotNormal = false;
    private bool isShotBomb = false;
    private float horizontal=0;
    private float vertical=0;
	public float obah;
	
	public float speed;
	public float tilt;
	public int Live;
	public Done_Boundary boundary;

	public GameObject playerExplosion;
	public GameObject shot;
    public GameObject BombShot;
    public AudioSource bombsound;
	public Transform shotSpawn;

	public Transform shotSpawn1;
	public Transform shotSpawn2;


    public Transform bombSpawn;
	public float fireRate;
    public float fireRateBomb;

    private int countBombshot=0;
	private int counter = 0;
	private int liveCount=0;
	private int statusPowerUp = 0;

	private float nextFire;
    private Done_GameController gameController;
    void Start() {

		liveCount = Live;
        
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire&&isShotNormal==true) 
		{
			if (statusPowerUp == 0) {
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
			} else if (statusPowerUp == 1) {
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn1.position, shotSpawn.rotation);
				Instantiate (shot, shotSpawn2.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
			}
		}

        if (Input.GetButton("Fire1") && Time.time > nextFire && countBombshot > 0 && isShotBomb == true)
        {
            nextFire = Time.time + fireRateBomb;
            Instantiate(BombShot, bombSpawn.position, bombSpawn.rotation);
            bombsound.Play();
            countBombshot--;
            gameController.UpdateBomb(countBombshot);
        }

        gameController.UpdateBomb(countBombshot);
	}

	void FixedUpdate ()
	{
        //float moveHorizontal = Input.GetAxis ("Horizontal");
        //float moveVertical = Input.GetAxis ("Vertical");

        float moveHorizontal = horizontal;
        float moveVertical = vertical;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

    public void AddBombCount() {
        this.countBombshot++;
    }

	public void getPowerUp()
	{
		this.statusPowerUp = 1;
	}


	void OnTriggerEnter (Collider other)
	{
	

		if (other.tag == "Boundary")
		{
			return;
		}

		if (other.tag == "Enemy" || other.tag == "EnemyWithPowerUp" || other.tag=="EnemyWithBomb" ) {
			if (playerExplosion != null) {
				Instantiate (playerExplosion, transform.position, transform.rotation);
				Destroy (other.gameObject);
				Destroy (gameObject);
				gameController.GameOver ();
                
			}
            
		}


		if (other.tag == "EnemyBullet") {
			counter++;
			Destroy (other.gameObject);

			if(counter==Live)
			{
				if (playerExplosion != null) {
					Instantiate (playerExplosion, transform.position, transform.rotation);
					Destroy (other.gameObject);
					Destroy (gameObject);
					gameController.GameOver ();
                   
				}
			}
			liveCount--;
			gameController.UpdateLive (liveCount);
		}


	}



	public void setIsShotNormalTrue() {
        this.isShotNormal = true;
    }
    public void setIsShotNormalFalse() {
        this.isShotNormal = false;
    }
    public void setIsShotBombTrue() {
        this.isShotBomb = true;
    }
    public void setIsShotBombFalse() {
        this.isShotBomb = false;
    }

    public void setHorizontalPositive() {
        horizontal = obah*Time.deltaTime;
    }

    public void setHorizontalNegative()
    {
        horizontal = -1*obah*Time.deltaTime;
    }

    public void setVerticalPositive()
    {
        vertical = 1 * obah * Time.deltaTime;
    }

    public void setVerticalNegative()
    {
        vertical = -1 * obah * Time.deltaTime;
    }

    public void setHorizontalNormal() {
        horizontal = 0;
    }

    public void setVerticalNormal() {
        vertical = 0;
    }
}
