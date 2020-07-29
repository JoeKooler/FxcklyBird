using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAndPickUpMovement : MonoBehaviour{
    private Rigidbody2D rb;
    private float tempNum;
    [SerializeField]private float maxY;
    [SerializeField]private float minY;
    [SerializeField]private Vector2 mobMovement;
    [SerializeField]private bool isUp;
    public float HorizontalMobMovement{get{return mobMovement.x;} set{mobMovement.x = value;}}
    public float VerticalMobMovement{get{return mobMovement.y;} set{mobMovement.y = value;}}
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        tempNum = transform.position.y;
        Debug.Log("MaxY = " + maxY + "MinY = " + minY);
        maxY = transform.position.y + maxY; 
        minY = transform.position.y - minY;
        isUp = true;
    }
    private void FixedUpdate() {
        rb.velocity = mobMovement;
        tempNum = transform.position.y;
        Debug.Log(tempNum);
        if(tempNum > maxY && isUp == true){
            mobMovement.y *= -1;
            isUp = false;
        }else if(tempNum < minY && isUp == false){
            mobMovement.y *= -1;
            isUp = true;
        }
    }
}