using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {

    public static List<string> getDict(int level)
    {
        /* kamus */
        TextAsset textAsset;
        string[] linesFromfile;
        List<string> dict;

        /* algoritma */
        textAsset = (TextAsset)Resources.Load("Level_" + level); // load asset
        linesFromfile = textAsset.text.Split("\n"[0]); // pisahkan berdasarkan baris
        dict = new List<string>(); // buatkan penampung data soal

        // looping sejumlah baris, kemudian simpan ke dalam dict
        foreach (string line in linesFromfile)
        {
            // Debug.Log(line);
            dict.Add(line.Substring(0,line.Length-1));
        }

        return dict;
    }
	
}