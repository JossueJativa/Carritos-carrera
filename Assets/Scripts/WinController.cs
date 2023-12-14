using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Necesitas esta línea para trabajar con objetos de texto UI

public class WinController : MonoBehaviour
{
    private int count = 0;
    private bool hasEntered = false;
    [SerializeField] private Text countText; // Referencia al objeto de texto en el Inspector

    private void Start()
    {
        // Asegúrate de asignar el objeto de texto en el Inspector
        if (countText == null)
        {
            Debug.LogError("CountText no está asignado en el Inspector.");
        }
        else
        {
            // Inicializa el texto con el valor actual del contador
            countText.text = "Contador: " + count.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasEntered)
        {
            hasEntered = true;
            StartCoroutine(WaitAndCount(1f));
        }
    }

    private IEnumerator WaitAndCount(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // Este código se ejecutará después de esperar waitTime segundos
        count++;
        Debug.Log("Contador incrementado a: " + count);

        // Actualiza el texto en el objeto de texto
        countText.text = "Contador: " + count.ToString();

        // Restablecer el indicador de entrada para permitir futuras interacciones
        hasEntered = false;
    }
}
