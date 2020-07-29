using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollision : MonoBehaviour{
    [SerializeField]private BirdAttack birdAttack;
    private string weaponType;
    private Rigidbody2D rb;
    private BirdController birdController;
    private Animator anim;
    private Collider2D birdCollider;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        birdCollider = GetComponent<Collider2D>();
        birdController = GetComponent<BirdController>();
        birdAttack = GetComponent<BirdAttack>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PickUps")){        
            weaponType = other.GetComponent<PickUps>().WeaponType;
            birdAttack.WeaponType = weaponType;
            switch(weaponType){
                case("Laser"):
                    birdAttack.WeaponDuration = Laser.WeaponDuration;
                    Debug.Log(birdAttack.WeaponDuration);
                    break;
                case("HomingMissilePickUp"):
                    break;
                case("MachineGun"):
                    birdAttack.WeaponDuration = 10f;
                    break;
                default:
                    break;
            }
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Mob")){
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Die();
    }

    private void Die(){
        rb.velocity = Vector2.zero;
		birdController.IsDead = true;
        birdCollider.enabled = false;
		GameManager.instance.BirdDied();
    }
}
