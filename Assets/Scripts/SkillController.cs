using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public ParticleSystem particle;
    public float cooldown;
    private float availableTime = 0;
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(Character character)
    {
        if (Time.time > availableTime)
        {
            availableTime = Time.time + cooldown;
            this.Action(character);
        }
    }
    
    public virtual void Action(Character character)
    {

    }

}
