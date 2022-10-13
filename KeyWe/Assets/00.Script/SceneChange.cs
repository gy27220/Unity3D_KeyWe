using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
	public void StartButton()
	{
		SceneManager.LoadScene("Telepost");
	}

	public void NextButton()
	{
		SceneManager.LoadScene("End");
	}

	public void ExitButton()
	{
		Application.Quit();
	}
}
