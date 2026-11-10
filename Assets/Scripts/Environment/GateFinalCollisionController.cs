using UnityEngine;
using TMPro; // REQUISITO: Necesario para controlar los textos de tu Canvas (TextMeshPro)

public class GateFinalCollisionController : MonoBehaviour
{
    // --- VARIABLES PARA EL CANVAS FINAL ---
    [Header("Configuración de Interfaz Final (UI)")]
    [SerializeField] private GameObject canvaFinal;              // Casilla para arrastrar el CanvaFinal entero y poder apagarlo/encenderlo
    [SerializeField] private TextMeshProUGUI textoPuntuacionFinal; // Arrastra aquí el texto de los puntos
    [SerializeField] private TextMeshProUGUI textoMensajeFinal;    // Arrastra aquí el texto del mensaje elegante

    void Start()
    {
        // Al empezar el nivel, nos aseguramos por código de que el CanvaFinal empiece apagado e invisible para que no moleste al jugar
        if (canvaFinal != null)
        {
            canvaFinal.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Primero compruebo si el objeto que me ha atravesado tiene asignada la etiqueta "Player"
        if (other.gameObject.tag == "Player")
        {
            // --- ACTIVAR INTERFAZ FINAL ---
            // Encendemos el CanvaFinal completo para que aparezcan los textos de golpe en pantalla
            if (canvaFinal != null)
            {
                canvaFinal.SetActive(true);
            }

            // --- LÓGICA DE PUNTUACIÓN CON TU GAMESCENEMANAGER REAL ---
            // Como mi GameSceneManager es un Singleton, accedemos directamente a él sin buscarlo en la escena
            if (GameSceneManager.Instance != null)
            {
                // Extraemos los puntos reales que lleva acumulados tu pájaro
                int puntosTotales = GameSceneManager.Instance.points; 

                // 1. Escribimos la puntuación en el texto del Canvas Final
                if (textoPuntuacionFinal != null)
                {
                    textoPuntuacionFinal.text = "PUNTUACION: " + puntosTotales;
                }

                // 2. Evaluamos la puntuación para poner el mensaje final dinámico
                if (textoMensajeFinal != null)
                {
                    if (puntosTotales >= 40)
                    {
                        // Al poner .text, le dices específicamente a Unity: "Entra en el componente 
                        // y cambia el texto (el string) que se muestra en pantalla por este nuevo mensaje".
                        textoMensajeFinal.text = "¡Eres una autentica leyenda del aire!";
                    }
                    else if (puntosTotales >= 25)
                    {
                        textoMensajeFinal.text = "¡Excelente partida, tienes buenos reflejos!";
                    }
                    else
                    {
                        textoMensajeFinal.text = "¡Buen intento! Al menos el pajaro iba elegante";
                    }
                }
            }
            // ---------------------------------------------



            // --- QUITAR LA GRAVEDAD AL PÁJARO CON SU RIGIDBODY ---
            // Buscamos el Rigidbody del objeto que acaba de chocar (el pájaro) y desactivamos su gravedad
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null) 
            {
                rb.useGravity = false;
            }


            // --- CONGELAR TIEMPO DE JUEGO --- NOO 
            // Esto detiene las físicas, movimientos por Update dependientes del tiempo y la gravedad.
            //Time.timeScale = 0f;
            
            /*
            // Busco en toda la escena el controlador del nivel
            LevelController levelController = FindAnyObjectByType<LevelController>();
            
            // Si encuentro el nivel lo que hago es llamar al método que me pasa a la siguiente escena
            if (levelController != null) 
            {
                levelController.LoadNextLevel(); // sanity check
            }*/
        }
    }
}
