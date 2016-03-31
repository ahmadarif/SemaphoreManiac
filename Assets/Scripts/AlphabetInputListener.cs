using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Thalmic.Myo;

public class AlphabetInputListener : MonoBehaviour {
    
    public int maxStringLength;

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
        danceMat = GetComponent<DancematController>();
        myo = GameObject.Find("Myo").GetComponent<ThalmicMyo>();
        inputText = GetComponent<Text>();
        textGenerator = transform.parent.FindChild("TextGenerator").GetComponent<TextGeneratorScript>();
	}
	
	// Update is called once per frame
	void Update () 
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

        /*
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
                Debug.Log("Hai");
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
         * */
    }
}
