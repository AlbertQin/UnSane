using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int curr;
    float availableTime = 0;
    bool pause = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScene();
    }

    public void UpdateScene()
    {
        if (Time.time > availableTime && !pause)
        {
            int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (enemyCount == 0)
            {
                Debug.Log("Load Progression");
                SceneManager.LoadScene("ProgressionScene", LoadSceneMode.Additive);
                availableTime = Time.time + 5;
                pause = true;
            }
        }
    }

    public void UnPause()
    {
        pause = false;
    }

    public void GoNext()
    {
        curr++;
        Debug.Log(curr);
        SceneManager.LoadScene(curr, LoadSceneMode.Additive);
        availableTime = Time.time + 5;
        pause = true;
    }

}
