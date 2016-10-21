using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class playerTouch : MonoBehaviour
{
	public GameObject bulletPrefab;
	private Animator anim;
	public float speed = 10f;
    public AudioSource playerHit;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{

		if (GameManager.isPaused == 1) {
			if (Input.touchCount >= 1) {
				Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (1).position);
				mouseWorldPos.z = 0f;
				transform.LookAt (mouseWorldPos);

				if (Input.GetButtonDown ("Fire1")) {
					GameObject bullet = GameObject.Instantiate (bulletPrefab);
					bullet.transform.position = transform.position;
					bullet.transform.forward = transform.forward;
				}
			}
	
		}
	}

	void OnTriggerEnter2D (Collider2D aCollider)
	{
		if (aCollider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			Destroy (aCollider.gameObject);
			//Destroy(gameObject);
		}

		if(aCollider.gameObject.tag == "Enemy")
		{
			anim.SetTrigger ("playerHit");
			healthManager.currentHealth = healthManager.currentHealth - dogAttack.dogValue;
            playerHit.GetComponent<AudioSource>().Play();


		}
	}
}