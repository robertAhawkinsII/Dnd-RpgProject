using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private bool checkTrigger;
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private GameObject parentObj;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      if(checkTrigger)
        {
            parentObj.transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerMovementControles>().results != PlayerMovementControles.battleResults.Flee)
        {
            checkTrigger = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            checkTrigger = false;
        }
    }
}
