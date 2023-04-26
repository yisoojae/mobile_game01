using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clearPanel : MonoBehaviour
{
    float timer;
    byte number;
    public GameObject clear_UI, clear_text;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0; number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>1)
        {
            switch (number)
            {
                case 0:
                    {
                        GetComponentInChildren<Text>().text += "날아온 새 : " + ctrl.final_spawn + "마리";
                        number++;
                        timer = 0;
                        break;
                    }
                case 1:
                    {
                        GetComponentInChildren<Text>().text += "\n잡은 새 : " + ctrl.final_score + "마리";
                        number++;
                        timer = 0;
                        break;
                    }
                case 2:
                    {
                        GetComponentInChildren<Text>().text += "\n놓친 새 : " + (ctrl.final_spawn - ctrl.final_score) + "마리";
                        number++;
                        timer = 0;
                        break;
                    }
                case 3:
                    {
                        GetComponentInChildren<Text>().text += "\n빗나간 화살 : " + ctrl.final_missedarrow + "개";
                        number++;
                        timer = 0;
                        break;
                    }
                case 4:
                    {
                        clear_UI.SetActive(true);
                        clear_text.GetComponent<Text>().text = "적중률 " + ((float)ctrl.final_score / (float)ctrl.final_spawn * 100).ToString("F1") + "%";
                        Destroy(this);
                        break;
                    }
            }
        }
        timer += Time.deltaTime;
    }
}
