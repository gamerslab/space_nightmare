using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {
	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 3.0f;
	public float verticalRange = 60.0f;
	public float jumpSpeed = 3.0f;

	float verticalRotation = 0;
	float verticalSpeed = 0;
	CharacterController characterController;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Rotate ();
		Move ();
	}

	void Rotate() {
		float lateralRotation = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, lateralRotation, 0);
		
		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -verticalRange, verticalRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
	}

	void Move() {
		float forwardSpeed = Input.GetAxis ("Vertical");
		float sideSpeed = Input.GetAxis ("Horizontal");
		
		verticalSpeed += Physics.gravity.y * Time.deltaTime;
		
		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
			verticalSpeed = jumpSpeed;
		}
		
		Vector3 speed = new Vector3 (sideSpeed, verticalSpeed, forwardSpeed);
		
		characterController.Move (transform.rotation * speed * movementSpeed * Time.deltaTime);
	}
}
