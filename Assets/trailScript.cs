using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailScript : MonoBehaviour
{

    private TrailRenderer trail;
    public Transform playerTransform;
    public RunnerPlayerMovement runnerScript;

    private void Awake() {
        playerTransform = GameObject.Find("TireModel").GetComponent<Transform>();
        trail = GetComponent<TrailRenderer>();
        runnerScript = FindObjectOfType<RunnerPlayerMovement>();
    }
    private void FixedUpdate() {

            transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }

    public void stopEmitting(){
        trail.emitting = false;
    }

    public void startEmitting(){
        trail.emitting = true;
    }
}
