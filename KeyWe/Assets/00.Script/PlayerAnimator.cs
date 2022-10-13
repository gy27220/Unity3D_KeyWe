using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	#region public º¯¼ö
	public Transform root;
	public float jumpSpeed;
	public float runSpeed = 5.0f;
	public float gravity;
	#endregion

	#region public Sound
	public AudioClip CHIRP;
	#endregion

	CharacterController controller;
	Animator ani;
	Transform playerTransform;
	AudioSource sound;
	Vector3 move;

	private void Awake()
	{
		playerTransform = transform;
		controller = GetComponentInChildren<CharacterController>();
		ani = GetComponent<Animator>();
		sound = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (controller.isGrounded)
			Jump();

		else
			move.y -= gravity * Time.deltaTime;

		Move();
		controller.Move(move * Time.deltaTime);

		ButtonPush();
		Chirp();
	}

	void Move()
	{
		float tempMove = move.y;

		move.y = 0;

		Vector3 inputMoveXZ = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		inputMoveXZ = playerTransform.TransformDirection(inputMoveXZ);

		inputMoveXZ = inputMoveXZ.normalized * runSpeed;

		if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
		{
			Vector3 forward = Vector3.Slerp(root.forward, inputMoveXZ, Time.deltaTime);

			root.LookAt(root.position + inputMoveXZ);

			move = Vector3.MoveTowards(move, inputMoveXZ, runSpeed);
		}

		else
			move = Vector3.MoveTowards(move, Vector3.zero, runSpeed);

		float speed = move.sqrMagnitude;
		ani.SetFloat("Speed", speed);

		move.y = tempMove;
	}

	void ButtonPush()
	{
		if (Input.GetKeyDown(KeyCode.Z))
			ani.SetTrigger("Push");
	}

	void Chirp()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			ani.SetTrigger("Chirp");
			sound.clip = CHIRP;
			sound.Play();
		}
	}

	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			move.y = jumpSpeed;
			ani.SetBool("Jumpbool", true);
		}
		else
			ani.SetBool("Jumpbool", false);
	}
}
