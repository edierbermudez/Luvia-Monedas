using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

    public TMP_Text puntajeTxt;

    public void SumarPunto()
    {
            Debug.Log("ScoreManager ejecutado");
    Debug.Log("PuntajeTxt = " + puntajeTxt);
        score++;
        puntajeTxt.text = "Puntaje :"+score;
        Debug.Log("Puntaje: " + score);
    }
}