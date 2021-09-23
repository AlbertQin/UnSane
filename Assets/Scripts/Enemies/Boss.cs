using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Boss : Character
{
    GameObject player;
    GameObject sceneLoader;
    int MaxDist = 10;
    int MinDist = 5;
    public float attackSpeed;
    float availableTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        sceneLoader = GameObject.Find("SceneLoader");
        Character playerChar = player.GetComponent<Character>();

        maxhealth = playerChar.maxhealth + 100;
        health = playerChar.maxhealth +  100;
        attack = playerChar.attack;
        speed = playerChar.speed - 1;

        if (playerChar.skill1 != null)
        {
            skill1 = Instantiate(playerChar.skill1);
            skill1.transform.SetParent(this.transform);
            skill1.transform.localPosition = Vector3.zero;
            var collision = skill1.GetComponent<ParticleSystem>().collision;
            collision.collidesWith = enemyLayers;
        }

        if (playerChar.skill2 != null)
        {
            skill2 = Instantiate(playerChar.skill2);
            skill2.transform.SetParent(this.transform);
            skill2.transform.localPosition = Vector3.zero;
            var collision = skill2.GetComponent<ParticleSystem>().collision;
            collision.collidesWith = enemyLayers;
            
        }

        if (playerChar.skill3 != null)
        {
            skill3 = Instantiate(playerChar.skill3);
            skill3.transform.SetParent(this.transform);
            skill3.transform.localPosition = Vector3.zero;
            var collision = skill3.GetComponent<ParticleSystem>().collision;
            collision.collidesWith = enemyLayers;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //Get Facing Direction
        Vector2 lookDir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        //Move Towards Player
        if (Vector3.Distance(transform.position, player.transform.position) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        //Attack if Within Range
        if (Vector3.Distance(transform.position, player.transform.position) < 1)
        {
            if (Time.time > availableTime)
            {

                Attack(this.transform.position + attackRange * new Vector3(DegreeToVector2(angle).x, DegreeToVector2(angle).y, 0));
                availableTime = Time.time + attackSpeed;
                weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
                weapon.Play();
            }
        }
        int rand = Random.Range(1, 5);
        switch (rand)
        {
            case 1:
                if (skill1 != null)
                    skill1.GetComponent<Skill>().Activate(this, angle);
                break;
            case 2:
                if (skill2 != null)
                    skill2.GetComponent<Skill>().Activate(this, angle);
                break;
            case 3:
                if (skill3 != null)
                    skill3.GetComponent<Skill>().Activate(this, angle);
                break;
            case 4:
                break;
        }
    }

    protected override void Attack(Vector3 attackPoint)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint, attackSize, enemyLayers);
        Debug.DrawLine(this.transform.position, attackPoint, Color.green, 2);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Character>().TakeHealthDamage(attack);
        }
    }

    protected override void Die()
    {
        SceneManager.LoadScene("Congrats");
        Destroy(this);
    }
}

