using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	public GameObject player;

	public float _horizontalMoveSpeed;
    public float _verticalMoveSpeed;
	bool isUpPressed=false;
	bool isRightPressed=false;
	bool isLeftPressed=false;
	bool isGrounded=true;
    private Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}

	void Update () {
		if (isUpPressed&&isGrounded) {
			upArrow ();
            
            
		}

		if (isRightPressed) {
			RightArrow();
		}

		if (isLeftPressed) {
			LeftArrow();
		}

	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Land")
        {
            isGrounded = true;
            Debug.Log("NyentuhTanah");
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Land")
        {
            isGrounded = false;
            Debug.Log("out");
        }
    }


	//-------------------------------------TriggerMove-----------------------------------------------------

	public void upPressed(){
		isUpPressed = true;
	}

	public void upReleased(){
		isUpPressed = false;
	}

	    public void rightPressed(){
		    isRightPressed = true;
	    }

	    public void rightReleased(){
		    isRightPressed = false;
	    }

	public void leftPressed(){
		isLeftPressed = true;
	}

	public void leftReleased(){
		isLeftPressed = false;
	}

	//-------------------------------------TriggerMove-----------------------------------------------------



	//-----------------------------------------FunctionMove-------------------------------------------
		public void upArrow(){
		
			//_animator.SetTrigger ("Lompat");
            player.transform.Translate(Vector2.up * Time.deltaTime * _verticalMoveSpeed);
            
			
        //_animator.SetTrigger("Lompat");
        
		}

		public void RightArrow(){
			//_animator.SetTrigger ("GerakKanan");
			player.transform.Translate (Vector2.right * Time.deltaTime * _horizontalMoveSpeed);
            anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
            anim.Play("Run");
		}

		public void LeftArrow(){
			//_animator.SetTrigger ("GerakKiri");
            
			player.transform.Translate (Vector2.left * Time.deltaTime * _horizontalMoveSpeed);

            
		}
	//-----------------------------------------FunctionMove-------------------------------------------
}
