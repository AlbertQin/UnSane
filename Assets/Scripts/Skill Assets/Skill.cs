using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public ParticleSystem particle;
    public float cooldown;
    private float availableTime = 0;
    public Sprite skillSprite;
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(Character character, float angle)
    {
        if (Time.time > availableTime)
        {
            availableTime = Time.time + cooldown;
            this.Action(character, angle);
        }
    }
    
    public virtual void Action(Character character, float angle)
    {

    }

}
