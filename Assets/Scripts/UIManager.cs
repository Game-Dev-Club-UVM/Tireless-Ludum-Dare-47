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

	public TextMeshProUGUI ScoreText { get => scoreText;}
	public TextMeshProUGUI CoinText { get => coinText;}

	private RunnerPlayerMovement player;
	private void Awake()
	{
		player = FindObjectOfType<RunnerPlayerMovement>().GetComponent<RunnerPlayerMovement>();
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
		scoreAndCoin.SetActive(false);
		gameOver.SetActive(true);
		finalScoreText.text = ("Score: " + CalulateScore().ToString());
	}

	public void ResetGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
