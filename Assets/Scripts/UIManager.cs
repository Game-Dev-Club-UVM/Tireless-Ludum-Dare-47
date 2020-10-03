using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshPro scoreText;
	[SerializeField]
	TextMeshPro coinText;

	private float timer;


	public TextMeshPro ScoreText { get => scoreText;}
	public TextMeshPro CoinText { get => coinText;}

	private void Update()
	{
		
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
}
