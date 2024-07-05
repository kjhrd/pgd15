using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTimer = 60f;
    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (gameTimer < 0) { gameTimer = 0; Debug.Log("END, RELOADING SCENE"); }
    }
}
