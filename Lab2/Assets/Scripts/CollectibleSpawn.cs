using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawn : MonoBehaviour
{

    public GameObject itemOne;
    public GameObject itemTwo;
    public GameObject itemThree;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 3);

        if (random == 0)
        {
            Instantiate(itemOne, gameObject.transform.position, gameObject.transform.rotation);
        }
        else if (random == 1)
        {
            Instantiate(itemTwo, gameObject.transform.position, gameObject.transform.rotation);
        }
        else
        {
            Instantiate(itemThree, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
