using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldTimer : MonoBehaviour
{
    public float ResetTime = 30;
    [SerializeField]
    private float TimeElipsed = 0;

    // Update is called once per frame
    void Update()
    {
        TimeElipsed += Time.deltaTime;

        if(TimeElipsed>= ResetTime)
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }
}
