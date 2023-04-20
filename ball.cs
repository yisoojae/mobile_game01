using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    float speed, times, height, timer;
    void Start()
    {
        speed = Random.Range(0, 9) / 4f + 2f; times = 1;
        height = Random.Range(0, 10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (height < 5) this.transform.position = new Vector2(this.transform.position.x + speed / 45 * times, this.transform.position.y + 0.05f);
        else this.transform.position = new Vector2(this.transform.position.x + speed / 45 * times, this.transform.position.y - 0.05f);
        if (this.transform.position.x > 5) Destroy(this.gameObject);
        if (timer + 0.1f < Time.time)
        {
            if (height == 9) height = 0;
            else height++;
            timer = Time.time;
        }
    }
}
