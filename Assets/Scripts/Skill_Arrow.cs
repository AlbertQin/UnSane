using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Arrow : Skill
{
    public List<ParticleCollisionEvent> collisionEvents;
    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void Action(Character character, float angle)
    {
        particle.transform.rotation = Quaternion.Euler(0, 0, angle);
        particle.Play();
    }


    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = particle.GetCollisionEvents(other, collisionEvents);
        if (other.GetComponent<Rigidbody2D>() != null)
            other.GetComponent<Rigidbody2D>().AddForce((collisionEvents[0].intersection - transform.position) * 150);
        other.GetComponent<Character>().TakeHealthDamage(20);
    }
}
