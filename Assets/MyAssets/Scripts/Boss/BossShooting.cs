using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour{
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]Transform firePoint;
    [SerializeField]private float attackDelay;
    [SerializeField]private float currentAttackDelay; 
    bool shootAble;
    private Boss boss;
    void Start(){
        boss = GetComponent<Boss>();
        shootAble = false;
    }
    void Update(){
        currentAttackDelay -= Time.deltaTime;
        shootAble = boss.Stop;
        if(currentAttackDelay <= 0 && shootAble){
            boss.Anim.SetTrigger("Shoot");
            Instantiate(bulletPrefab,firePoint.position,Quaternion.Euler(0,0,Random.Range(-30,30)));
            currentAttackDelay = attackDelay;
        }
    }
}
