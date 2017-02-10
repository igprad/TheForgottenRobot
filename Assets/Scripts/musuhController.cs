using UnityEngine;
using System.Collections;

public class musuhController : MonoBehaviour {

	public float moveSpeed;
	public bool moveLeft;
	private Rigidbody2D rigid;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigid = GetComponent<Rigidbody2D> ();

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall)
			moveLeft = !moveLeft;

		if (moveLeft) {
			transform.localScale = new Vector3 (-5.197438f, 4.113088f, 1f);
			rigid.velocity = new Vector2 (-moveSpeed, rigid.velocity.y);
		} else {
			transform.localScale = new Vector3 (5.197438f, 4.113088f, 1f);
			rigid.velocity = new Vector2 (moveSpeed, rigid.velocity.y);
		}
	}

}
