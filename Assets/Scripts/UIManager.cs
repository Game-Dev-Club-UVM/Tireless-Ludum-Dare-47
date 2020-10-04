using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
	TextMeshProUGUI scoreText;
	[SerializeField]
	TextMeshProUGUI coinText;

	[SerializeField]
	GameObject scoreAndCoin;
	[SerializeField]
	GameObject gameOver;

	[SerializeField]
	TextMeshProUGUI finalScoreText;

	private float timer;
	private bool running = true;
	
	private Rigidbody playerRB;	// put a rigidbody on gameObject Circle (centerPivot -> tireModel -> empty.001 -> circle)

	public TextMeshProUGUI ScoreText { get => scoreText;}
	public TextMeshProUGUI CoinText { get => coinText;}

	private RunnerPlayerMovement player;

	public Animator playerAnimator;	//  SET IN THE INSPECTOORRRRR TO TIRE MODEL
	private void Awake()
	{
		player = FindObjectOfType<RunnerPlayerMovement>().GetComponent<RunnerPlayerMovement>();
		playerRB = FindObjectOfType<Rigidbody>().GetComponent<Rigidbody>();

	}
	private void Update()
	{
		if (running)
		{
			SetScoreText(CalulateScore().ToString());
			timer += Time.deltaTime;
		}		
	}

	public void SetCoinText(string text)
	{
		coinText.text = text;
	}
	public void SetScoreText(string text)
	{
		scoreText.text = text;
	}
	public void AddCoin()
	{
		SetCoinText((Int32.Parse(coinText.text) + 1).ToString());
	}

	public int CalulateScore()
	{
		int time = (int)(timer * 10f);
		int coin = (Int32.Parse(coinText.text) * 100);
		return time + coin;
	}

	public void GameOver()
	{
		running = false;
		player.GameOver();
		playerAnimator.SetBool("gameOver", true);
		playerRB.isKinematic = false;
		scoreAndCoin.SetActive(false);
		gameOver.SetActive(true);
		finalScoreText.text = ("Score: " + CalulateScore().ToString());
	}

	public void ResetGame()
	{
		playerAnimator.SetBool("gameOver", false);
		playerRB.isKinematic = true;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
