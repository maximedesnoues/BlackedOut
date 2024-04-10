using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class ItemTrigger : MonoBehaviour
{
    [SerializeField] private ItemsData itemsData;
    [SerializeField] private GameObject itemsButton;
    [SerializeField] private GameObject itemsText;
    private GameObject items;

    // Lorsque le joueur rentre en collision avec la potion
    private void OnTriggerEnter(Collider other)
    {
        // Si on touche le tag item
        if (gameObject.CompareTag("Item"))
        {
            // R�cup�rer le bon item
            items = gameObject;
            itemsButton.SetActive(true);
            itemsText.GetComponent<Text>().text = "R�cup�rer l'objet";   // Affichage du texte
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si on sors de la collision avec l'item
        if (gameObject.CompareTag("Item"))
        {
            // On lib�re la variable
            itemsButton.SetActive(false);
        }
    }

    public void Pick()
    {

        // S'il y'a collision avec l'objet nomm�
        switch (items.name)
        {
            #region Consommables

            case "SmallHeal":
                GameManager.Instance.life += itemsData.regenPts; 
                break;

            case "SmallShield":
                GameManager.Instance.shield += itemsData.shieldPts;   // On r�cup�re 5 points de faim
                break;

            #endregion

            default:
                // Si l'objet n'a pas de nom d�fini, on sort de la fonction
                return;
        }

        // On masque l'item et le dialogue lorsque l'objet a �t� ramass�
        items.SetActive(false);
        itemsButton.SetActive(false);
        
    }
}