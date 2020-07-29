using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BirdAttack : MonoBehaviour{	
    [SerializeField]private GameObject bulletPrefab;
	[SerializeField]private GameObject laserRenderer;
	[SerializeField]private Transform firePoint;
    [SerializeField]private string weaponType;
	[SerializeField]private AudioSource soundManager;
	[SerializeField]private AudioClip normalBulletFX;
	[SerializeField]private AudioClip laserFX;	
	private Laser laserController;
	private Animator anim;
	private float currentAttackDelay;
	private float weaponDuration;
	private bool shootAble;
	public string WeaponType{get{return weaponType;} set{weaponType = value;}}
	public float WeaponDuration{get{return weaponDuration;} set{weaponDuration = value;}}

	private void Start() {
		anim = GetComponent<Animator>();
		laserController = laserRenderer.gameObject.GetComponent<Laser>();
	}
	private void Update() {
		currentAttackDelay -= Time.deltaTime;
		weaponDuration -= Time.deltaTime;

		if(weaponDuration <= 0){
			weaponType = "";
		}

		if(currentAttackDelay <= 0){
			shootAble = true;
		}
	}
    public void StartShooting(){
		Debug.Log("Weapon : " + weaponType);
		if(shootAble){
			anim.SetTrigger("Shoot");
			switch(weaponType){
				case("Laser"):
					InitLaser();
					break;
				case("HomingMissile"):
					HomingMissile();
					break;
				case("MachineGun"):
					MachineGun();
					break;
				default:
					NormalBullet();
					break;
				}
		}
	}
    public void NormalBullet(){
		currentAttackDelay = bulletPrefab.GetComponent<BulletScript>().AttackDelay;
		shootAble = false;
		soundManager.clip = normalBulletFX;
		soundManager.Play();
        Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
    }
    public void InitLaser(){
		currentAttackDelay = Laser.AttackDelay;
		shootAble = false;
		soundManager.clip = laserFX;
		soundManager.Play();
		laserController.StartShooting();
	}
	public void MachineGun(){
		currentAttackDelay = 0.05f;
		shootAble = false;
		soundManager.clip = normalBulletFX;
		soundManager.Play();
		Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
	}
	public void HomingMissile(){
		//Implement Later ~
    }
}
