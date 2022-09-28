using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    private Transform tf;

    public float time;

    // Update is called once per frame
    void Update()
    {
        transform.position = tf.position;
    }

    public void Seek(Transform _tf)
    {
        tf = _tf;
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
