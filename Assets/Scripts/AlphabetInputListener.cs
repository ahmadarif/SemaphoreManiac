using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Thalmic.Myo;

public class AlphabetInputListener : MonoBehaviour {
    
    public int maxStringLength;
    public bool isUseKeyboard = true;

    private DancematController danceMat;
    private ThalmicMyo myo = null;
    private Text inputText;
    private TextGeneratorScript textGenerator;

    private const float MAX_TIME = 1.0f;

    private string lastChar = "";
    private float inputTimeLeft = MAX_TIME;

    private Pose lastPose = Pose.Unknown;
    private float deleteTimeLeft = MAX_TIME;
    
    void Start () 
    {
        if (!isUseKeyboard)
        {
            danceMat = GetComponent<DancematController>();
            myo = GameObject.Find("Myo").GetComponent<ThalmicMyo>();
        }


        inputText = GetComponent<Text>();
        textGenerator = transform.parent.FindChild("TextGenerator").GetComponent<TextGeneratorScript>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isUseKeyboard)
        {
            danceMatAction();
            myoAction();
        }
        else
        {
            keyboardAction();
        }

    }

    private void danceMatAction()
    {
        // input huruf dari Dancemat
        if (danceMat.huruf == "")
        {
            inputTimeLeft = MAX_TIME;
            lastChar = danceMat.huruf;
        }
        else
        {
            inputTimeLeft -= Time.deltaTime;

            if (danceMat.huruf != lastChar)
            {
                inputTimeLeft = MAX_TIME;
                lastChar = danceMat.huruf;
            }
            else
            {
                if (inputTimeLeft < 0)
                {
                    inputText.text += lastChar;
                    inputTimeLeft = MAX_TIME;
                }
            }
        } //> input huruf dari Dancemat
    }

    private void myoAction()
    {
        // hapus karakter menggunakan pose WaveIn
        if (myo.pose == Pose.Unknown || myo.pose == Pose.Rest)
        {
            deleteTimeLeft = MAX_TIME;
            lastPose = myo.pose;
        }
        else
        {
            deleteTimeLeft -= Time.deltaTime;

            if (myo.pose != lastPose)
            {
                deleteTimeLeft = MAX_TIME;
                lastPose = myo.pose;
            }
            else
            {
                if (deleteTimeLeft < 0)
                {
                    if (lastPose == Pose.WaveIn)
                    {
                        if (inputText.text.Length > 0)
                        {
                            inputText.text = inputText.text.Substring(0, inputText.text.Length - 1);
                        }
                    }
                    else if (lastPose == Pose.Fist)
                    {
                        textGenerator.cek();
                    }

                    deleteTimeLeft = MAX_TIME;
                }
            }
        } //> hapus karakter menggunakan pose WaveIn
    }

    private void keyboardAction()
    {
        //listen input keyboard trus ngubah string di input sesuai dengan inputan
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // delete or backspace
            {
                //delete char
                if (GetComponent<Text>().text.Length > 0)
                {
                    inputText.text = inputText.text.Substring(0, inputText.text.Length - 1);
                }
            }
            else if (c == '\n' || c == '\r') // enter
            {
                //trigger action
                Debug.Log("Hai");
                textGenerator.cek();
                inputText.text = "";
            }

            // append char
            if (inputText.text.Length < maxStringLength)
            {
                if (c >= 'a' && c <= 'z') 
                {
                    inputText.text += c;
                    inputText.text = inputText.text.ToUpper();
                }
            }
        }
    }
}
