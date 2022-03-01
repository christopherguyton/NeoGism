using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorScript : MonoBehaviour
{

    //Elevator Door Objects
    public GameObject leftDoor;
    public GameObject rightDoor;

    //Elevator Door Position (Closed)
    private Vector3 leftDoorPosClosed;
    private Vector3 rightDoorPosClosed; 

    //Opened Elevator Position
   Vector3 leftDoorPosOpen = new Vector3(-0.55f, 0, 0);
   Vector3 rightDoorPosOpen = new Vector3(-1.95f, 0, 0);


    //Bool for if player character is in elevator
    private bool isInElevator;


    void Start()
    {
        leftDoorPosClosed = leftDoor.transform.position;
        rightDoorPosClosed = rightDoor.transform.position;
}

    // Update is called once per frame
    void Update()
    {

       if (isInElevator)
        {
            StartCoroutine(OpenElevatorDoor());
        } else
        {
            StartCoroutine(CloseElevatorDoor());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInElevator = true;
          
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInElevator = false;

        }
    }

    public IEnumerator OpenElevatorDoor()
    {
        yield return new WaitForSeconds(.7f);
        leftDoor.transform.localPosition = leftDoorPosOpen;
        rightDoor.transform.localPosition = rightDoorPosOpen;
        
      
        
    }

    public IEnumerator CloseElevatorDoor()
    {
        yield return new WaitForSeconds(.5f);
        leftDoor.transform.position = leftDoorPosClosed;
        rightDoor.transform.position = rightDoorPosClosed;
    


    }

}
