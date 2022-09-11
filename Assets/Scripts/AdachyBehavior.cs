using System.Collections;
using UnityEngine;

public class AdachyBehavior : MonoBehaviour
{
    public GameObject ShadowTarget;
    public GameObject Explosion;
    public bool FindTarget = false;
    public bool Destination = false;

    void Update()
    {
        if (ShadowTarget == null)
        {
            FindTarget = false;
        }
        while (FindTarget == false)
        {
            int ChooseTarget = Random.Range(1, 7);
            if (ChooseTarget == 1)
            {
                ShadowTarget = GameObject.Find("Mothman");
                if (ShadowTarget != null)
                {
                    FindTarget = true;
                }
            }
            else if (ChooseTarget == 2)
            {
                ShadowTarget = GameObject.Find("Pixie");
                if (ShadowTarget != null)
                {
                    FindTarget = true;
                }
            }
            else if (ChooseTarget == 3)
            {
                ShadowTarget = GameObject.Find("Jack Frost");
                if (ShadowTarget != null)
                {
                    FindTarget = true;
                }
            }
            else if (ChooseTarget == 4)
            {
                ShadowTarget = GameObject.Find("Pyro Jack");
                if (ShadowTarget != null)
                {
                    FindTarget = true;
                }
            }
            else if (ChooseTarget == 5)
            {
                ShadowTarget = GameObject.Find("Neko Shogun");
                if (ShadowTarget != null)
                {
                    FindTarget = true;
                }
            }
            else if (ChooseTarget == 6)
            {
                ShadowTarget = GameObject.Find("Mokoi");
                if (ShadowTarget != null)
                {
                    FindTarget = true;
                }
            }
        }
        StartCoroutine(KillAllShadows());
    }

    IEnumerator KillAllShadows()
    {
        while (true)
        {
            if (Destination == false)
            {
                if (ShadowTarget != null)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, ShadowTarget.transform.position, 0.025f * Time.deltaTime);
                    yield return new WaitForSeconds(0.01f);
                }
            }
        }
        //yield return null;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameController gc = GameObject.FindObjectOfType<GameController>();
        if (collision.gameObject.tag == "Shadow")
        {
            Destination = true;
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            gc.ShadowCount--;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
