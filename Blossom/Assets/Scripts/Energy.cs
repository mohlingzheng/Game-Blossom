using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private float experienceContent = 10f;

    public GameObject expEffectPrefabs;

    private string tagName = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            GameObject inst = Instantiate(expEffectPrefabs, other.transform.position, Quaternion.identity);
            inst.GetComponent<Effects>().Seek(other.transform);
            other.gameObject.GetComponent<PlayerStats>().gainExperience(experienceContent);
            GameObject parentGO = gameObject.transform.root.gameObject;
            Destroy(parentGO);
        }
    }

}
