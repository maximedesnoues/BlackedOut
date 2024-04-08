using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public ItemsData itemsData;

    // Lorsque le joueur rentre en collision avec la potion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heals"))
        {
            // On récupère la vie du joueur et on régénère sa vie par rapport à la potion 
            GameManager.Instance.life += itemsData.regenPts;
            // On limite la vie du joueur à 100
            GameManager.Instance.life = Mathf.Clamp(GameManager.Instance.life, 0, 100);
            Destroy(gameObject);
        }
    }
}
