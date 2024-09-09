using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : ViewObject
{
    public int health;
    public int healthMax;
    public override void LoadComponent()
    {
        health = healthMax;
        base.LoadComponent();
    }
}
public class Item : ViewObject
{

    public override void LoadComponent()
    {

        base.LoadComponent();
    }


}