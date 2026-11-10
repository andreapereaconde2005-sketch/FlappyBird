using UnityEngine;

public class DetectorMoneda : MonoBehaviour
{
    // Esta variable te permite configurar cuántos puntos da este objeto desde el Inspector de Unity
    [SerializeField] private int valorPuntos;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Este método automático de Unity se ejecuta en el instante en el que
    // el jugador entra dentro del colisionador de la moneda (que debe ser de tipo Trigger)
    private void OnTriggerEnter(Collider other)
    {
        // Primero compruebo si el objeto que me ha atravesado tiene asignada la etiqueta "Player"
        if (other.gameObject.tag == "Player")
        {
            // Busco en toda la escena el componente global que gestiona la puntuación
            ScoreBoardManager scoreBoardManager = FindAnyObjectByType<ScoreBoardManager>();
            
            // Si encuentro el marcador con éxito, le ordeno que sume la cantidad de puntos configurada
            if (scoreBoardManager != null) 
            {
                scoreBoardManager.IncreaseScore(valorPuntos); // ¡Aquí le pasamos el valor de la variable!
            }
            
            // Finalmente, me destruyo a mí mismo para que la moneda desaparezca del escenario de inmediato
            Destroy(this.gameObject);
        }
    }
}
