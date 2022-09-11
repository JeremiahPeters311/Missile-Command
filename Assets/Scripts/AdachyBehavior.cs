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
        GameController gc = GameObject.FindObjectOfType<GameController>();
        if (gc.ShadowCount <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (ShadowTarget == null && gc.ShadowCount != 0)
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
        GameController gc = GameObject.FindObjectOfType<GameController>();
        if (gc.ShadowCount <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        while (true)
        {
            if (Destination == false)
            {
                if (gc.ShadowCount <= 0)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                }
                if (ShadowTarget != null)
                {
                    if (gc.ShadowCount <= 0)
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                    }
                    this.transform.position = Vector3.MoveTowards(this.transform.position, ShadowTarget.transform.position, 0.025f * Time.deltaTime);
                    yield return new WaitForSeconds(0.01f);
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameController gc = GameObject.FindObjectOfType<GameController>();
        if (gc.ShadowCount <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Shadow")
        {
            Destination = true;
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            gc.ShadowCount--;
            if (gc.ShadowCount <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Projectile")
        {
            if (gc.ShadowCount <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            Destroy(gameObject);
        }
    }
}
