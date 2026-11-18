using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Tiempo")]
    [SerializeField] private float tiempoInicial = 20f;
    [SerializeField] private TMP_Text textoTiempo;

    [Header("UI")]
    [SerializeField] private GameObject panelGameOver;

    private float tiempoRestante;
    private bool juegoTerminado;

    [SerializeField] private CoinPool coinPool;

    [SerializeField] private PlayerController playerController;

    private void Start()
    {
        tiempoRestante = tiempoInicial;
        panelGameOver.SetActive(false);
    }

    private void Update()
    {
        if (juegoTerminado)
            return;

        tiempoRestante -= Time.deltaTime;
        Debug.Log("tiempo restante= "+tiempoRestante);
        textoTiempo.text = Mathf.Ceil(tiempoRestante).ToString();

        if (tiempoRestante <= 0)
        {
            FinalizarJuego();
        }
    }

    private void FinalizarJuego()
    {
        juegoTerminado = true;

        panelGameOver.SetActive(true);
        
        coinPool.DetenerGeneracion();

        playerController.DetenerMovimiento();
    }
    public void ReiniciarJuego()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
}
