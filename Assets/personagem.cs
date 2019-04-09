using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personagem : MonoBehaviour {

    public float distancia = 3.0f;

    Vector3 destino;
    public float vel = 0.015f;
    public float velRot = 2.0f;

    // Use this for initialization
    void Start () {

        destino = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        AtualizarPosicaoDestino();

        Rotacionar();

        Movimentar();

    }

    private void Rotacionar()
    {
        var rotacaoDestino = Quaternion.LookRotation(destino);
        var rotacao = Quaternion.Slerp(
            transform.rotation,
            rotacaoDestino,
            velRot * Time.deltaTime);

        rotacao.eulerAngles = new Vector3(0f, rotacao.eulerAngles.y, 0f);

        transform.rotation = rotacao;
    }

    private void Movimentar()
    {
        transform.Translate(Vector3.forward * vel * Time.deltaTime);
    }

    private void AtualizarPosicaoDestino()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distancia))
            {
                destino = hit.point;
                destino.y = transform.position.y;
            }
        }
    }
}
