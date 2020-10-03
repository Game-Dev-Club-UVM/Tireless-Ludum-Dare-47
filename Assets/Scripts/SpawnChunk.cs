using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChunk : MonoBehaviour
{
    public List<GameObject> chunkPrefabs;
    public string centerPivotStr = "Center Piviot";
    public float minAngle = 0.05f;
    private GameObject centerPivot;

    public bool locked1 = false;
    public bool locked2 = false;

    public float offset = -10;

    private GameObject chunk1;
    private GameObject chunk2;
    private GameObject chunk3;
    private GameObject chunk4;

    // Start is called before the first frame update
    void Start()
    {
        centerPivot = GameObject.Find(centerPivotStr);
    }

    // Update is called once per frame
    void Update()
    {
        int randomChunk1 = Random.Range(0, chunkPrefabs.Count);
        int randomChunk2 = Random.Range(0, chunkPrefabs.Count);
        float pivotAngle = centerPivot.transform.rotation.y;
        
        // Check if player is entering any of the new chunks then replace the opposite one
        if (!locked1 && pivotAngle <= 0 + minAngle && pivotAngle >= 0 - minAngle) {
            locked1 = true;
            locked2 = false;
            Destroy(chunk1);
            Destroy(chunk2);
            chunk1 = Instantiate(chunkPrefabs[randomChunk1], new Vector3(0, 0, 0), Quaternion.Euler(0, 180 + offset, 0));
            chunk2 = Instantiate(chunkPrefabs[randomChunk2], new Vector3(0, 0, 0), Quaternion.Euler(0, 270 + offset, 0));
            Debug.Log("Refreshed chunks 1 & 2");
        }
        else if (!locked2 && (pivotAngle <= 1 + minAngle && pivotAngle >= 1 - minAngle) || (pivotAngle >= -1 - minAngle && pivotAngle <= -1 + minAngle))
        {
            locked1 = false;
            locked2 = true;
            Destroy(chunk3);
            Destroy(chunk4);
            chunk3 = Instantiate(chunkPrefabs[randomChunk1], new Vector3(0, 0, 0), Quaternion.Euler(0, 0 + offset, 0));
            chunk4 = Instantiate(chunkPrefabs[randomChunk2], new Vector3(0, 0, 0), Quaternion.Euler(0, 90 + offset, 0));
            Debug.Log("Refreshed chunks 3 & 4");
        }
    }
}
