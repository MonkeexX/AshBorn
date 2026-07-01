using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour
{
    [Header("Movimiento")]
    private float velocity = 0f;
    public float maxVelocity = 5f;

    private Rigidbody2D rb;
    private float inputHorizontal;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void VelocityAcceleration()
    {
        if (velocity < maxVelocity)
        velocity += 0.03f;
    }

    void Update()
    {
        // Leer input en Update
        inputHorizontal = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            inputHorizontal = -1f;
            VelocityAcceleration();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputHorizontal = 1f;
            VelocityAcceleration();
        }
        else
            velocity = 0f;
    }

    void FixedUpdate()
    {
        // Aplicar física en FixedUpdate
        Vector3 movement = new Vector3(inputHorizontal * velocity, rb.linearVelocity.y, 0f);
        rb.linearVelocity = movement;
    }
}
