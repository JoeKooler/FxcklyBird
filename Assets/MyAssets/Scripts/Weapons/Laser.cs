using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour{
    [SerializeField]private GameObject gunPoint;
    private string weaponType = "Laser";
    private static float damage;
    private static float attackDelay;
    private static float attackDuration;
    private static float weaponDuration;
    private bool isDead;
    [SerializeField]private LineRenderer lr;
    [SerializeField]private BaseStats baseStats;
    public string WeaponType{get{return weaponType;}}
    public static float Damage{get{return damage;}}
    public static float AttackDelay{get{return attackDelay;}}
    public static float AttackDuration{get{return attackDuration;}}
    public static float WeaponDuration{get{return weaponDuration;}}
    public bool IsDead{get{return isDead;}}
    private float currentAttackDuration;

    private void Start() {
        damage = baseStats.Damage;
        attackDelay = baseStats.AttackDelay;
        attackDuration = baseStats.AttackDuration;
        weaponDuration = baseStats.WeaponDuration;
    }

    private void Update() {
        StateCheck();
        if(currentAttackDuration <= 0){
            isDead = true;
        }
        if(!isDead){
            currentAttackDuration -= Time.deltaTime;
            SetLaserPosition();
            RayCastingTarget();
        }
    }

    public void StartShooting(){
        isDead = false;
        SetLaserPosition();
        lr.enabled = true;
        currentAttackDuration = attackDuration;
    }
    void StateCheck(){
        if(isDead){
            lr.enabled = false;
        }
    }

    void SetLaserPosition(){
        lr.SetPosition(0,gunPoint.transform.position);
		lr.SetPosition(1,gunPoint.transform.position + gunPoint.transform.right * 16.5f);
    }

    void RayCastingTarget(){
        RaycastHit2D hitInfo = Physics2D.Raycast(gunPoint.transform.position,gunPoint.transform.position + gunPoint.transform.right * 16.5f);
        if(hitInfo.collider != null){
            Component damagable = hitInfo.transform.GetComponent(typeof(IDamagable));
            if(damagable){
                (damagable as IDamagable).TakeDamage(damage);
            }
            Debug.Log(hitInfo.transform.tag);
        }
    }
}
