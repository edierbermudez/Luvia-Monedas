using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float limiteInferior = -6f;

    ScoreManager scoreManager;
    private void Start()
    {
        scoreManager=FindFirstObjectByType<ScoreManager>();  
    }
    private void Update()
    {
        
        if (transform.position.y < limiteInferior)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager.SumarPunto();
            gameObject.SetActive(false);
        }
    }
}
