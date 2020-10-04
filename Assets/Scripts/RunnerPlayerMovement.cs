using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RunnerPlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject Center;
    public GameObject Player;

    public float rotateSpeed = 5f;
    [SerializeField]
    float speed;
    public float playerMoveDistance = 5f;
    private int playerMoveState = 1; //0 left, 1 middle, 2 right
    private bool hasMoved = false;
    private bool running = true;
    void Update()
    {
        if (!running) { return; };
        float jump = Input.GetAxisRaw("Vertical");
        float movement = Input.GetAxisRaw("Horizontal");
		if (!hasMoved && movement != 0)
		{
            hasMoved = true;
            if (movement > 0 && playerMoveState != 0)
            {
                //move left
                Player.transform.Translate(new Vector3(0, 0, -playerMoveDistance));
                playerMoveState--;
            }
            else if (movement < 0 && playerMoveState != 2)
            {
                //move right
                Player.transform.Translate(new Vector3(0, 0, playerMoveDistance));
                playerMoveState++;
            }
		}
		else if(hasMoved && movement == 0)
		{
            hasMoved = false;
        }
        //rotateSpeed += Time.deltaTime;
        //speed = Mathf.Atan(rotateSpeed /100) ;
        //Rotates the player around the map
        //Center.transform.Rotate(new Vector3(0, speed, 0));

        rotateSpeed += Time.deltaTime;
        Center.transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }
    public void GameOver()
	{
        running = false;
    }
}
