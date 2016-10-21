using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]

public class TennisBall : MonoBehaviour
{
	public float speed = 2f;
	private SpriteRenderer spriteRenderer;
	public Rigidbody2D[] rb;
    private GameObject dogs;
    public AudioSource dogHit;



	void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


	void Update () 
	{
		transform.position += Time.deltaTime * speed * transform.forward;
		if(spriteRenderer.isVisible == false)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D aCollider)
	{
		if(aCollider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			scoreManager.currentScore += dogAttack.dogValue;
            Destroy(aCollider.gameObject);
            //Destroy(gameObject);

            dogHit.GetComponent<AudioSource>().Play();

		}
	}

}
