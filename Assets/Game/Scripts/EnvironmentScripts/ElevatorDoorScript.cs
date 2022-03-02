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


    //Bool for if player character is in elevator and door is open
    private bool isInElevator;
    private bool doorIsOpen;


    //Player Movement Object and Variables
    private PlayerScript playerScript;
    private Vector3 playerWalkOut = new Vector3(0,0,-10);
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

        if (!isInElevator)
        {
            other.GetComponent<PlayerScript>().isInAnElevator = false;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (doorIsOpen && isInElevator)
        {
            other.GetComponent<PlayerScript>().isInAnElevator = true;
            other.transform.position += playerWalkOut * Time.deltaTime * 1;
        } 
    }

    public IEnumerator OpenElevatorDoor()
    {
        yield return new WaitForSeconds(.7f);
        leftDoor.transform.localPosition = leftDoorPosOpen;
        rightDoor.transform.localPosition = rightDoorPosOpen;
        doorIsOpen = true;
        
    }

    public IEnumerator CloseElevatorDoor()
    {
        yield return new WaitForSeconds(.5f);
        leftDoor.transform.position = leftDoorPosClosed;
        rightDoor.transform.position = rightDoorPosClosed;
    


    }

}
