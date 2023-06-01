using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float pickupDistance = 2f; // Distância para interagir com o objeto

    private GameObject objectToPickup; // Objeto a ser pego
    private bool isHoldingObject = false;
    private Vector3 objectHoldOffset = new Vector3(0f, 0.7f, 0.5f); // Deslocamento do objeto em relação ao personagem ao ser pego

    private void Update()
    {
        // Verifica se o personagem está próximo de um objeto e pressionou a tecla de espaço
        if (!isHoldingObject && Input.GetKeyDown(KeyCode.Space))
        {
            // Obtém os objetos próximos ao personagem com a tag "Grabbable"
            Collider[] colliders = Physics.OverlapSphere(transform.position, pickupDistance);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Grabbable"))
                {
                    objectToPickup = collider.gameObject;
                    PickUpObject();
                    break;
                }
            }
        }
        else if (isHoldingObject && Input.GetKeyDown(KeyCode.Space))
        {
            DropObject();
        }
    }

    private void PickUpObject()
    {
        // Desativa a gravidade do objeto
        Rigidbody objectRigidbody = objectToPickup.GetComponent<Rigidbody>();
        objectRigidbody.useGravity = false;
        objectRigidbody.isKinematic = true;
        // Define a posição do objeto em relação ao personagem com o deslocamento especificado
        objectToPickup.transform.position = transform.position + transform.TransformDirection(objectHoldOffset);

        // Torna o objeto filho do personagem
        objectToPickup.transform.SetParent(transform);

        isHoldingObject = true;
    }

    private void DropObject()
    {
        // Ativa a gravidade do objeto
        Rigidbody objectRigidbody = objectToPickup.GetComponent<Rigidbody>();
        objectRigidbody.useGravity = true;
        objectRigidbody.isKinematic = false;

        // Remove o objeto como filho do personagem
        objectToPickup.transform.SetParent(null);

        isHoldingObject = false;
    }
}
