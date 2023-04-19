using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    // Start is called before the first frame update
    float n;
    void Start()
    {
        n = 12 / 40f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + n);
        if (this.transform.position.y > 6) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
