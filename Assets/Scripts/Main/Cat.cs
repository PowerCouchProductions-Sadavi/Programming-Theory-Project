using System.Collections;
using UnityEngine;

public class Cat : Animal
{
    protected override string species { get; set; } = "Cat";

    public override IEnumerator Talk()
    {
        speakText.text = "Meow!";
        yield return new WaitForSeconds(3);
        speakText.text = "";
    }
    protected override void Start()
    {
        base.Start();
    }
}
