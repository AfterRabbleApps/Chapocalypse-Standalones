using UnityEngine;
using System.Collections;


public class dogAttack : MonoBehaviour
{
	public float speed = 2f;
	private Transform player;
	public static int killCount = 0;
	public static int dogValue = 1;
	public int[] dogSpeed;


	void Start()
	{
		if (healthManager.currentHealth > 0) 
		{
			player = GameObject.FindWithTag ("Player").transform;
		}
	}

	void Update ()
	{

		int speedIndex = Random.Range (0, dogSpeed.Length);

		if(player != null)
		{
			transform.LookAt(player);
			transform.position += transform.forward * Time.deltaTime * dogSpeed[speedIndex];
		}
	}

}