using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ctrl : MonoBehaviour
{
    public GameObject ball, arrow, arrowCount;
    float timer, time_escape, time_shot;

    public Sprite[] bow_sprites;
    SpriteRenderer bow_spriteRenderer;

    public static int arrowCount_UI, score_UI;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1; time_escape = 0; time_shot = 0;
        bow_spriteRenderer = GameObject.FindWithTag("bow").GetComponent<SpriteRenderer>();
        bow_spriteRenderer.sprite = bow_sprites[0];

        arrowCount_UI = 30; score_UI = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home))
            {
                //home button
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                if (time_escape > Time.time - 2) Application.Quit();
                else time_escape = Time.time;
            }
            else if (Input.GetKey(KeyCode.Menu))
            {
                //menu button
            }
        }

        if (timer > 2)
        {
            Instantiate(ball, new Vector2(-3.5f, 2.2f), Quaternion.identity);
            timer = 0;
        }
        

        timer += Time.deltaTime;

        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (time_shot + 0.5f < Time.time)
                {
                    time_shot = Time.time;
                    bow_spriteRenderer.sprite = bow_sprites[0];
                    Instantiate(arrow, new Vector2(1.1f, -3.2f), Quaternion.identity);
                    arrowCount_UI--;
                    arrowCount.GetComponent<Text>().text = "" + arrowCount_UI;
                }
            }
        }
        if (bow_spriteRenderer.sprite != bow_sprites[2])
        {
            if (time_shot + 0.5f < Time.time) bow_spriteRenderer.sprite = bow_sprites[2];
            else if (time_shot + 0.25f < Time.time) bow_spriteRenderer.sprite = bow_sprites[1];
        }
    }
}
