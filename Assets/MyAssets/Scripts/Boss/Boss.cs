using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IDamagable {
    [SerializeField] GameObject explosion;
    private Animator anim;
    private Rigidbody2D rb;
    private MobAndPickUpMovement movement;
    public Animator Anim { get { return anim; } }
    private bool stop;
    public bool Stop { get { return stop; } }
    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
        movement = GetComponent<MobAndPickUpMovement> ();
        anim = GetComponent<Animator> ();
        stop = false;
    }
    public void TakeDamage (float damage) {
        hp -= damage;
        if (hp <= 0) {
            StartCoroutine (Die ());
            GameManager.instance.BossDied ();
        }
    }
    public IEnumerator Die () {
        GameManager.instance.ScoreIncrement ();
        anim.SetTrigger ("Die");
        movement.VerticalMobMovement = 0;
        rb.gravityScale = 10;
        yield return new WaitForSeconds (2.0f);
        Instantiate (explosion, transform.position, Quaternion.identity);
        Destroy (gameObject);
    }

    [SerializeField] private float hp = 100;
    public float HP { get { return hp; } set { hp = value; } }
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("StopHere")) {
            movement.HorizontalMobMovement = 0;
            stop = true;
        }
        if (other.CompareTag ("BossWarning")) {
            if (GameManager.instance.gameOver) {
                Destroy (gameObject);
            } else {
                GameManager.instance.BossAppear ();
            }
        }
    }
}