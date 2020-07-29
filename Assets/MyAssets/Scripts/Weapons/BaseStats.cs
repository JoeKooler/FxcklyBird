using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStats{
    [SerializeField]private string weaponType;
    [SerializeField]private float damage;
    [SerializeField]private float attackDelay;
    [SerializeField]private float attackDuration;
    [SerializeField]private float weaponDuration;
    [SerializeField]private bool isDead;
    
    public string WeaponType{get{return weaponType;} set{weaponType = value;}}
    public float Damage{get{return damage;} set{damage = value;}}
    public float AttackDelay{get{return attackDelay;} set{attackDelay = value;}}
    public float AttackDuration{get{return attackDuration;} set{attackDuration = value;}}
    public float WeaponDuration{get{return weaponDuration;} set{weaponDuration = value;}}
    public bool IsDead{get{return isDead;} set{isDead = value;}}
}
