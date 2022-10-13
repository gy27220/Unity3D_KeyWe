using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    #region public º¯¼ö
    public char alphabet;
    public AnimationClip PUSH;
	public AudioClip PUSH_SOUND;
	#endregion

	Animation ani;
	AudioSource sound;
	MeshRenderer meshRenderer;
	bool playerCollCheck;


	private void Awake()
    {
		playerCollCheck = false;
		ani = GetComponentInParent<Animation>();
		sound = GetComponent<AudioSource>();
		meshRenderer = GetComponent<MeshRenderer>();
	}

    private void Update()
    {
		if(playerCollCheck && Input.GetKeyDown(KeyCode.Z))
		{
			sound.clip = PUSH_SOUND;
			sound.Play();

			ani.Play(PUSH.name);

			GameObject.FindObjectOfType<AlphabetCompare>().buttonChar.Add(alphabet);
		}
	}

    private void OnTriggerStay(Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
		{
			playerCollCheck = true;

			meshRenderer.material.color = new Color(246/255f, 225/225f, 85/255f);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerCollCheck = false;
			meshRenderer.material.color = new Color(204 / 255f, 164 / 255f, 164 / 255f);
		}
	}

}