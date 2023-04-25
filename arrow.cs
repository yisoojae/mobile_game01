using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class arrow : MonoBehaviour
{
    public GameObject feather_particle, scorePrefab;
    public ParticleSystem featherParticle_P;

    //tmp
    GameObject a;
    ParticleSystem.MainModule mainModule_F;
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
            mainModule_F = featherParticle_P.main;
            switch (collision.GetComponent<ball>().bird_value)
            {
                case 1:
                    mainModule_F.startColor = new Color(1, 0.5f, 0);
                    mainModule_F.startSize = 1;
                    break;
                case 2:
                    mainModule_F.startColor = Color.red;
                    mainModule_F.startSize = 0.5f;
                    break;
                case 3:
                    mainModule_F.startColor = new Color(1, 1, 200 / 255f);
                    mainModule_F.startSize = 0.5f;
                    break;
                case 4:
                    mainModule_F.startColor = Color.black;
                    mainModule_F.startSize = 0.5f;
                    break;
                case 5:
                    mainModule_F.startColor = new Color(1, 192 / 255f, 0);
                    mainModule_F.startSize = 0.5f;
                    break;
                case 6:
                    mainModule_F.startColor = Color.cyan;
                    mainModule_F.startSize = 0.5f;
                    break;
                case 7:
                    mainModule_F.startColor = Color.yellow;
                    mainModule_F.startSize = 0.5f;
                    break;
                case 8:
                    mainModule_F.startColor = Color.gray;
                    mainModule_F.startSize = 0.6f;
                    break;
                case 9:
                    mainModule_F.startColor = new Color(1, 1, 0.5f);
                    mainModule_F.startSize = 0.9f;
                    break;
            }
            Instantiate(feather_particle, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            ctrl.ball[collision.GetComponent<ball>().bird_num] = null;
            a = Instantiate(scorePrefab, collision.transform.position, Quaternion.identity, GameObject.FindWithTag("Canvas").transform);
            if (collision.GetComponent<ball>().bird_value == 9)
            {
                ctrl.score_UI += 4;
                a.GetComponent<Text>().text = "+ 4";
            }
            else if (collision.GetComponent<ball>().bird_value > 6)
            {
                ctrl.score_UI += 3;
                a.GetComponent<Text>().text = "+ 3";
            }
            else if (collision.GetComponent<ball>().bird_value > 4)
            {
                ctrl.score_UI += 2;
                a.GetComponent<Text>().text = "+ 2";
            }
            else
            {
                ctrl.score_UI++;
                a.GetComponent<Text>().text = "+ 1";
            }
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
                    ctrl.isLevelUpEffect = true;
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
