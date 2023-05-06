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
                        GetComponentInChildren<Text>().text += "���ƿ� �� : " + ctrl.final_spawn + "����";
                        number++;
                        timer = 0;
                        break;
                    }
                case 1:
                    {
                        GetComponentInChildren<Text>().text += "\n���� �� : " + ctrl.final_score + "����";
                        number++;
                        timer = 0;
                        break;
                    }
                case 2:
                    {
                        GetComponentInChildren<Text>().text += "\n��ģ �� : " + (ctrl.final_spawn - ctrl.final_score) + "����";
                        number++;
                        timer = 0;
                        break;
                    }
                case 3:
                    {
                        GetComponentInChildren<Text>().text += "\n������ ȭ�� : " + ctrl.final_missedarrow + "��";
                        number++;
                        timer = 0;
                        break;
                    }
                case 4:
                    {
                        clear_UI.SetActive(true);
                        clear_text.GetComponent<Text>().text = "���߷� " + ((float)ctrl.final_score / (float)ctrl.final_spawn * 100).ToString("F1") + "%";
                        Destroy(this);
                        break;
                    }
            }
        }
        timer += Time.deltaTime;
    }
}
