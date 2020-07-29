using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour{
    [SerializeField]private int bulletVelocity;
    private Rigidbody2D rb;
    private bool isDead = false;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        stateCheck();
        if(!isDead){
            rb.velocity = -transform.right * bulletVelocity;
        }
    }
    void stateCheck(){
        if(isDead){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.CompareTag("StopHere") && !other.CompareTag("Mob") && !other.CompareTag("Bullets")){
            isDead = true;
        }
    }
}
