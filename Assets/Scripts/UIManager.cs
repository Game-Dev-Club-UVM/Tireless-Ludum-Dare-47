using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField]
	TextMeshProUGUI scoreText;
	[SerializeField]
	TextMeshProUGUI coinText;

	private float timer;


	public TextMeshProUGUI ScoreText { get => scoreText;}
	public TextMeshProUGUI CoinText { get => coinText;}

	private void Update()
	{
		SetScoreText(CalulateScore().ToString());
		timer += Time.deltaTime;
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

}
