using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;

	GameObject player;

	// Use this for initialization
	void Start () {
		player = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f/smoothing);//Linear Interpretation of movement
		smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f/smoothing);
		mouseLook += smoothV;
		mouseLook.y = Mathf.Clamp(mouseLook.y,-90f,90f); //Limits movement on the y axis

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x,player.transform.up);

	}
}
