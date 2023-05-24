using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float time;
    public GameObject grenadeExplosion;

    public Vector3 targetDestination;

    public Grenade(Vector3 targetVec3)
    {

    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position == targetDestination)
        {
            StartCoroutine(Explode(0.01f));
        }
        StartCoroutine(Explode(time));

    }

    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject gE = Instantiate(grenadeExplosion, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
        // Code to execute after the delay
    }

}
