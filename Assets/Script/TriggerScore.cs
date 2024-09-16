using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScore : MonoBehaviour
{
    public float score;

    public Collider bola;
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            //score add
            scoreManager.AddScore(score);
        }
    }
}
