using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour{
	[SerializeField]AudioSource soundManager;
	[SerializeField]AudioClip boomFX;
    private void Start() {
        soundManager.clip = boomFX;
        soundManager.Play();
    }
}
