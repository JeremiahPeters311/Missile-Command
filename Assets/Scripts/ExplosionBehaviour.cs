using System.Collections;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.745f);
        Destroy(gameObject);
    }
}
