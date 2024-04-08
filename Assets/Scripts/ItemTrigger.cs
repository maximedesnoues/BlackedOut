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
            // On r�cup�re la vie du joueur et on r�g�n�re sa vie par rapport � la potion 
            GameManager.Instance.life += itemsData.regenPts;
            // On limite la vie du joueur � 100
            GameManager.Instance.life = Mathf.Clamp(GameManager.Instance.life, 0, 100);
            Destroy(gameObject);
        }
    }
}
