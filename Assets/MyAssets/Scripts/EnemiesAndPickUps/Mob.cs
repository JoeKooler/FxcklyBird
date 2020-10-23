using System.Collections;
using UnityEngine;

public class Mob : MonoBehaviour, IDamagable {
    [SerializeField] GameObject explosion;
    public void TakeDamage (float damage) {
        hp -= damage;
        if (hp <= 0) {
            GameManager.instance.ScoreIncrement ();
            Destroy (gameObject);
            Instantiate (explosion, transform.position, Quaternion.identity);
        }
    }

    [SerializeField] private float hp = 10;
    public float HP { get { return hp; } set { hp = value; } }
    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.CompareTag ("DestroyZone")) {
            Destroy (gameObject);
        }
    }
}