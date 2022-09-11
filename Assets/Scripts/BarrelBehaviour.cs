using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    public GameObject Cabbage;
    public GameObject Explosion;
    public Vector3 TargetLocation;
    public Camera cam;
    void Update()
    {
        GameController gc = GameObject.FindObjectOfType<GameController>();
        if (gc.ShadowCount <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + 270);

        if (Input.GetMouseButtonDown(0))
        {
            TargetLocation = cam.ScreenToWorldPoint(Input.mousePosition);
            TargetLocation.z = 0;
            GameObject ThisCabbage = Instantiate(Cabbage, new Vector3(0, -3, 0), Quaternion.identity);
            StartCoroutine(CabbageMovement(ThisCabbage, TargetLocation));
        }
    }

    IEnumerator CabbageMovement(GameObject ThisCabbage, Vector3 ThisTargetLocation)
    {
        while(true)
        {
            if (ThisCabbage != null)
            {
                ThisCabbage.transform.position = Vector3.MoveTowards(ThisCabbage.transform.position, ThisTargetLocation, 75f * Time.deltaTime);
                yield return new WaitForSeconds(0.01f);
                if (ThisCabbage.transform.position == ThisTargetLocation)
                {
                    Instantiate(Explosion, ThisTargetLocation, Quaternion.identity);
                    Destroy(ThisCabbage);
                    break;
                }
            }
        }
        yield return null;
    }
}
