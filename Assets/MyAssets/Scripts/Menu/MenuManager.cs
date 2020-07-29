using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour{
	public static MenuManager instance;
    [SerializeField]Button startButton;
    [SerializeField]Button campaignButton;
    [SerializeField]Button endlessButton;
    [SerializeField]AudioSource soundManager;
    private void Awake() {
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}
    private void Start() {
        soundManager.Play();
    }
    public void ToSelectMode(){
        startButton.gameObject.SetActive(false);
        campaignButton.gameObject.SetActive(true);
        endlessButton.gameObject.SetActive(true);
        
    }
    public void QuitTheGame(){
        Application.Quit();
    }

    public void ToCampaign(){
        SceneManager.LoadScene("Campaign");
    }

    public void ToEndless(){
        SceneManager.LoadScene("Endless");
    }
}
