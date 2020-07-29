using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour{
	[SerializeField]private float upForce;
	[SerializeField]AudioSource soundManager;
	[SerializeField]AudioClip flapFX;
	private bool isDead = false;
	private bool isTap = false;
	private bool isShoot = false;
	private Animator anim;				
	private Rigidbody2D rb;				
	private Quaternion downRotation;
	private Quaternion forwardRotation;
	private BirdAttack birdAttack;
	private float hp = 1;
	public bool IsDead{get{return isDead;} set{isDead = value;}}
	public float HP{get{return hp;} set{hp = value;}}
	private void Start(){
		Initialize();
	}
	private void Initialize(){
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D>();
		birdAttack = GetComponent<BirdAttack>();
		downRotation = Quaternion.Euler(0,0,-90);
		forwardRotation = Quaternion.Euler(0,0,35);
	}	
	private void Update(){
		if (!isDead){
			InputHandler();
			Shoot();
		}
	}
	private void InputHandler(){
		if (Input.GetKeyDown("space")){
			isTap = true;
		}
		if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Return)){
			isShoot = true;
		}
	}
	private void FixedUpdate() {
		if(!isDead){
			Flap();
			transform.rotation = Quaternion.Lerp(transform.rotation, downRotation,Time.deltaTime);
		}
	}
	private void Flap(){
		if(isTap){
			anim.SetTrigger("Flap");
			soundManager.clip = flapFX;
			soundManager.Play();
			transform.rotation = forwardRotation;
			rb.velocity = Vector2.zero;
			rb.AddForce(new Vector2(0,upForce));
			isTap = false;
		}
	}
	private void Shoot(){
		if(isShoot){
			birdAttack.StartShooting();
			isShoot = false;
		}
	}
}
