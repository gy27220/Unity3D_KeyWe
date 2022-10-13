using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AlphabetCompare : MonoBehaviour
{
	public const int uiCount = 3;

	#region public º¯¼ö
	public TextMesh     textMesh;
	public MeshRenderer meshRender;
	public GameObject[] checkUi = new GameObject[uiCount];
	public GameObject   sendMessageUi;
	public GameObject   nextSceneButton;
	#endregion

	[HideInInspector] public bool buttonPush;
	[HideInInspector] public int  wordSize;
	[HideInInspector] public bool wordEndCheck;

	public List<string> screenWord = new List<string>();
	public List<char>   buttonChar = new List<char>();

				
	char[] wordCharType;
	string text;
	int    buttonCount;

	private void Awake()
	{
		wordEndCheck = false;
		wordSize = 0;
		buttonCount = 0;
		text = "";

		meshRender = GetComponent<MeshRenderer>();
	}

	private void Update()
	{ 
		wordCharType = screenWord[wordSize].ToCharArray();

		if (!wordEndCheck)
		{
			ButtonClick();

			if (GameObject.FindObjectOfType<DeleteButton>().buttonClick && buttonChar.Count > 0)
				DeleteAlphabet();

			CompareAlphabet();
		}

		else
		{
			text = "";
			buttonCount = 0;

			for(int i =0; i < buttonChar.Count; ++i)
			buttonChar.Remove(buttonChar[i]);

			if(buttonChar.Count == 0)
				wordEndCheck = false;
		}

		textMesh.text = text;

		if (screenWord[wordSize] == " ")
		{	
			sendMessageUi.SetActive(true);
		}

		uiCecking();
	}

	void uiCecking()
	{
		if (GameObject.FindObjectOfType<SendButton>().buttonPush)
		{
			sendMessageUi.SetActive(false);

			if (screenWord[wordSize] == " " && wordSize == uiCount)
			{
				wordSize += 1;
				checkUi[0].SetActive(true);
			}

			else if (screenWord[wordSize] == " " && wordSize == uiCount + 4)
			{
				wordSize += 1;
				checkUi[1].SetActive(true);
			}

			else if (screenWord[wordSize] == " " && wordSize == uiCount + 8)
			{
				wordSize += 1;
				checkUi[2].SetActive(true);
				nextSceneButton.SetActive(true);
			}
		}
	}

	void ButtonClick()
	{
		if (buttonCount < buttonChar.Count)
		{
			text += buttonChar[buttonCount];
			buttonCount += 1;
		}
	}

	void DeleteAlphabet()
	{
		buttonChar.RemoveAt(buttonChar.Count - 1);
		text = "";

		for (int i = 0; i < buttonChar.Count; ++i)
			text += buttonChar[i].ToString();

		buttonCount -= 1;
	}

	void  CompareAlphabet()
	{
		for (int i = 0; i < buttonCount; ++i)
		{
			if (string.Equals(text[i], wordCharType[i]))
			{
				meshRender.material.color = new Color(0, 230, 255);

				if (text.ToString() == screenWord[wordSize])
				{
					wordSize += 1;
					wordEndCheck = true;
					return;
				}
				else
					wordEndCheck = false;
			}
			else
			{
				meshRender.material.color = new Color(1, 0, 0);
			}
		}
	}
}
