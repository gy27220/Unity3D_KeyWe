using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct TextType
{
	public string  word;
	public Vector3 pos;

	public TextType(string word, Vector3 pos)
	{
		this.word = word;
		this.pos = pos;
	}
};

public class SplitWord : MonoBehaviour
{
	TextMesh textMesh;
	public TextType[] textType;

	string kiwiWord = "need/more/bagels/ /meteor/shower/tonight/ /swallowed/a/bug/ ";
	string[] wordArray;
	int arraySize = 0;

	private void Awake()
	{
		textMesh = GetComponent<TextMesh>();

		wordArray = kiwiWord.Split('/');

		textType = new TextType[]
		{
			new TextType(wordArray[0],new Vector3(-11.0f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[1],new Vector3(-11.5f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[2],new Vector3(-12.2f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[3],new Vector3(-13.2f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[4],new Vector3(-13.2f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[5],new Vector3(-13.5f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[6],new Vector3(-13.5f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[7],new Vector3(-15.7f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[8],new Vector3(-15.7f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[9],new Vector3(-9f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[10],new Vector3(-11.0f,textMesh.transform.position.y,textMesh.transform.position.z)),
			new TextType(wordArray[11],new Vector3(-11.0f,textMesh.transform.position.y,textMesh.transform.position.z))
		};

		for (int i = 0; i < wordArray.Length; ++i)
			GameObject.FindObjectOfType<AlphabetCompare>().screenWord.Add(wordArray[i]);
	}

	void Update()
	{
		for (; arraySize < textType.Length;)
		{
			textMesh.text = textType[arraySize].word;
			textMesh.transform.position = textType[arraySize].pos;
			arraySize = GameObject.FindObjectOfType<AlphabetCompare>().wordSize;

			break;
		}
	}
}