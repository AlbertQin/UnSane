using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : Character
{
    
    // Update is called once per frame
    public override void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);
        this.Move(vec);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            skill1.Activate(this);
        }
    }
}
