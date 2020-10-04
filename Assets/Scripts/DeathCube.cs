using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float xVal = Random.Range(3, 8);
        float yVal = Random.Range(3, 8);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(xVal, yVal), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
