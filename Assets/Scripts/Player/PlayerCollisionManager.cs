using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // 1. DETECTA LOS TUBOS (Esfera rígida: No es Trigger)
    // Este método se ejecuta automáticamente cuando la esfera choca físicamente contra algo
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobamos si el objeto con el que chocamos tiene la etiqueta de obstáculo
        // (Asegúrate de ponerle el Tag "Obstaculo" a tus tuberías en Unity)
        if (collision.gameObject.CompareTag("Obstaculo")) 
        {
            Debug.Log("¡Choque frontal contra una tubería!");
            ProcessHit();
        }
    }

    // 2. DETECTA EL SUELO Y EL TECHO (Cápsula: Sí es Trigger)
    // Este método se ejecuta automáticamente cuando la cápsula atraviesa un objeto Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si tocamos el suelo o el techo mediante sus etiquetas
        // (Asegúrate de ponerle los Tags "Suelo" o "Techo" a esos objetos en Unity)
        if (other.CompareTag("Suelo") || other.CompareTag("Techo"))
        {
            Debug.Log("¡El jugador ha tocado el límite del escenario!");
            ProcessHit();
        }
    }

    // Este método interno procesa el impacto que ha sufrido mi personaje
    internal void ProcessHit()
    {
        Debug.Log("¡El jugador ha muerto! Busco el gestor de nivel...");

        // Busco dinámicamente en mi escena el script LevelController que está en mi GameplayManager
        LevelController levelController = FindAnyObjectByType<LevelController>();
        
        // Si lo encuentro, le ordeno que active el proceso de reinicio de la partida
        if (levelController != null)
        {
            levelController.TriggerReloadLevel();
        }
    }
}
