using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemy : Character
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

        skill1.transform.SetParent(this.transform);
        skill1.transform.localPosition = Vector3.zero;
        var collision = skill1.GetComponent<ParticleSystem>().collision;
        collision.collidesWith = enemyLayers;

        skill2.transform.SetParent(this.transform);
        skill2.transform.localPosition = Vector3.zero;
        collision = skill2.GetComponent<ParticleSystem>().collision;
        collision.collidesWith = enemyLayers;
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
        int rand = Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                skill1.GetComponent<Skill>().Activate(this, angle);
                break;
            case 2:
                skill2.GetComponent<Skill>().Activate(this, angle);
                break;
            case 3:
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
        player.GetComponentInChildren<Character>().TakeSanityDamage(10);
        sceneLoader.GetComponent<SceneLoader>().UpdateScene();
        Destroy(gameObject);
    }
}