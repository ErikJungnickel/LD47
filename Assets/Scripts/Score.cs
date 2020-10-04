using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    private float score = 0;

    private float scoreIncreaseThreshold = 2;
    private float time = 0;

    private static Score _instance;

    public static Score Instance { get { return _instance; } }

    public bool isDead = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;

        }
        text.text = "" + 0;
    }
    
    void Update()
    {
        time += Time.deltaTime;
        if(time >= scoreIncreaseThreshold && !isDead)
        {
            time = 0;
            score++;
            text.text = ""+score;
        }
    }
}
