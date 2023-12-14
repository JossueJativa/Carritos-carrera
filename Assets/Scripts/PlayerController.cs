using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la entrada del teclado
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Mover el objeto del jugador hacia adelante
        Vector3 movement = new Vector3(0f, 0f, verticalInput) * speed;
        rb.velocity = transform.TransformDirection(movement);

        // Rotar gradualmente
        RotateTowardsDirection(horizontalInput);
    }

    void RotateTowardsDirection(float horizontalInput)
    {
        // Si no hay entrada de movimiento lateral, no hay necesidad de rotar
        if (horizontalInput == 0)
            return;

        // Calcula la rotación lateral
        Quaternion rotationAmount = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);

        // Aplica la rotación
        transform.rotation *= rotationAmount;
    }
}
