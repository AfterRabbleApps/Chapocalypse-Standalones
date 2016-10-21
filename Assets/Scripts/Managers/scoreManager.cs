using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreManager : MonoBehaviour {

	public static int currentScore;
	public static float testScore;

	Text text;

	void Awake()
	{

		text = GetComponent<Text> ();
		currentScore = 0;
	}



	void Update()
	{
		testScore = currentScore;
		text.text = "" + currentScore;
	}

}
