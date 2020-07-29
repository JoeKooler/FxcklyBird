using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public AudioSource soundManager;
	public AudioClip maintheme;
	public AudioClip bosstheme;
	public AudioClip birdDieTheme;
	public Text pauseText;
	public Text gameOverText;
	public Text thanksText;
	public Button retryButton;
	public Button pauseButton;
	public Button continueButton;
	public Button menuButton;
	public GameObject spawner;
	public static GameManager instance;
	public Text scoreText;						
	private int score = 0;					
	public bool gameOver = false;				
	void Awake(){
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}
	private void Start() {
		soundManager.clip = maintheme;
		soundManager.Play();
	}
	public void BirdDied(){
		gameOver = true;
		soundManager.clip = birdDieTheme;
		soundManager.Play();
		int highScore = PlayerPrefs.GetInt("HighScore");
		retryButton.gameObject.SetActive(true);
		if(spawner != null){
			spawner.SetActive(false);
		}
		Debug.Log(highScore);
		if(score > highScore){
			PlayerPrefs.SetInt("HighScore",score);
			highScore = score;
		}
		if(scoreText!= null){
			scoreText.text = "HighScore : " + highScore;
		}
	}
	public void ScoreIncrement(){
		if(scoreText != null){
			score++;
			scoreText.text = score.ToString();
		}
	}
	public void BossDied(){
		StartCoroutine(TextThenLoad());
	}

	public IEnumerator TextThenLoad(){
		gameOverText.gameObject.SetActive(true);
		gameOverText.gameObject.GetComponent<Animator>().SetTrigger("BossDie");
		yield return new WaitForSeconds(2f);
		thanksText.gameObject.SetActive(true);
		thanksText.gameObject.GetComponent<Animator>().SetTrigger("BossDie");
		yield return new WaitForSeconds(10f);
		SceneManager.LoadScene("Menu");
	}

	public void gameRestart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void BossAppear(){
		soundManager.clip = bosstheme;
		soundManager.Play();
	}

	public void ToMenu(){
		Time.timeScale = 1;
		SceneManager.LoadScene("Menu");
	}
	public void Pause(){
		pauseButton.gameObject.SetActive(false);
		continueButton.gameObject.SetActive(true);
		pauseText.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void UnPause(){
		continueButton.gameObject.SetActive(false);
		pauseButton.gameObject.SetActive(true);
		pauseText.gameObject.SetActive(false);
		Time.timeScale = 1;
	}
}
