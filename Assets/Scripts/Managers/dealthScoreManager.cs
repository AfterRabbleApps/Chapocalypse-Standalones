using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dealthScoreManager : MonoBehaviour 

{

	public static int testScore = 0;
	public GameObject GameOverScore;


	Text text;

	void Awake()
	{

		text = GameOverScore.GetComponent<Text> ();
	}



	void Update()
	{
		testScore = GameManager.GameScore;

		text.text = "Score: " + testScore;
	}


}