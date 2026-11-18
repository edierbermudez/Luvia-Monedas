using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;

    // Update is called once per frame
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * movimientoHorizontal * velocidad * Time.deltaTime);

        float posicionX = Mathf.Clamp(transform.position.x, -8f, 8f);
        transform.position = new Vector3(posicionX, transform.position.y, transform.position.z);
    }

    public void DetenerMovimiento()
{
    enabled = false;
}
}
