using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    // --- VARIABLES ---
    // [SerializeField] permite ver y asignar esta variable desde el Inspector de Unity.
    // Hace referencia al script 'Dropper' adjunto en el objeto que queremos que caiga.
    [SerializeField] private Dropper target;

    // Start se ejecuta una sola vez al iniciar la escena, antes del primer Update
    void Start()
    {
        
    }

    // Update se ejecuta de forma automática una vez por cada frame (fotograma) del juego
    void Update()
    {
        
    }

    // Función nativa de Unity que se activa cuando OTRO objeto entra en el área del Collider de este objeto
    // NOTA: Para que funcione, el Collider de este objeto debe tener la casilla 'Is Trigger' activada.
    private void OnTriggerEnter(Collider other)
    {
        // Condición: Comprobamos si el objeto que acaba de cruzar el sensor tiene la etiqueta (Tag) "Player" (tu Flappy Bird)
        if (other.gameObject.tag == "Player")
        {
            // Sanity Check: Comprobamos que la variable 'target' no esté vacía (evita el error NullReferenceException)
            if (target) 
            {
                // Si hay un objeto asignado, llamamos a su función 'Activate()' para que se caiga
                target.Activate(); 
            }
        }
    }
}
