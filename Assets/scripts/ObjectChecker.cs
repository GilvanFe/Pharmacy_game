using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    public GameObject object1; // Primeiro objeto específico
    public GameObject object2; // Segundo objeto específico
    public GameObject object3; // Terceiro objeto específico

    private int objectsCollidingCount = 0; // Contador de objetos colidindo

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        Debug.Log("Os objetos específicos colidiram com este objeto.");

        // Verifica se o objeto colidido é um dos objetos específicos
        if (collidedObject == object1 || collidedObject == object2 || collidedObject == object3)
        {
            objectsCollidingCount++;

            // Verifica se todos os três objetos específicos colidiram
            if (objectsCollidingCount == 3)
            {
                Debug.Log("Os três objetos específicos colidiram com este objeto.");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        // Verifica se um dos objetos específicos deixou de colidir
        if (collidedObject == object1 || collidedObject == object2 || collidedObject == object3)
        {
            objectsCollidingCount--;
        }
    }
}







