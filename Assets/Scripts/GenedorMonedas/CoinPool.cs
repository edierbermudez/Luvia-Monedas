using System.Collections;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private GameObject[] monedas;
    [SerializeField] private float intervaloGeneracion = 1f;
    [SerializeField] private float posicionYGeneracion = 5.5f;
    [SerializeField] private float limiteIzquierdo = -8f;
    [SerializeField] private float limiteDerecho = 8f;

    private void Start()
    {
        if (monedas == null || monedas.Length == 0)
        {
            Coin[] monedasEncontradas = GetComponentsInChildren<Coin>(true);
            monedas = new GameObject[monedasEncontradas.Length];

            for (int i = 0; i < monedasEncontradas.Length; i++)
            {
                monedas[i] = monedasEncontradas[i].gameObject;
            }
        }

        foreach (GameObject moneda in monedas)
        {
            moneda.SetActive(false);
        }

        StartCoroutine(GenerarMonedas());
    }

    public GameObject ObtenerMonedaLibre()
    {
        foreach (GameObject moneda in monedas)
        {
            if (!moneda.activeInHierarchy)
            {
                return moneda;
            }
        }

        return null;
    }

    private IEnumerator GenerarMonedas()
    {
        while (true)
        {
            GameObject moneda = ObtenerMonedaLibre();

            if (moneda != null)
            {
                float posicionX = Random.Range(limiteIzquierdo, limiteDerecho);
                moneda.transform.position = new Vector3(posicionX, posicionYGeneracion, moneda.transform.position.z);

                Rigidbody2D rigidbodyMoneda = moneda.GetComponent<Rigidbody2D>();
                if (rigidbodyMoneda != null)
                {
                    rigidbodyMoneda.velocity = Vector2.zero;
                    rigidbodyMoneda.angularVelocity = 0f;
                }

                moneda.SetActive(true);
            }

            yield return new WaitForSeconds(intervaloGeneracion);
        }
    }

    public void DetenerGeneracion()
{
    StopAllCoroutines();
}
}
