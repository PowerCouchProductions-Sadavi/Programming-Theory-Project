using System.Collections;
using UnityEngine;

public class Cat : Animal //INHERITANCE
{
    protected override void Start() //POLYMORPHISM
    {
        species = "Cat";
        movementSpeed = 3.0f;
        speech = "I'm a cat, meow!";
        base.Start();
    }
}
