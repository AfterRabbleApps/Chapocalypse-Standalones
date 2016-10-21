using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class highScoreManager : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		text.text = "Highscore is: \n" + PlayerPrefs.GetInt ("highscore", 0);
	
	}
}
