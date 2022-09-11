using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Adachy;
    public int ShadowCount = 6;
    void Start()
    {
        StartCoroutine(SummonAdachy());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (ShadowCount == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    IEnumerator SummonAdachy()
    {
        while (true)
        {
            if (ShadowCount <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            yield return new WaitForSeconds(1.5f);
            Instantiate(Adachy, new Vector3(Random.Range(-10, 11), 7.5f, 0), Quaternion.identity);
        }
    }
}
