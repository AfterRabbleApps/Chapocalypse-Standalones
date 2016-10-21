using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pauseScoreManager : MonoBehaviour {

	public int testScore = 0;

	Text text;

	void Awake()
	{

		text = GetComponent<Text> ();
	}



	void Update()
	{
		testScore = scoreManager.currentScore;
		
		text.text = "Score: " + scoreManager.currentScore;
	}


}
