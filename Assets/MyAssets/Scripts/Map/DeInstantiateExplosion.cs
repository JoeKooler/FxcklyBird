using UnityEngine;
public class DeInstantiateExplosion : MonoBehaviour{
    [SerializeField]private Animator anim;
    private void Start() {
        anim = GetComponentInChildren<Animator>();
    }
    private void Update() {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Die")){
            Destroy(gameObject);
        }
    }
}
