using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecaoProximidade : MonoBehaviour
{
    public string tagDoObjeto = "Grabbable";
    private bool objetoEmMao = false;
    private GameObject objetoAtual;
    public Vector3 offset = new Vector3(0f, 1f, 1f);

    private Collider colisorAdicional;

    private void Awake()
    {
        colisorAdicional = gameObject.AddComponent<BoxCollider>(); // Adiciona um BoxCollider como colisor adicional
        colisorAdicional.isTrigger = true; // Configura o colisor adicional como trigger
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagDoObjeto))
        {
            objetoAtual = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagDoObjeto))
        {
            objetoAtual = null;
        }
    }

    private void Update()
    {
        if (objetoAtual != null && Input.GetKeyDown(KeyCode.Space))
        {
            if (!objetoEmMao)
            {
                // Segurar objeto
                objetoAtual.transform.SetParent(transform); // Define o personagem como pai do objeto
                objetoAtual.transform.position = transform.position + transform.TransformDirection(offset); // Posiciona o objeto na posicao desejada
                //objetoAtual.GetComponent<Rigidbody>().isKinematic = true; // Desativa a física do objeto enquanto estiver sendo segurado
                objetoEmMao = true;
            }
            else
            {
                // Soltar objeto
                objetoAtual.transform.SetParent(null); // Remove o pai do objeto, colocando-o de volta na cena
                //objetoAtual.GetComponent<Rigidbody>().isKinematic = false; // Ativa a física do objeto para que a gravidade o afete
                //objetoAtual.GetComponent<Rigidbody>().useGravity = true; // Ativa a gravidade no objeto
                objetoEmMao = false;
            }
        }
    }
}