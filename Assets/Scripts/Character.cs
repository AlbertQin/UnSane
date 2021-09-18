using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected GameObject healthBar;
    public float speed = 3;
    public int health;
    public int maxhealth;
    public int attack;
    public Skill skill1;
    public Skill skill2;
    public Skill skill3;
    public int sanity;
    public int maxSanity;
    public float attackRange;
    public float attackSize;
    public LayerMask enemyLayers;
    protected ParticleSystem weapon;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<ParticleSystem>();
        healthBar = transform.Find("HealthBar").gameObject;
        if (skill1 != null)
        {
            skill1 = Instantiate(skill1);
            skill1 = Instantiate(skill1);
            skill1.transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        healthBar.transform.localScale = new Vector3((float)health / maxhealth, 0.1f, 1);

        if (health == 0)
        {
            Die();
        }
    }

    public void TakeHealthDamage(int damage)
    {
        health = Math.Max(health - damage, 0);
    }

    public void TakeSanityDamage(int damage)
    {
        sanity = Math.Max(sanity - damage, 0);
    }

    protected virtual void Attack(Vector3 attackPoint)
    {

    }

    protected static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    protected static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }

    protected void Move(Vector3 move)
    {
        transform.position += move;
    }

    protected virtual void Die()
    {

    }
}
