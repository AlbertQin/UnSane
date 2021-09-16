using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3;
    public int health;
    public int maxhealth;
    public int attack;
    public Skill skill1;
    public Skill skill2;
    public Skill skill3;
    public Weapon weapon;
    public int sanity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        skill1 = Instantiate(skill1);
        skill1.transform.SetParent(this.transform);
        weapon = Instantiate(weapon);
        weapon.transform.SetParent(this.transform);
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public void TakeHealthDamage(int damage)
    {
        health = Math.Max(health - damage, 0);
    }

    public void TakeSanityDamage(int damage)
    {
        sanity = Math.Max(sanity - damage, 0);
    }

    public void Move(Vector3 move)
    {
        transform.position += move;
    }
}
