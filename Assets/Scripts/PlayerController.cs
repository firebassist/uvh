using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	/*** Part 1 ***/ /*** Edge Collider provides smooth walking ***/
	public float moveSpeed;
	public float jumpHeight;

	//prevent double jump Layer Ground is required /*** Part 2 ***/
	public Transform groundCheck;
	public float groundCheckRadius;// size of ground checker material
	public LayerMask whatIsGround; //brick is tagged as ground
	private bool grounded; 
	private bool doubleJumped;

	/*** Part 4 ***/ 
	private Animator anim;

	/*** Part 6 prevent sticky wall player material is attached***/ 
	private float moveVelocity;

	/*** Part 11 knockback player hurt ***/ 
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void FixedUpdate() {
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		

		/*** Part 1 ***/ /*** Part 2 ***/
//		if(Input.GetKeyDown (KeyCode.J) && grounded) {
//				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
//		}

		/*** Part 17 other controllers support***/
		if(Input.GetButtonDown ("Jump") && grounded) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

		/*** Part 6 prevent sticky wall***/  
//		moveVelocity = 0f;

//		if(Input.GetKey (KeyCode.D)) {
			//GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
//			moveVelocity = moveSpeed;
//		}

//		if(Input.GetKey (KeyCode.A)) {
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
//			moveVelocity = -moveSpeed;
//		}

		/*** Part 17 other controllers support***/
		moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");

		/*** Part 6 prevent sticky wall***/ 
		/*** Part 11 knockback player hurt ***/ 
		if (knockbackCount <= 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
			anim.SetBool ("Hurt", false);
		} else {
			if(knockFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockback, knockback);
			if(!knockFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockback, knockback);
			knockbackCount -= Time.deltaTime;
			anim.SetBool ("Hurt", true);
		}

		/*** Part 12 boolean Whip in animator***/
		if(anim.GetBool("Whip"))
			anim.SetBool("Whip", false);

//		if (Input.GetKeyDown (KeyCode.K)) {
//			anim.SetBool ("Whip", true);
//		}

		/*** Part 17 other controllers support***/
		if (Input.GetButtonDown("Fire1")) 
		{
			anim.SetBool ("Whip", true);
		}
	
		//Move (Input.GetAxisRaw ("Horizontal"));
				
		//GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		/*** Part 4 ***/ 
		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x)); // mathf instead of example 0 or -0 for x position

		anim.SetBool ("Grounded", grounded); //boolean Grounded in animator

		//prevents flipping when paused
		if (Time.timeScale == 1f) {
			//flips player sprite
			if (GetComponent<Rigidbody2D> ().velocity.x > 0)
				transform.localScale = new Vector3 (1f, 1f, 1f);
			else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
				transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}

	//public void Move(float moveInput) {
	//	moveVelocity = moveSpeed * moveInput;
	//}
}
