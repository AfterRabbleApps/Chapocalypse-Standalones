using UnityEngine;
using System.Collections;

public class spawnManger : MonoBehaviour {

	public GameObject[] enmey;
	public float spawnTime = 2.0f;
    public GameObject[] spawnPoints;
	public bool resetStatic = false;
	public static int gameLevels;
	public static bool upLevel = true;

 	
	void Start () {
        InvokeRepeating("Spawn", 1.0f, 1.0f); 
        gameLevels = 1;
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
	

    }
	void Update()
	{
		if (((scoreManager.currentScore % 10) == 0) && (scoreManager.currentScore > 1) && spawnTime > 0.1) {
			switch (scoreManager.currentScore % 100) {
			case 10: 							
				if (spawnTime != 0.9f) { 		
					CancelInvoke ("Spawn"); 	
					spawnTime = 0.9f; 			
					InvokeRepeating ("Spawn", 0, spawnTime); 
					upLevel = true;
				}
				break;                       
			case 20: 
				if (spawnTime != 0.8f) {
					spawnTime = 0.8f;
					CancelInvoke ("Spawn");
					InvokeRepeating ("Spawn", 0, spawnTime);
				}
				break;
			case 30:
				if (spawnTime != 0.7f) {
					spawnTime = 0.7f;
					CancelInvoke ("Spawn");
					InvokeRepeating ("Spawn", 0, spawnTime);
				}
				break;
			case 40:
				if (spawnTime != 0.6f) {
					spawnTime = 0.6f;
					CancelInvoke ("Spawn");
					InvokeRepeating ("Spawn", 0, spawnTime);
				}
				break;
			case 50:
				if (spawnTime != 0.5f) {
					spawnTime = 0.5f;
					CancelInvoke ("Spawn");
					InvokeRepeating ("Spawn", 0, spawnTime);
				}
				break;
			case 60:
				if (spawnTime != 0.4f) {
					spawnTime = 0.4f;
					CancelInvoke ("Spawn");
					InvokeRepeating ("Spawn", 0, spawnTime);
				}
				break;
			case 70:
				if (spawnTime != 0.3f) {
					spawnTime = 0.3f;
					CancelInvoke ("Spawn");
					InvokeRepeating ("Spawn", 0, spawnTime);
				}
				break;
			case 80:
				if (spawnTime != 0.2f) {
					spawnTime = 0.2f;
					CancelInvoke ("Spawn");
					InvokeRepeating ("Spawn", 0, spawnTime);
				}
				break;
			case 90:
				if (spawnTime != 0.1f) {
					spawnTime = 0.1f;
					CancelInvoke ("Spawn");
					InvokeRepeating ("Spawn", 0, spawnTime);
					Debug.Log ("Can i change levels:" + upLevel);

				}
				break;

			default:                        
				if (spawnTime == 0.1f) {
					spawnTime = 1.0f;   
					CancelInvoke ("Spawn");
					InvokeRepeating ("Spawn", 0, 0.1f);
				}
				break;
			}
		}
		if (GameManager.GameScore % 100 == 0 && upLevel) 
		{
			spawnManger.gameLevels+=1;
			Debug.Log (spawnManger.gameLevels);
			upLevel = false;
		}
	}
	void Spawn() {
		if (healthManager.currentHealth == 0)
		{
			return;
		}

		int spawnPointPre = Random.Range (0, spawnPoints.Length);
        int spawnPointIndex = spawnPointPre++;
		int enmeyIndex = Random.Range (0, enmey.Length);
        transform.rotation = Quaternion.identity;
        //Debug.Log(spawnPointIndex);
		  
		if (GameManager.isPaused == 1)
		{
            Instantiate (enmey [enmeyIndex], spawnPoints [spawnPointIndex].transform.position, transform.rotation );
		}
	}
}

