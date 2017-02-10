using UnityEngine;
using System.Collections;

public class WallBullet : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		Destroy(other.gameObject);
	}

	void OnTriggerExit (Collider other) 
	{
		Destroy(other.gameObject);
	}
}
