using UnityEngine;
using TMPro; // ¡Súper importante! Necesito esta librería para poder controlar textos de TextMeshPro por código

public class ScoreBoardManager : MonoBehaviour
{
    
    //private int score; // Mi variable interna para almacenar los puntos acumulados(YA NO NOS SIRVE)

    // Esta variable me permite arrastrar desde el editor el texto de la interfaz que quiero modificar
    [SerializeField] private TMP_Text scoreBoardText;


    void Start()
    {
        //aseguramos que la primera vez ese texto en pantalla sea mi puntuación
        scoreBoardText.text = GameSceneManager.Instance.points.ToString(); 
    }

    // Con este método público aumento mis puntos y actualizo el marcador visual
    public void IncreaseScore(int amount)
    {
        GameSceneManager.Instance.points += amount; 
        
        // Convierto mi número entero a texto y se lo asigno a mi componente de la UI
        scoreBoardText.text = GameSceneManager.Instance.points.ToString(); 
    }
}
