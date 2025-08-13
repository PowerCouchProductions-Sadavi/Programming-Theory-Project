using System.Collections;
using TMPro;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    protected abstract string species { get; set; }
    public TMP_Text speakText;
    [SerializeField]protected float movementSpeed = 5.0f;

    [SerializeField]private float changeDirectionDelay = 3.0f;

    private Vector3 targetDirection;
    private Rigidbody rb;

    private bool isStopped = false;
    protected virtual void Start()
    {
        Debug.Log("Started succesful!");
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ChooseDirection());
        StartCoroutine(StopOrNot());
        Walk();
    }
    private void Update()
    {
    }
    public virtual void Walk()
    {
        Debug.Log("Walking!" + isStopped);
        while (!isStopped)
        {
            transform.Translate(targetDirection * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    public abstract IEnumerator Talk();

    IEnumerator ChooseDirection()
    {
        while (true)
        {
            targetDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

            yield return new WaitForSeconds(changeDirectionDelay); // Wait for Delay Time(Seconds)
        }
    }
    IEnumerator StopOrNot()
    {
        while (true && !isStopped)
        {
            if(Random.Range(1,10) < 2)
            {
                isStopped = true;
                yield return new WaitForSeconds(Random.Range(1, 5));
                isStopped = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        targetDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}

