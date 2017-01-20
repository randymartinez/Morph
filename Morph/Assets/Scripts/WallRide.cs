using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRide : MonoBehaviour {

	public bool isWallR = false;
	public bool isWallL = false;

	public bool canJump;

	public float jumpHeight;
	public float speed;

	private RaycastHit hitR;
	private RaycastHit hitL;
	private int jumpCount;
	private PlayerController cc;
	private Rigidbody rb;

	void Start () {
		canJump = true;
		jumpHeight = 3.5f;
		jumpCount = 0;
		speed = 8f;
		cc = GetComponent<PlayerController>();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(cc.isGrounded){
			jumpCount = 0;
			canJump = true;
		}

		if( !cc.isGrounded && jumpCount <= 1){

			if(Physics.Raycast(transform.position, transform.right, out hitR, 1)){

				if(Input.GetKeyDown(KeyCode.E) && (hitR.transform.tag == "wall")){
					rb.AddForce(transform.forward * speed);
					canJump = false;
				}

				if(hitR.transform.tag == "wall"){
					isWallR = true;
					isWallL = false;
					print("I'm Wall Running! R");
					jumpCount += 1;
					rb.useGravity = false;
					rb.AddForce(new Vector3(0f,jumpHeight,0f));
					//rb.velocity = rb.velocity.normalized *10;

					StartCoroutine(afterRun());
				}

				
			}



			if(Physics.Raycast(transform.position, -transform.right, out hitL, 1)){
				
				if(Input.GetKeyDown(KeyCode.E) && (hitL.transform.tag == "wall")){
					rb.AddForce(transform.forward * speed);
					canJump = false;
				}

				if(hitL.transform.tag == "wall"){
					isWallR = false;
					isWallL = true;
					print("I'm Wall Running! L");
					jumpCount += 1;
					rb.useGravity = false;
					rb.AddForce(new Vector3(0f,jumpHeight,0f));
					//rb.velocity = rb.velocity.normalized *10;

					StartCoroutine(afterRun());
					}
				}
			}
	}

		IEnumerator afterRun(){
		yield return new WaitForSeconds(0.5f);
		isWallR = false;
		isWallL = false;
		canJump = true;
		rb.useGravity = true;
	}
}
