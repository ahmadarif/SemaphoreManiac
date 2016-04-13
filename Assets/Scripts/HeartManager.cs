using UnityEngine;
using System.Collections;

public class HeartManager : MonoBehaviour {

    private const int MAX_HEART = 3;
    private static int jumHeart = MAX_HEART;

    public static void increment()
    {
        if (jumHeart < MAX_HEART)
        {
            jumHeart++;
            updateHeart();
        }

    }

    public static void decrement()
    {
        if (jumHeart > 0)
        {
            jumHeart--;
            updateHeart();
        }
    }

    private static void updateHeart()
    {
        // disable semua
        for (int i = 1; i <= MAX_HEART; i++)
        {
            GameObject.Find("Heart-" + i).transform.localScale = new Vector3(0, 0);
        }

        // enable sesuai heart
        for (int i = 1; i <= jumHeart; i++)
        {
            GameObject.Find("Heart-" + i).transform.localScale = new Vector3(1, 1);
        }
    }
}
