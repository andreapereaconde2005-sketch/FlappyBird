using UnityEngine;
using UnityEngine.SceneManagement; // Necesito esta librería para gestionar el flujo de mis escenas

public class LevelController : MonoBehaviour
{
    private bool isReload;
    private float reloadLapseTime; // Tiempo de espera antes de reiniciar para que se note el impacto


    void Start()
    {
        isReload=false;
        reloadLapseTime=0.5f;
    }
    void Update()
    {
        // En cada fotograma compruebo si alguien ha solicitado reiniciar el nivel
        if (isReload)
        {
            isReload = false; // Bajo la bandera de inmediato para que no se ejecute en bucle
            Invoke("ReloadLevel", reloadLapseTime); // Invoco el método de recarga con un pequeño retraso
        }
    }

    // Este es el método público que llamo desde fuera (desde el jugador o tubos) para pedir el reinicio
    public void TriggerReloadLevel()
    {
        isReload = true;
    }

    // Este método privado se encarga de calcular y cargar la siguiente pantalla del juego
    public void LoadNextLevel()
    {
        // Consulto el índice numérico de la escena que está activa en este momento
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        
        // Cargo la siguiente escena sumando uno al índice, y uso el porcentaje para volver al nivel uno si era el último
        SceneManager.LoadScene((CurrentScene + 1) % SceneManager.sceneCountInBuildSettings);
    }

    // Este método privado realiza la carga real de la escena actual
    void ReloadLevel()
    {
        // Consulto el índice de la escena que tengo abierta ahora mismo en mis Build Settings
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        
        // Le ordeno al motor que vuelva a cargar exactamente esta misma escena desde cero
        SceneManager.LoadScene(CurrentScene);
    }
}
