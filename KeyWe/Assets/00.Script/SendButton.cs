using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendButton : MonoBehaviour
{
	#region public º¯¼ö
	public AudioClip PUSH;
	#endregion

	[HideInInspector] public bool buttonPush;

	AudioSource sound;

	private void Awake()
	{
		buttonPush = false;
		sound = GetComponent<AudioSource>();
	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyDown(KeyCode.Z) && other.gameObject.CompareTag("Player"))
		{
			sound.clip = PUSH;
			sound.Play();
			buttonPush = true;
		}

		else
		{
			buttonPush = false;
		}
	}
}
