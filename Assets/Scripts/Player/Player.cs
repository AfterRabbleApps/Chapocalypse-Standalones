using UnityEngine;
using System.Collections;
 

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject HealthManager;
    public static float FireRate  = 40f;  // The number of bullets fired per second
    public static float lastfired = 0f;      // The value of Time.time at the last firing moment
    public static bool fullAuto;
    public AudioSource playerHit;
 
    private Animator anim;
	public float speed = 10f;
 
    void Awake ()
    {
        anim = GetComponent<Animator> ();
        //fallAuto = false;
    }
 
    void Update ()
    {
 
        if (GameManager.isPaused == 1)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            mouseWorldPos.z = 0f;
            transform.LookAt (mouseWorldPos);
 
            fullauto1 ();
        }
    }
 
    void OnTriggerEnter2D (Collider2D aCollider)
    {
        if (aCollider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
            Destroy (aCollider.gameObject);
            //Destroy(gameObject);
        }
 
        if (aCollider.gameObject.tag == "Enemy") {
            anim.SetTrigger ("playerHit");
            healthManager.currentHealth = healthManager.currentHealth - dogAttack.dogValue;
            playerHit.GetComponent<AudioSource>().Play();
 
        }
 
    }
 
    public void fullauto1  ()
    {
       
        if (Input.GetButton ("Fire1") && fullAuto) {
                if (Time.time - lastfired > 1 / FireRate) {
                    lastfired = Time.time;
                    GameObject bullet = GameObject.Instantiate (bulletPrefab);
                    bullet.transform.position = transform.position;
                    bullet.transform.forward = transform.forward;
                }
            }
 
           
        if (Input.GetButtonDown ("Fire1") && !fullAuto)
                {
                    GameObject bullet = GameObject.Instantiate (bulletPrefab);
                    bullet.transform.position = transform.position;
                    bullet.transform.forward = transform.forward;
                }
		}

	public void fullautOnOff()
	{
		fullAuto = !fullAuto;
	}
}