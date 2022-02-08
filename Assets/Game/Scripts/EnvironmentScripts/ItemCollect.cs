using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{

    //Feedback / Sound
    public AudioSource itemCollectSound;

    //Rotation Variables
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float rotationSpeed;


    //Property Variables
    public float healthGiven;

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
                itemCollectSound.Play();
                StartCoroutine(CollectAndDestroy());
        }
    }

    IEnumerator CollectAndDestroy()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(_rotation * rotationSpeed * Time.deltaTime);
    }
}
