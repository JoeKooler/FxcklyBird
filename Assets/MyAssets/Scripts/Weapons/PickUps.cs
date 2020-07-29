using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps:MonoBehaviour{
    [SerializeField]private string weaponType;
    public string WeaponType{get{return weaponType;} set{weaponType = value;}}
}
