using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimateText : MonoBehaviour {

    String prelude;
    String loc = "\nC:User\\Octocat>";
    String carrot = "_";
    String userSelection = "";
    Boolean animDone = false;

    public void Start()
    {
        StartCoroutine(animateTxt());
    }

    public void Update()
    {
        if (!animDone) return;
        Text txt = gameObject.GetComponent<Text>();
        int frameCount = Time.frameCount;

        if (frameCount % 30 == 0)
        {
            if (carrot.Equals("_"))
            {
                carrot = "";
            }
            else
            {
                carrot = "_";
            }
        }

        if(frameCount % 1 == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                int lv = Int32.Parse(userSelection);
				if (lv == 1)
					SceneManager.LoadScene ("Test");
				else if (lv == 2)
					SceneManager.LoadScene ("AssAbyss");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                userSelection += "1";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                userSelection += "2";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                userSelection += "3";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                userSelection += "4";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                userSelection += "5";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                userSelection += "6";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                userSelection += "7";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                userSelection += "8";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                userSelection += "9";
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if(userSelection.Length >= 1)
                {
                    userSelection = userSelection.Remove(userSelection.Length - 1);

                }
            }
            else
            {
            }

            txt.text = prelude + loc + userSelection + carrot;
        }
    }

    private IEnumerator animateTxt()
    {
        Text txt = gameObject.GetComponent<Text>();
        string strComplete = txt.text;
        txt.color =  Color.white;
        txt.text = "";
        int i = 0;

        while (i < strComplete.Length)
        {
            txt.text += strComplete[i++];
            yield return new WaitForSeconds(.1F);
        }
        prelude = txt.text;
        animDone = true;
    }
}
