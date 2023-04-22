using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    float speed, height, timer;
    public int bird_num, bird_value;
    void Start()
    {
        speed = (Random.Range(0, 9) / 4f + 2f) / 45;
        if (bird_value == 9) speed *= 1.8f;
        else if (bird_value > 6) speed *= -1;
        else if (bird_value > 4) speed *= 1.35f;
        else if (bird_value > 1) speed *= 1.15f;
        height = Random.Range(0, 10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (height < 5) this.transform.position = new Vector2(this.transform.position.x + speed, this.transform.position.y + 0.05f);
        else this.transform.position = new Vector2(this.transform.position.x + speed, this.transform.position.y - 0.05f);
        if (this.transform.position.x > 5) Destroy(this.gameObject);
        if (timer + 0.1f < Time.time)
        {
            if (height == 9) height = 0;
            else height++;
            timer = Time.time;
        }
    }

    void destryBall()
    {
        Destroy(this);
    }
}
