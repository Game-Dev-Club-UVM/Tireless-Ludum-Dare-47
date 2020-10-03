using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	private UIManager uiManager;
	private void Awake()
	{
		uiManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
	}
	private void OnTriggerEnter(Collider other)
	{
		uiManager.GameOver();
	}
}
