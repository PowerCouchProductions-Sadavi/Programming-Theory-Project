using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Animal : MonoBehaviour //PARENT CLASS
{
    protected string species;
    protected string speech;
    public string petName;
    public TMP_Text speakText;
    private float _movementSpeed = 3.0f;
    protected float movementSpeed //ENCAPSULATION
    {
        get { return _movementSpeed; }
        set
        {
            if (value < 0)
            {
                Debug.LogWarning("Speed cannot be negative! Setting to 0");
                value = 0;
            }
            else
            {
                _movementSpeed = value;
            }
        }
    }

    [SerializeField] private float changeDirectionDelay = 3.0f;

    private Vector3 targetDirection;
    private Rigidbody rb;

    private bool isStopped = false;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!rb) { Debug.Log($"No RigidBody for {this.name}"); }
        StartCoroutine(ChooseDirection()); //ABSTRACTION
        StartCoroutine(StopOrNot()); //ABSTRACTION
        StartCoroutine(Talk()); //ABSTRACTION

        targetDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    void FixedUpdate() // Handle physics movement here
    {
        if (!isStopped && rb != null)
        {
            rb.linearVelocity = targetDirection * movementSpeed;
            if (targetDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(targetDirection);
            }
        }
        else if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    public virtual IEnumerator Talk() //ABSTRACTION
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));

            speakText.text += speech;
            yield return new WaitForSeconds(3);
            speakText.text = $"{petName}\n";
        }
    }

    IEnumerator ChooseDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionDelay); // Wait for Delay Time(Seconds)
            targetDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        }
    }
    IEnumerator StopOrNot() //ABSTRACTION
    {
        while (true)
        {
            if (!isStopped)
            {
                if (Random.Range(1, 10) < 2)
                {
                    isStopped = true;
                    yield return new WaitForSeconds(Random.Range(1, 5));
                    isStopped = false;
                }

            }
            yield return new WaitForSeconds(3.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            StopCoroutine(ChooseDirection());
            Debug.Log("Collided");
            Debug.Log(targetDirection.ToString());
            //reflect the direction
            Vector3 reflected = Vector3.Reflect(rb.linearVelocity, collision.contacts[0].normal);
            //Stabalise the Y value
            reflected.y = 0;
            targetDirection = reflected.normalized;

            if (rb != null)
            {
                Debug.Log("Applying directional force)");
                rb.linearVelocity = targetDirection * movementSpeed;
                if (targetDirection != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(targetDirection);
                }

                Debug.Log(targetDirection.ToString());
            }
            StartCoroutine(ChooseDirection());
        }
    }
}