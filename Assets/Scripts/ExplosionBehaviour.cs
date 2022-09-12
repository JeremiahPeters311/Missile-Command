using System.Collections;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public Animator Anim;
    public BoxCollider2D Bcol;
    void Start()
    {
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        Anim = gameObject.GetComponent<Animator>();
        Bcol = gameObject.GetComponent<BoxCollider2D>();
        //Anim.speed = 0;

        yield return new WaitForSeconds(0.1f);
        Bcol.size = new Vector2(0.2f, 0.2f);
        yield return new WaitForSeconds(0.3f);
        Bcol.size = new Vector2(0.1f, 0.1f);
        yield return new WaitForSeconds(0.345f);
        Destroy(gameObject);
        yield return null;
    }
}
