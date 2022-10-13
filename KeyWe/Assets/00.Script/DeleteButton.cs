using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
	#region public º¯¼ö
	public GameObject	 player;
	public AnimationClip PUSH;
	public AudioClip	 PUSH_SOUND;
	#endregion

	[HideInInspector] public bool buttonClick;

	Animation   ani;
	AudioSource sound;

	bool playerCollCheck;

    private void Awake()
	{
		ani = GetComponentInChildren<Animation>();
		playerCollCheck = false;
		buttonClick = false;
		sound = GetComponent<AudioSource>();
	}

    void Update()
    {
		buttonClick = false;

		if(playerCollCheck && Input.GetKeyDown(KeyCode.X))
		{
			sound.clip = PUSH_SOUND;
			sound.Play();
			ani.Play(PUSH.name);
			buttonClick = true;
		}
	}

    private void OnTriggerStay(Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
		{
			playerCollCheck = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerCollCheck = false;
		}
	}
}