using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score: MonoBehaviour
{
    public static int EndOfRoundScore;

    public static void SetEndOfRoundScore(int score)
    {
        EndOfRoundScore = score;
    }
}
