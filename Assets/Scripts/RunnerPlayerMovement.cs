using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RunnerPlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject Center;
    public GameObject Player;
    public Transform JumpTarget;
    [SerializeField]
    Transform groundCheck;
    private float groundDistance = 0.005f;
    public LayerMask groundMask;

    public float rotateSpeed = 5f;
    [SerializeField]
    float speed;
    public float playerMoveDistance = 5f;
    public float playerJumpDistance = 5f;
    public float playerFallSpeed = 5f;

    private int playerMoveState = 1; //0 left, 1 middle, 2 right
    private bool hasMoved = false;
    private bool isGrounded = true;
    private bool running = true;

    private trailScript trailScript;

    private void Awake() {
        trailScript = GetComponentInChildren<trailScript>();
    }

    void Update()
    {
        if (!running) { return; };
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
        {
            trailScript.startEmitting();
        }

        float movement = Input.GetAxisRaw("Horizontal");
		if (!hasMoved && isGrounded && movement != 0)
		{
            hasMoved = true;
            if (movement > 0 && playerMoveState != 0)
            {
                //move left
                Player.transform.Translate(new Vector3(0, 0, -playerMoveDistance));
                playerMoveState--;
            }
            else if (movement < 0 && isGrounded && playerMoveState != 2)
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
        float jump = Input.GetAxisRaw("Vertical");
        if (!hasMoved && isGrounded && jump > 0)
		{
            trailScript.stopEmitting();
            JumpTarget.Translate(new Vector3(0, playerJumpDistance, 0));
            playerFallSpeed = 1;
        }
        else if (!isGrounded)
		{
            JumpTarget.Translate(new Vector3(0, -playerFallSpeed * Time.deltaTime, 0));
            playerFallSpeed += (playerFallSpeed + 7) * Time.deltaTime;
            if (JumpTarget.position.y < 0.5)
			{
                JumpTarget.position =new Vector3(0,.5f, 0);
			}

        }
        // Rotates the player around the map
        rotateSpeed += Time.deltaTime;
        //speed = Mathf.Atan(rotateSpeed /100) ;
        //Center.transform.Rotate(new Vector3(0, speed, 0));
        if(rotateSpeed < 2000)
		{
            speed = Mathf.Clamp(-0.0001f * ((rotateSpeed) * (rotateSpeed)) + 0.2298f * (rotateSpeed) + 2.5609f, 10, 130);
		}
		else
		{
            speed = 130f;
		}

        //Linear speed
        //rotateSpeed += Time.deltaTime;
        Center.transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    public void GameOver()
	{
        trailScript.stopEmitting();
        running = false;
    }

    public bool getIsGrounded()
    {
        return isGrounded;
    }
}
