using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {
	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 3.0f;
	public float verticalRange = 60.0f;
	public float jumpSpeed = 7.0f;
	public float gravityForce = -9.8f;

	float verticalRotation = 0.0f;
	float verticalSpeed = 0.0f;
	CharacterController characterController;
	float floorY;
	bool hasJumped = false;
	Vector3 numKey = new Vector3(0, 0, 0);
	int inLadder = 0;

	// Use this for initialization
	void Start () {
		floorY = transform.position.y;
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

		if (characterController.isGrounded) {
			if (verticalSpeed < -3.0f && inLadder == 0)
			{
				gameObject.SendMessage("OnDamage", Mathf.Abs(verticalSpeed)*5.0f);
			}
			verticalSpeed = 0.0f;
			if(Input.GetButtonDown ("Jump")) {
				verticalSpeed = jumpSpeed;
				hasJumped = true;
				Debug.Log ("Jump");
			}
		}

		if(inLadder == 0) {
			verticalSpeed += gravityForce * Time.deltaTime;
		}

		Vector3 speed;
		if (inLadder > 0) 
		{
			if (characterController.isGrounded && forwardSpeed <= 0.0f)
			{
				speed = new Vector3 (sideSpeed, verticalSpeed, forwardSpeed);
			}
			else
			{
				speed = new Vector3 (0.0f, forwardSpeed, 0.0f);
			}
		} 
		else 
		{
			speed = new Vector3 (sideSpeed, verticalSpeed, forwardSpeed);
		}
		characterController.Move (transform.rotation * speed * movementSpeed * Time.deltaTime);
	}

	void GiveKey(int typeKey)
	{
		if (typeKey == 0)
			numKey.x++;
		else if (typeKey == 1)
			numKey.y++;
		else if (typeKey == 2)
			numKey.z++;
	}

	public bool hasKey(int typeKey)
	{
		if (typeKey == 0)
			return numKey.x > 0;
		else if (typeKey == 1)
			return numKey.y > 0;
		else if (typeKey == 2)
			return numKey.z > 0;
		return false;
	}

	void wasteKey(int typeKey)
	{
		if (typeKey == 0)
			numKey.x--;
		else if (typeKey == 1)
			numKey.y--;
		else if (typeKey == 2)
			numKey.z--;
	}

	void AmmoRecharge(int ammount)
	{
		transform.Find ("Camera").Find ("Camera").Find ("MachineGun").SendMessage ("AmmoRecharge", ammount);
	}

	void TargetReached()
	{

	}

	void ladderScaling()
	{
		inLadder++;
	}

	void ladderLeaving()
	{
		inLadder--;
	}
}
