using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        ITEMONE, ITEMTWO, ITEMTHREE
    }

    public CollectibleType type;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (type)
            {
                case CollectibleType.ITEMONE:

                    break;
                case CollectibleType.ITEMTWO:
                    break;
                case CollectibleType.ITEMTHREE:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
