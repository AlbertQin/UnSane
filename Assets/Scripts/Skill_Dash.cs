using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Dash : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    public override void Action(Character character, float angle)
    {
        particle.Play();
        particle.transform.rotation = Quaternion.Euler(0, 0, angle + 180);
        character.GetComponent<Rigidbody2D>().AddForce(new Vector3(DegreeToVector2(angle).x, DegreeToVector2(angle).y, 0) * 1000);
    }
}
