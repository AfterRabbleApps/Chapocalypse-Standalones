using UnityEngine;

public class GameOverManager : MonoBehaviour
{
	public float restartDelay = 5f;
	//public GameObject MainMenu;
	public GameObject DealthCanvas;
	public GameObject Canvas;


    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
		//MainMenu.SetActive (false);
		DealthCanvas.SetActive (false);
		//MainMenu.SetActive (true);
    }


    void Update()
    {
		if (healthManager.currentHealth <= 0)
        {
			DealthCanvas.SetActive (true);
			Canvas.SetActive (false);
			anim.SetTrigger("GameOver");
        }
    }
}
