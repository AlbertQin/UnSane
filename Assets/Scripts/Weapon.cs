using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D m_Collider;
    private SpriteRenderer renderer;
    public int damage;
    public float attackspeed;
    public int cooldown;
    private float availableTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        if (Time.time > availableTime)
        {
            m_Collider.enabled = true;
            renderer.enabled = true;
            availableTime = Time.time + cooldown * (1 - attackspeed);
            yield return new WaitForSeconds(1);
            Console.WriteLine("SCHWING");
            m_Collider.enabled = false;
            renderer.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Character>().TakeHealthDamage(10);
    }
}
