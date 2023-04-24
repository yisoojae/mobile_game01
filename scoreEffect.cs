using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreEffect : MonoBehaviour
{
    float timer;
    Color scoreColor;
    // Start is called before the first frame update
    void Start()
    {
        timer += Time.time;
        scoreColor = GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer + 0.75f < Time.time)
        {
            scoreColor.a = (1 - Time.time + timer) * 4;
            GetComponent<Text>().color = scoreColor;
            if (timer + 1 < Time.time)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
