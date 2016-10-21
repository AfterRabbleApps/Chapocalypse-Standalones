using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {


	public GameObject GameCanvas;
	public GameObject MainMenuCanvas;
	public GameObject PauseCanvas;
	public GameObject GameOverCanvas;
	public GameObject NightCanvas;
	public GameObject MuteOff1;
	public GameObject MuteOff2;
	public GameObject MuteOff3;
	public GameObject MuteOn1;
	public GameObject MuteOn2;
	public GameObject MuteOn3;
	public static int GameHealth;
	public static int Highscore;
	public static int HealthScore;
	public static int isPaused;
	public static int GameScore;
	private Animator anim;
	public bool isMute;
	public  bool isNight;
	public int i = 1;

    private int newgpsHighScore;
    public int gpsHighScore;




	void Start () 
	{
        
		MainMenuCanvas.SetActive(true);
		GameCanvas.SetActive (false);
		PauseCanvas.SetActive (false);
		GameOverCanvas.SetActive (false);
		NightCanvas.SetActive (false);
        GameOverCanvas.SetActive(false);
		MuteOn1.SetActive (false);
		MuteOn2.SetActive (false);
		MuteOn2.SetActive (false);
		spawnManger.gameLevels = 1;
		isPaused = 0;
		Time.timeScale = 0;
    
		anim = NightCanvas.GetComponent<Animator>();
        Debug.Log("Can I go to sleep?" + !isNight); 

	}
	

	void Update () 
	{
        if (GameHealth >= 2)
        {
            GameOverCanvas.SetActive (false);
        }
		if (Time.timeScale == 1) 
		{
			isPaused = 1;
		}

		if (Time.timeScale == 0) 
		{
			isPaused = 0;
		}
		if (GameHealth <= 0) 
		{
			GameOverScript ();
		}
       



		GameHealth = healthManager.currentHealth;
		GameScore = scoreManager.currentScore;
		HealthScore = healthManager.currentHealth;

        if (spawnManger.gameLevels % 2 == 0 && isNight )
		{
			NightCanvas.SetActive (false);
			isNight = false;
            Debug.Log("Night Time :" + isNight); 
		}
        if (spawnManger.gameLevels % 2 == 1 && spawnManger.gameLevels != 1 && !isNight)
		{
			NightCanvas.SetActive (true);
			isNight = true;
            Debug.Log("Night Time :" + !isNight); 

		}
	}
		



	public void PlayButton()
	{
		PauseCanvas.SetActive (false);
		MainMenuCanvas.SetActive (false);
		GameCanvas.SetActive (true);
		Time.timeScale = 1;
	}

	public void PauseButton()
	{
		GameCanvas.SetActive (false);
		PauseCanvas.SetActive (true);
		Time.timeScale = 0;
	
	}
	public void Restart ()
	{
		SceneManager.LoadScene (Application.loadedLevel);
	}

	public void MuteON()
	{
		AudioListener.volume = 0;
		MuteOff1.SetActive(false);
		MuteOff2.SetActive(false);
		MuteOff3.SetActive(false);
		MuteOn1.SetActive (true);
		MuteOn2.SetActive (true);
		MuteOn3.SetActive (true);
		isMute = false;
	}

	public void MuteOFF()
	{
		AudioListener.volume = 1;
		MuteOff1.SetActive (true);
		MuteOff2.SetActive (true);
		MuteOff3.SetActive (true);
		MuteOn1.SetActive (false);
		MuteOn2.SetActive (false);
		MuteOn3.SetActive (false);
		isMute = true;
	}

	public void QuitButton()
	{
		Application.Quit ();
	}
        
	public void GameOverScript (){
		
			GameOverCanvas.SetActive (true);
			GameCanvas.SetActive (false);
			Time.timeScale = 0;
			Destroy (GameObject.FindGameObjectWithTag("Enemy"));
			StoreHighscore (scoreManager.currentScore);
			spawnManger.gameLevels= 0;
		
	}
    void StoreHighscore(int newHighscore)
	{
		
		int oldHighscore = PlayerPrefs.GetInt ("highscore", 0);
		if (newHighscore > oldHighscore ){
			Highscore = newHighscore;
			PlayerPrefs.SetInt ("highscore", newHighscore);
		}

        if (gpsHighScore < Highscore)
        {
            gpsHighScore = Highscore;
            Social.ReportScore(gpsHighScore, "CgkI1ePEjJ4eEAIQBg", (bool success) =>
                {
                    
                });
        }

       


	}
}



