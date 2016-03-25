using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public bool T, B, U, S, TL, TG, BL, BD;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        // default bernilai false
        T = B = U = S = TL = TG = BL = BD = false;

        // Input Manager : Type pada Horizontal dan Vertical harus "Joystick Axis"
        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Horizontal") < 1) T = B = true; // kanan dan kiri
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Vertical") < 1)     U = S = true; // atas dan bawah

        if (Input.GetAxis("Horizontal") == 1)  T = true; // kanan
        if (Input.GetAxis("Horizontal") == -1) B = true; // kiri
        if (Input.GetAxis("Vertical") == -1)    U = true; // atas
        if (Input.GetAxis("Vertical") == 1)   S = true; // bawah

        if (Input.GetKey(KeyCode.JoystickButton0)) BD = true; // kiri bawah
        if (Input.GetKey(KeyCode.JoystickButton1)) TL = true; // kanan atas
        if (Input.GetKey(KeyCode.JoystickButton2)) BL = true; // kiri atas
        if (Input.GetKey(KeyCode.JoystickButton3)) TG = true; // kanan bawah

        /*
        // aksi yang dilakukan sesuai dengan input
        if (B && T)
            Debug.Log("Kiri dan Kanan");
        else if (B && U)
            Debug.Log("Kiri dan Atas");
        else if (B && S)
            Debug.Log("Kiri dan Bawah");
        else if (T && U)
            Debug.Log("Kanan dan Atas");
        else if (T && S)
            Debug.Log("Kanan dan Bawah");
        else if (U && S)
            Debug.Log("Atas dan Bawah");
        else if (B)
            Debug.Log("Kiri");
        else if (T)
            Debug.Log("Kanan");
        else if (U)
            Debug.Log("Atas");
        else if (S)
            Debug.Log("Bawah");
         */

    }
}