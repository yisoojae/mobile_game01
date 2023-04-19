using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    float speed, n;
    void Start()
    {
        speed = Random.Range(0, 9) / 4f + 2f; n = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector2(this.transform.position.x + speed / 45 * n, this.transform.position.y);
        if (this.transform.position.x > 5) Destroy(this.gameObject);
    }
}
