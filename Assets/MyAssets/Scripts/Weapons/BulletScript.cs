using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour{
    [SerializeField]private int bulletVelocity;
    private Rigidbody2D rb;
    private float attackDuration = 0.9f;
    private bool isDead = false;
    [SerializeField]int damage = 5;
    [SerializeField]float attackDelay = 0.5f;
    [SerializeField]float weaponDuration;
    public float Damage{get{return damage;}}
    public float AttackDelay{get{return attackDelay;}}
    public float WeaponDuration{get{return weaponDuration;}}
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        stateCheck();
        if(attackDuration <= 0){
            isDead = true;
        }
        if(!isDead){
            rb.velocity = transform.right * bulletVelocity;
            attackDuration -= Time.deltaTime;
        }
    }
    void stateCheck(){
        if(isDead){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Component damagable = other.transform.GetComponent(typeof(IDamagable));
        if(!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("StopHere") && !other.gameObject.CompareTag("PickUps") && !other.gameObject.CompareTag("Bullets")){
            isDead = true;
            if(damagable){
                (damagable as IDamagable).TakeDamage(damage);
            }
        }
    }
}
