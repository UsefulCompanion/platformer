using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData instance;

    public GameData()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }

            return instance;
        }
    }

    private int score;

    /*
    public int Score(int value)
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    */

}
