using System.Collections;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Dog : Animal //INHERITANCE
{
    protected override void Start() //POLYMORPHISM
    {
        species = "Dog";
        movementSpeed = 5.0f;
        speech = "I'm a dog, Woof!";
        base.Start();
    }
}
