//CharacterMovement
using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	Animator animator;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}


	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded && PlayerHealth.getAlive()) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			//Debug.Log (Input.GetAxis("Horizontal"));
			if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
				//you are moving
				animator.SetBool("Walking", true);
			} else {
				animator.SetBool("Walking", false);
			}
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
				animator.SetBool ("Jump", true);
			} else {
				animator.SetBool ("Jump", false);
			}

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

}