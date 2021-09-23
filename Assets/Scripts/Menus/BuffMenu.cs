using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuffMenu : MonoBehaviour
{
    GameObject player;
    GameObject sceneLoader;
    public GameObject[] possibleSkills;
    GameObject chosen;
    Sprite chosenSprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sceneLoader = GameObject.Find("SceneLoader");
        int rand = Random.Range(0, 5);
        chosen = possibleSkills[rand];
        chosenSprite = chosen.GetComponent<Skill>().skillSprite;
        GameObject.Find("ChosenSkill").GetComponent<Image>().sprite = chosenSprite;

        if (player.GetComponent<Character>().skill1 != null)
            GameObject.Find("Skill1").GetComponent<Image>().sprite = player.GetComponent<Character>().skill1.GetComponent<Skill>().skillSprite;
        if (player.GetComponent<Character>().skill2 != null)
            GameObject.Find("Skill2").GetComponent<Image>().sprite = player.GetComponent<Character>().skill2.GetComponent<Skill>().skillSprite;
        if (player.GetComponent<Character>().skill3 != null)
            GameObject.Find("Skill3").GetComponent<Image>().sprite = player.GetComponent<Character>().skill3.GetComponent<Skill>().skillSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void replaceSkill1()
    {
        player.GetComponent<Character>().skill1 = Instantiate(chosen);
        player.GetComponent<Character>().skill1.transform.SetParent(player.transform);
        player.GetComponent<Character>().skill1.transform.localPosition = Vector3.zero;
        Continue();
    }

    public void replaceSkill2()
    {
        player.GetComponent<Character>().skill2 = Instantiate(chosen);
        player.GetComponent<Character>().skill2.transform.SetParent(player.transform);
        player.GetComponent<Character>().skill2.transform.localPosition = Vector3.zero;
        Continue();
    }

    public void replaceSkill3()
    {
        player.GetComponent<Character>().skill3 = Instantiate(chosen);
        player.GetComponent<Character>().skill3.transform.SetParent(player.transform);
        player.GetComponent<Character>().skill3.transform.localPosition = Vector3.zero;
        Continue();
    }

    public void AttackUp()
    {
        player.GetComponent<Character>().attack += 1;
        Continue();
    }

    public void HPUp()
    {
        player.GetComponent<Character>().maxhealth += 10;
        Continue();
    }

    void Continue()
    {
        player.GetComponent<Character>().health = player.GetComponent<Character>().maxhealth;
        sceneLoader.GetComponent<SceneLoader>().GoNext();
        sceneLoader.GetComponent<SceneLoader>().UnPause();
        SceneManager.UnloadScene("ProgressionScene");
    }

    public void SpeedUp()
    {
        player.GetComponent<Character>().speed += 0.5f;
        Continue();
    }
}
