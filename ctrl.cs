using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ctrl : MonoBehaviour
{
    public GameObject ball01, ball02, ball03, ball04, ball05, ball06, ball07, ball08, ball09, arrow, arrowCount;
    public static GameObject[] ball = new GameObject[3];
    public float timer, time_escape, time_shot;

    public Sprite[] bow_sprites;
    SpriteRenderer bow_spriteRenderer;

    public static int arrowCount_UI, score_UI, stageLevel;
    
    //tmp
    int bird_value, bird_random;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1; time_escape = 0; time_shot = 0;
        bow_spriteRenderer = GameObject.FindWithTag("bow").GetComponent<SpriteRenderer>();
        bow_spriteRenderer.sprite = bow_sprites[0];

        arrowCount_UI = define.maxArrow[0]; score_UI = 0; stageLevel = 1;
        
        arrowCountRefresh();
        GameObject.FindWithTag("score").GetComponent<Text>().text = "" + score_UI + " / " + define.maxScore[ctrl.stageLevel - 1];
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

        if (timer > define.bird_setTime)
        {
            for (int i = 0; i < ball.Length; i++)
            {
                if (ball[i] != null) continue;
                if (stageLevel == 1) bird_value = 1;
                else if (stageLevel == 2)
                {
                    bird_random = Random.Range(0, 4);
                    bird_value = bird_random + 1;
                }
                else if (stageLevel == 3)
                {
                    bird_random = Random.Range(0, 8);
                    if (bird_random > 5) bird_value = 6;
                    else if (bird_random > 3) bird_value = 5;
                    else bird_value = bird_random + 1;
                }
                else if (stageLevel == 4)
                {
                    bird_random = Random.Range(0, 12);
                    if (bird_random > 9) bird_value = 8;
                    else if (bird_random > 7) bird_value = 7;
                    else if (bird_random > 5) bird_value = 6;
                    else if (bird_random > 3) bird_value = 5;
                    else bird_value = bird_random + 1;
                }
                else if (stageLevel == 5)
                {
                    bird_random = Random.Range(0, 14);
                    if (bird_random > 11) bird_value = 9;
                    else if (bird_random > 9) bird_value = 8;
                    else if (bird_random > 7) bird_value = 7;
                    else if (bird_random > 5) bird_value = 6;
                    else if (bird_random > 3) bird_value = 5;
                    else bird_value = bird_random + 1;
                }
                if (bird_value == 1) ball[i] = Instantiate(ball01, new Vector2(-3.5f, 2.2f), Quaternion.identity);
                else if (bird_value == 2) ball[i] = Instantiate(ball02, new Vector2(-3.5f, 2.2f), Quaternion.identity);
                else if (bird_value == 3) ball[i] = Instantiate(ball03, new Vector2(-3.5f, 2.2f), Quaternion.identity);
                else if (bird_value == 4) ball[i] = Instantiate(ball04, new Vector2(-3.5f, 2.2f), Quaternion.identity);
                else if (bird_value == 5) ball[i] = Instantiate(ball05, new Vector2(-3.5f, 2.2f), Quaternion.identity);
                else if (bird_value == 6) ball[i] = Instantiate(ball06, new Vector2(-3.5f, 2.2f), Quaternion.identity);
                else if (bird_value == 7) ball[i] = Instantiate(ball07, new Vector2(3.5f, 2.2f), Quaternion.identity);
                else if (bird_value == 8) ball[i] = Instantiate(ball08, new Vector2(3.5f, 2.2f), Quaternion.identity);
                else if (bird_value == 9) ball[i] = Instantiate(ball09, new Vector2(-3.5f, 2.2f), Quaternion.identity);
                timer = 0;
                ball[i].GetComponent<ball>().bird_value = bird_value;
                ball[i].GetComponent<ball>().bird_num = i;
                break;
            }
        }
        

        timer += Time.deltaTime;

        if (Input.touchCount > 0 && arrowCount_UI > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (time_shot + define.arrow_cooldown < Time.time)
                {
                    time_shot = Time.time;
                    bow_spriteRenderer.sprite = bow_sprites[0];
                    Instantiate(arrow, new Vector2(1.1f, -3.2f), Quaternion.identity);
                    arrowCount_UI--;
                    arrowCountRefresh();
                }
            }
        }
        if (bow_spriteRenderer.sprite != bow_sprites[2])
        {
            if (time_shot + define.arrow_cooldown < Time.time) bow_spriteRenderer.sprite = bow_sprites[2];
            else if (time_shot + define.arrow_cooldown / 2 < Time.time) bow_spriteRenderer.sprite = bow_sprites[1];
        }
    }

    public void arrowCountRefresh()
    {
        arrowCount.GetComponent<Text>().text = "" + arrowCount_UI;
    }
}
