using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class TextGeneratorScript : MonoBehaviour {
    public int maxTextOnScreen;
    public GameObject textGameObject;

    public float generateDelay;
    float curTime;

    float ortoWidth;
    float ortoHeight;

	// Use this for initialization
	void Start () {
        curTime = 0;
        ortoHeight = 2 * Camera.main.orthographicSize;
        ortoWidth = ortoHeight * Camera.main.aspect;
        
	}
	
	// Update is called once per frame
	void Update () {
        curTime += Time.deltaTime;
        if (curTime > generateDelay)
        {
            if (transform.childCount < maxTextOnScreen)
            {
                GameObject newText = (GameObject) Instantiate(textGameObject);
                newText.transform.SetParent(transform);
                newText.transform.localScale = new Vector3 (1, 1, 1);
                newText.transform.position = new Vector3(Random.Range(10, Screen.width - 150), Screen.height);
            }
            curTime = 0;
        }
    }

    public void cek()
    {
        //destroy kalo ada kata di layar yang bener
        bool isMatch = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<TextBehavior>().textRemaining == "")
            {
                //Debug.Log("beneeeer");
                ScoreManager.increment(10);
                transform.GetChild(i).GetComponent<TextBehavior>().destroy();
                transform.parent.FindChild("InputText").GetComponent<Text>().text = "";
                isMatch = true;
                break;
            }
        }
        if (!isMatch)
        {
            //Debug.Log("salaaaah");
            HeartManager.decrement();
        }
    }
}
