using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailScript : MonoBehaviour
{


    public Transform playerTransform;
    private void Awake() {
        playerTransform = GameObject.Find("TireModel").GetComponent<Transform>();
    }
    private void FixedUpdate() {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }
}
