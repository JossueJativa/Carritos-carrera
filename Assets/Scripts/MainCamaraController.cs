using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public string playerTag = "Player"; // Tag del jugador
    public float rotationSpeed = 5f;  // Velocidad de rotación de la cámara alrededor del jugador
    public Vector3 offset = new Vector3(0f, 2f, -5f);  // Desplazamiento desde el jugador
    public float angularRotation = 30f;  // Rotación angular en grados

    private Transform target;  // Referencia al componente Transform del jugador

    void Start()
    {
        // Busca el jugador por su tag al comienzo del juego
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("No se encontró el jugador con tag: " + playerTag);
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la rotación deseada basada en la entrada del jugador
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 playerDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            Vector3 desiredForward = Vector3.Slerp(transform.forward, playerDirection, rotationSpeed * Time.deltaTime);

            // Calcula la posición deseada basada en el desplazamiento
            Vector3 desiredPosition = target.position + offset;

            // Aplica la rotación angular a la cámara
            transform.Rotate(Vector3.up, angularRotation * Time.deltaTime);

            // Actualiza la rotación y posición de la cámara
            transform.forward = desiredForward;
            transform.position = desiredPosition;

            // Asegúrate de que la cámara esté mirando al jugador
            transform.LookAt(target);
        }
    }
}
