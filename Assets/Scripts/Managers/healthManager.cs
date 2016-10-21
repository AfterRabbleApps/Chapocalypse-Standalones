using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthManager : MonoBehaviour {

	public static int currentHealth;
	public int testHealth = 0;

	Text text;

	void Awake()
	{

		text = GetComponent<Text> ();
		currentHealth = 6;

	}


	// Update is called once per frame
	void Update () 
	{
		testHealth = currentHealth;

		if (currentHealth == 6) 
		{
			text.text = "III";
		}

		if (currentHealth == 4) 
		{
			text.text = "XII";
		}

		if (currentHealth == 2) 
		{
			text.text = "XXI";
		}

		if (currentHealth <= 0)
		{
			text.text = "XXX";
			//Destroy (GameObject.FindGameObjectWithTag("Player"));
		}
	}
}
