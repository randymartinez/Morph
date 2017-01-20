using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float maxForward;
	public float maxSpeed;
	public float jumpHeight;
	public bool isGrounded;
	public Rigidbody rb;


	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		maxForward = 20f;
		maxSpeed = 10f;
	    speed = 7.0F;
		jumpHeight = 3.5F;
		isGrounded = false;
		rb = GetComponent<Rigidbody>();
		//transform.position = new Vector3(0f,0.5f,0f);


	}
	
	// Update is called once per frame
	void Update () {
		
		if (isGrounded)
		{

			
			if (Input.GetKeyDown(KeyCode.Space)) 
			{
				rb.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
				isGrounded = false;
			}

			if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow))){

				rb.AddForce(transform.forward * speed);
				rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxForward);
			}
				
			if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow))){
				rb.AddForce(-transform.forward * speed);
				rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
			}

			
			if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow))){
				rb.AddForce(-transform.right * speed);
				rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
			}


			if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow))){
				rb.AddForce(transform.right * speed);
				rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
			}

			//rb.velocity = rb.velocity.normalized *speed;
			if(Input.GetKeyDown("escape")){Cursor.lockState = CursorLockMode.None;}
		}

}


void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("ground")){isGrounded = true;}

		if(other.gameObject.CompareTag("OutOfBounds")){
			//Application.LoadLevel(0);
			SceneManager.LoadScene(0);
			}

	}
}





		/**
		float translation = Input.GetAxis("Vertical") * speed;
		float straffe = Input.GetAxis("Horizontal") * speed; //Left & Right

		if(isGrounded){
			translation *= Time.deltaTime;
			straffe *= Time.deltaTime;

			if(Input.GetButton("Jump")){
				//rb.velocity += new Vector3(straffe,jumpHeight,translation);

				rb.AddForce(new Vector3(0f,jumpHeight, 0f));
				isGrounded = false;
			}

			else{
				rb.AddForce (new Vector3(straffe, 0f, translation));
				//transform.Translate(straffe, 0f, translation);

				}
		}
		**/
