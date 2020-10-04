using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public Transform coinGFX;

    [SerializeField]
    float bobDistance = .5f;
    [SerializeField]
    float rotateSpeed = 2f;
    [SerializeField]
    float bobSpeed = 1f;

	bool isGoingUp;

	float startPos;

	private UIManager uiManager;
	private void Awake()
	{
		uiManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
		startPos = coinGFX.position.y;
		isGoingUp = Random.Range(0, 2) == 0;
	}

	// Update is called once per frame
	void Update()
    {
		RotateCoin();

	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			uiManager.AddCoin();
			Destroy(gameObject);
		}
	}

    void RotateCoin()
	{
		coinGFX.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
		if (isGoingUp)
		{
			coinGFX.Translate(new Vector3(0, bobSpeed * Time.deltaTime, 0));
		}
		else
		{
			coinGFX.Translate(new Vector3(0, -bobSpeed * Time.deltaTime, 0));
		}

        if(coinGFX.position.y >= startPos + bobDistance)
		{
			isGoingUp = false;
		}
		else if(coinGFX.position.y <= startPos - bobDistance)
		{
			isGoingUp = true;
		}
	}
}
