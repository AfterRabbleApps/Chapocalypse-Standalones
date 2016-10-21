using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelsManager : MonoBehaviour {

	public GameObject Levels;

	private Animator anim;

	Text text;

	void Start () {
		text = GetComponent<Text> ();
		anim = GetComponent<Animator> ();
	
	}

	void Update () {

		int gameLevels = spawnManger.gameLevels;
		text.text = "Level: " + gameLevels;
		}
}
