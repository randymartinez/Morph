using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour {

	//private bool isWallR = false;
	//private bool isWallL = false;
	private RaycastHit hitR;
	private RaycastHit hitL;
	private int jumpCount = 0;
	private PlayerController cc;
	private Rigidbody rb;

	void Start () {
		cc = GetComponent<PlayerController>();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(jumpCount > 0){
			print("Jump");
			print(jumpCount);
		}

		if(cc.isGrounded){
			jumpCount = 0;
		}

		if(Input.GetKeyDown(KeyCode.D) && !cc.isGrounded && jumpCount <= 1){
			if(Physics.Raycast(transform.position, transform.right, out hitR, 1)){
				if(hitR.transform.tag == "wall"){
					//isWallR = true;
					//isWallL = false;
					print("I'm Wall Running! R");
					jumpCount += 1;
					rb.useGravity = false;
					StartCoroutine(afterRun());
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.A) && !cc.isGrounded && jumpCount <= 1){
			if(Physics.Raycast(transform.position, -transform.right, out hitL, 1)){
				if(hitL.transform.tag == "wall"){
					//isWallR = false;
					//isWallL = true;
					print("I'm Wall Running! L");
					jumpCount += 1;
					rb.useGravity = false;
					StartCoroutine(afterRun());
					}
				}
		}

		}

	IEnumerator afterRun(){
		yield return new WaitForSeconds(0.5f);
		//isWallL = false;
		//isWallR = false;
		rb.useGravity = true;
	}
}
