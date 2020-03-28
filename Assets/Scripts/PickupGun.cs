using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Take a look back at this script if/when multiplayer functionality gets added.
 * It will probably need a pretty significant overhaul.
 **/
public class PickupGun : MonoBehaviour
{
    public GameObject item;
    public int itemCount = 1;
    public Vector3 colliderSize = new Vector3(1, 1, 1);


    private bool playerInRange = false;
    private List<GameObject> playerList = new List<GameObject>(); // List of players that are within range, first one in will get priority

    void Start()
    {
        BoxCollider pickupRange = gameObject.AddComponent<BoxCollider>();
        pickupRange.center = new Vector3(0, 0, 0);
        pickupRange.size = colliderSize;
        pickupRange.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(itemCount <= 0)
        {
            Destroy(gameObject);
        }

        //If player is in range to grab and at least 1 item left and E is being pressed
        if (playerInRange && itemCount > 0 && Input.GetKey(KeyCode.E))
        {
            itemCount--;
            GameObject player = playerList[0];
            Vector3 spawnPos = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
            GameObject itemInstance = Instantiate(item, spawnPos, Quaternion.identity);
            itemInstance.GetComponent<ParentGunClass>().player = player; // Setting the "Player" field of the gun class
            itemInstance.transform.parent = player.transform;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            playerInRange = true;
            playerList.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            playerInRange = false;
            playerList.Remove(col.gameObject);
        }
    }
}
