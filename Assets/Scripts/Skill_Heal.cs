using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Heal : Skill
{

    // Start is called before the first frame update
    void Start()
    {
        this.cooldown = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void Action(Character character)
    {
        character.health = Math.Min(character.health + 50, character.maxhealth);
    }
}
