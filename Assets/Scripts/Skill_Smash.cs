using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Smash : Skill
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void Action(Character character, float angle)
    {
        particle.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(character.transform.position, 2, character.enemyLayers);
        Debug.DrawLine(character.transform.position, character.transform.position, Color.green, 2);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Character>().TakeHealthDamage(10);
            Vector2 dir = (enemy.transform.position - character.transform.position).normalized;
            enemy.GetComponent<Rigidbody2D>().AddForce(200 * dir);
        }
    }
}
