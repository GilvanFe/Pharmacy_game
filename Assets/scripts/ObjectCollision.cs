using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public string targetObjectName = "Target"; // Nome do objeto alvo
    public string[] objectTags; // Tags dos objetos que colidem com o alvo

    private int collisionCount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto colidido possui uma das tags específicas
        if (ArrayContainsTag(collision.gameObject.tag))
        {
            collisionCount++;

            // Verifica se o número de colisões atingiu o limite
            if (collisionCount == 5)
            {
                GameObject targetObject = GameObject.Find(targetObjectName);
                if (targetObject != null)
                {
                    Debug.Log("3 objetos colidiram com o objeto alvo: " + targetObject.name);
                }
                else
                {
                    Debug.LogWarning("O objeto alvo não foi encontrado.");
                }
            }
        }
    }

    private bool ArrayContainsTag(string tag)
    {
        // Verifica se a tag está presente no array de tags
        for (int i = 0; i < objectTags.Length; i++)
        {
            if (objectTags[i] == tag)
            {
                return true;
            }
        }
        return false;
    }
}
