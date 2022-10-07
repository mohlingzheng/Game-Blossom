using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    public GameObject player;
    private Transform playerTransform;

    [Header("Wave Attack")]
    public bool onWave = false;
    private float waveCD = 5f;
    public GameObject wavePrefabs;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ActivateWaveAttack();
        }
    }

    public void ActivateWaveAttack()
    {
        onWave = true;
        StartCoroutine(PerformWaveAttack());
    }

    private IEnumerator PerformWaveAttack()
    {
        playerTransform = player.transform;
        GameObject inst = Instantiate(wavePrefabs, playerTransform.position, Quaternion.LookRotation(playerTransform.position));
        yield return new WaitForSeconds(waveCD);
        Destroy(inst);
        StartCoroutine(PerformWaveAttack());
    }
}
