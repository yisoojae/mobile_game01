using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + define.bird_heightBound);
        if (this.transform.position.y > 6) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            if (collision.GetComponent<ball>().bird_value == 9) ctrl.score_UI += 4;
            else if (collision.GetComponent<ball>().bird_value > 6) ctrl.score_UI += 3;
            else if (collision.GetComponent<ball>().bird_value > 4) ctrl.score_UI += 2;
            else ctrl.score_UI++;
            if (ctrl.score_UI >= define.maxScore[ctrl.stageLevel - 1])
            {
                if (ctrl.stageLevel == 5)
                {
                    GameObject.FindWithTag("MainCamera").GetComponent<ctrl>().gameClear();
                }
                else
                {
                    for (int i = 0; i < ctrl.ball.Length; i++)
                    {
                        if (ctrl.ball[i] != null)
                        {
                            Destroy(ctrl.ball[i]);
                            ctrl.ball[i] = null;
                        }
                    }
                    ctrl.stageLevel++;
                    ctrl.score_UI = 0;
                    ctrl.arrowCount_UI = define.maxArrow[ctrl.stageLevel - 1];
                    GameObject.FindWithTag("MainCamera").GetComponent<ctrl>().arrowCountRefresh();
                    GameObject.FindWithTag("MainCamera").GetComponent<ctrl>().timer = 0;
                    GameObject.FindWithTag("MainCamera").GetComponent<ctrl>().levelUp_ani();
                }
            }
            GameObject.FindWithTag("score").GetComponent<Text>().text = "" + ctrl.score_UI + " / " + define.maxScore[ctrl.stageLevel - 1];
        }
    }
}
