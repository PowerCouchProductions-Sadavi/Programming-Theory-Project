using System.Collections;
using UnityEngine;

public class Dog : Animal
{
    protected override string species { get; set; } = "Dog";

    public override IEnumerator Talk()
    {
        speakText.text = "Bark!";
        yield return new WaitForSeconds(3);
        speakText.text = "";
    }
    protected override void Start()
    {
        base.Start();
    }
}
