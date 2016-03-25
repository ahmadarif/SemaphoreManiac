using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlphabetInputListener : MonoBehaviour {
    // Attach to a game object with string proper
    // Change a string variable based on keyboard
    // GetComponent<Text>().text

    public int maxStringLength;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //listen input keyboard trus ngubah string di input sesuai dengan inputan
        foreach (char c in Input.inputString)
        {
            if (c == '\b')
            {
                //delete char
                if (GetComponent<Text>().text.Length > 0)
                {
                    GetComponent<Text>().text = GetComponent<Text>().text.Substring(0, GetComponent<Text>().text.Length - 1);
                }
            }
            else if (c == '\n' || c == '\r')
            {
                //trigger action
                GetComponent<Text>().text = "";
            }
            else if (GetComponent<Text>().text.Length < maxStringLength)
            {
                //append char
                if (c >= 'a' && c <= 'z')
                {
                    GetComponent<Text>().text += c;
                    GetComponent<Text>().text = GetComponent<Text>().text.ToUpper();
                }
            }
        }
    }
}
