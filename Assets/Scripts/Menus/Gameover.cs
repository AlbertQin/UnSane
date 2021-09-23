using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public void GameOver()
    {
        Debug.Log("GAME OVER");
        SceneManager.LoadScene(0);
    }
}
