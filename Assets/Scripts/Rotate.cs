using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float maxSpeed = 30;
    public float rotationSpeed = 5;
    private float speedIncreaseThreshold = 2;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= speedIncreaseThreshold && rotationSpeed < maxSpeed)
        {
            rotationSpeed += 0.3f;
            time = 0;
        }

        transform.Rotate(new Vector3(0, 0, 1), -5 * rotationSpeed * Time.deltaTime);
    }
}
