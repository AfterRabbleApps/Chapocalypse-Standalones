using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreManager1 : MonoBehaviour 

{

	static int testScore = 0;
	static int highScore = 0;
	public GameObject GameOverScore;
	public GameObject GameOverHighScore;


	Text text1;
	Text text2;

	void Awake()
	{

		text1 = GameOverScore.GetComponent<Text> ();
		text2 = GameOverHighScore.GetComponent<Text> ();

	}



	void Update()
	{
		testScore = GameManager.GameScore;
		highScore = GameManager.Highscore;

		text1.text= "Score: " + testScore;
		text2.text = "Highscore is: \n"+ PlayerPrefs.GetInt ("highscore", 0);

	}


}