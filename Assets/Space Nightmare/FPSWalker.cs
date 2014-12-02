using UnityEngine;
using System.Collections;

public class FPSWalker : MonoBehaviour {
	public bool leftMouseClick=false;
	public bool rightMouseClick=false;
	public bool canControl=true;
	private float shift_axis_late;
	public float leftMouseClicks;

	private float animLayer2;
	public float inputX;
	public float inputY;
	public float angle;
	public float auxi;
	float speed = 5.0f;
	float maxSpeedZ = 0.05f;
	float stepSpeedZ = 0.005f;
	float speedZ = 0.0f;
	bool jumped = false;
	bool hasCollided = false;
	Vector3 lastPosition;
	CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;

	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	void OnAnimatorIK(){
//		if(canControl){
//			Vector3 camDir =  transform.position - Camera.main.transform.position;
//			Vector3 lookPos = transform.position + camDir;
//			lookPos.y = transform.position.y -(Camera.main.transform.position.y - transform.position.y) + 10f;
//		}
	}
	
	void Update () {
		if(canControl){

			inputX = Input.GetAxis("Horizontal");
			inputY = Input.GetAxis("Vertical");

			if (Input.GetKeyDown(KeyCode.Space)){
				speedZ = maxSpeedZ;
				jumped = true;
			}

			angle = Camera.main.transform.eulerAngles.y*Mathf.PI/180.0f;
			auxi = Mathf.Cos(angle);
			if (!hasCollided)
			{
				lastPosition = transform.position;
//				transform.Translate(inputY*speed,speedZ,inputY*speed);
				moveDirection = new Vector3(inputY*speed*Mathf.Sin(angle),speedZ,inputY*speed*Mathf.Cos(angle));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				controller.Move(moveDirection * Time.deltaTime);

				moveDirection = new Vector3(inputX*speed*Mathf.Cos(-angle),speedZ,inputX*speed*Mathf.Sin(-angle));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				controller.Move(moveDirection * Time.deltaTime);
//				transform.Translate(inputY*speed*Mathf.Sin(angle),speedZ,inputY*speed*Mathf.Cos(angle));
//				transform.Translate(inputX*speed*Mathf.Cos(-angle),speedZ,inputX*speed*Mathf.Sin(-angle));

			}
			hasCollided = false;

			if(jumped){
				speedZ = speedZ-stepSpeedZ;
				if(speedZ <= -maxSpeedZ){
					speedZ = 0.0f;
					jumped = false;
				}
			}
		}
		
	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log("(PlayerHitWall) Player hit: " + col.gameObject.name);

		if (col.gameObject.name == "Walls") {
		}
	}
}
