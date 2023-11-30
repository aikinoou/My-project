using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int ammoAdded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player ammostuff = other.GetComponent<player>();
            ammostuff.currentAmmo += ammoAdded;
            Debug.Log("Collected " + ammoAdded + " bullets");
            Destroy(gameObject);
            ammostuff.ammo.text = ammostuff.currentAmmo.ToString();
        }
    }
}
