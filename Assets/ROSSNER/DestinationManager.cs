using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Characters.FirstPerson;


namespace manuel {

[System.Serializable]
public struct Destination
{
    public Transform destination;
    public float currDist;
}

public class DestinationManager : MonoBehaviour
{
    public Destination[] destinationArray;

    public GameObject character;
        public AICharacterControl aiCharacterControl;
    public Vector3 firstDestination;

    public int closestId = 0;

    void Awake()
    {
        destinationArray = new Destination[transform.childCount];
        for (int i = 0; i < destinationArray.Length; i++) {
            destinationArray[i].destination = transform.GetChild(i).gameObject.transform;
            destinationArray[i].destination.GetComponent<DestinationJump>().id = i;

            if (destinationArray[i].destination.GetComponent<DestinationJump>().isFirst) {
                firstDestination = new Vector3(destinationArray[i].destination.position.x, destinationArray[i].destination.position.y + 2.0f, destinationArray[i].destination.position.z);
            }
        }
        UpdateTarget();
    }


    public void UpdateTarget() {

        float closestDist = 999999f;
        for (int i = 0; i < destinationArray.Length; i++) {
            var currDist = Vector3.Distance(character.transform.position, destinationArray[i].destination.position);
            destinationArray[i].currDist = currDist;
            if (destinationArray[i].destination.gameObject.active && currDist < closestDist) {
                closestId = i; 
                closestDist = currDist;
            }
        }
        
        if (destinationArray[closestId].destination.GetComponent<DestinationJump>().isLast) {
           
             for (int i = 0; i < destinationArray.Length; i++) { 
                destinationArray[i].destination.gameObject.SetActive(true);
            }
            //Temporarily disable the character so it's position can be reset
            character.SetActive(false);
            character.transform.position = firstDestination;
            character.SetActive(true);
        } else {
            character.GetComponent<AICharacterControl>().target = destinationArray[closestId].destination;
            

        }

        
    }


}

}

