using UnityEngine;
using System.Collections;

public class Done_BombItem : MonoBehaviour {
    private Done_PlayerController player;
	// Use this for initialization
	void Start () {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Done_PlayerController>();
        }
        if (playerObject == null)
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.AddBombCount();
            Destroy(this.gameObject);
        }

        
    }
}
