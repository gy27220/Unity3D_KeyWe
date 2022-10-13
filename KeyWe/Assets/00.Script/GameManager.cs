using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public const int uiCount = 3;

	#region public º¯¼ö
	public GameObject[] checkUi = new GameObject[uiCount];
	public GameObject   sendMessageUi;
	public TextMesh		buttonText;
	public TextMesh		screenText;
	#endregion
}
