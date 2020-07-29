using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    [SerializeField]private GameObject laserPickUp;
    [SerializeField]private GameObject machineGunPickUp;
    [SerializeField]private GameObject mob;
    [SerializeField]private float pickUpCoolDownTime;
    [SerializeField]private float mobCoolDownTime;
    [SerializeField]private int randomPickUp;
    private float currentPickUpCoolDownTime;
    private float currentMobCoolDownTime;

    void Start(){
        currentPickUpCoolDownTime = pickUpCoolDownTime;
        currentMobCoolDownTime = mobCoolDownTime;
    }
    void Update(){
        if(mobCoolDownTime >= 0.2){
            mobCoolDownTime -= (Time.deltaTime * 0.01f);
        }
        currentPickUpCoolDownTime -= Time.deltaTime;
        currentMobCoolDownTime -= Time.deltaTime;
        if(currentPickUpCoolDownTime <= 0){
            float rng = Random.Range(-2,4);
            Vector2 spawnPosition = new Vector2 (transform.position.x,transform.position.y + rng);
            randomPickUp = Random.Range(0,2);

            switch(randomPickUp){
                case(0):
                    Instantiate(laserPickUp,spawnPosition,Quaternion.identity);
                    break;
                case(1):
                    Instantiate(machineGunPickUp,spawnPosition,Quaternion.identity);
                    break;
                default:
                    break;
            }
            currentPickUpCoolDownTime = pickUpCoolDownTime;
        }
        if(currentMobCoolDownTime <= 0){
            float rng = Random.Range(-2,4);
            Vector2 spawnPosition = new Vector2 (transform.position.x,transform.position.y + rng);
            Instantiate(mob,spawnPosition,Quaternion.identity);
            currentMobCoolDownTime = mobCoolDownTime;
        }
    }
}
