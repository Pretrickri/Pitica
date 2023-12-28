using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    private bool isUnderEffect = false;
    public int duration = 5;
    public float intensity = 15f;
    void OnTriggerEnter(Collider other)
    {
        if (!isUnderEffect)
        {
            other.GetComponent<MovementTest>().jumpHeight += intensity;
            isUnderEffect = true;

            StartCoroutine(StopEffect(other));
            Object.Destroy(GetComponent<MeshRenderer>());
        }


    }

    IEnumerator StopEffect(Collider other)
    {
        yield return new WaitForSeconds(duration);

        other.GetComponent<MovementTest>().jumpHeight -= intensity;
        isUnderEffect = false;
        Object.Destroy(gameObject);
    }
}
