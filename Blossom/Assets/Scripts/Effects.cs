using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    private Transform tf;

    public float time;

    private Light lightComp;
    private float rateFadeOut;

    private void Start()
    {
        lightComp = GetComponent<Light>();
        if (lightComp != null)
        {
            rateFadeOut = lightComp.intensity / time;
        }
    }

    void Update()
    {
        transform.position = tf.position;
        if (lightComp != null)
        {
            LightFadeOut();
        }
    }

    public void Seek(Transform _tf)
    {
        tf = _tf;
        StartCoroutine(DestroyThis());
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    private void LightFadeOut()
    {
        lightComp.intensity -= Time.deltaTime * rateFadeOut;
    }
}
