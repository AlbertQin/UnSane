using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharaController : Character
{
    public Camera cam;
    private GameObject sanityBar;
    private GameObject sanitySmoke;
    Vector2 mousePos;
    public float attackSpeed;
    float availableTime = 0;
    GameObject sceneLoader;
    // Update is called once per frame

    protected override void Start()
    {
        base.Start();
        sanityBar = transform.Find("SanityBar").gameObject;
        sanitySmoke = transform.Find("SanitySmoke").gameObject;
        InvokeRepeating("RegenSan", 0.0f, 1.0f);
        sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().UnPause();
    }

    void RegenSan()
    {
        if (sanity < maxSanity)
            sanity += 1;
    }

    protected override void Update()
    {
        base.Update();

        //Movement Inputs
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);
        this.Move(vec);

        //Get Attack Position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        //Get Attack Input
        if (Time.time > availableTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack(this.transform.position + attackRange * new Vector3(DegreeToVector2(angle).x, DegreeToVector2(angle).y, 0));
                availableTime = Time.time + attackSpeed;
                weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
                weapon.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (skill1 != null)
                skill1.GetComponent<Skill>().Activate(this, angle);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (skill2 != null)
                skill2.GetComponent<Skill>().Activate(this, angle);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (skill3 != null)
                skill3.GetComponent<Skill>().Activate(this, angle);
        }

        //Sanity Effects
        sanityBar.transform.localScale = new Vector3((float)sanity / maxSanity, 0.1f, 1);
        ParticleSystem ps = sanitySmoke.GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.rateOverTime = 50 * (1 - (float)sanity / maxSanity);

        if (health == 0)
        {
            Die();
        }

        if (sanity == 0)
        {
            Die();
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
        SceneManager.LoadScene("Game Over");
        Destroy(gameObject);
    }
}
