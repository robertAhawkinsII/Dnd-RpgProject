using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControles : MonoBehaviour
{
    [SerializeField]
    CharacterStats pbi;

    [Header("Logic")]
    [SerializeField]
    public Animator anim;
    private CharacterController controller;
    private Vector3 slopeNormal;
    private bool grounded;

    //for Turn Processing
    public bool canMove = true;

    public float verticalVelocity;

    [Header("Movement config")]
    [SerializeField] public float speedX = 5;
    [SerializeField] public float speedY = 5;
    [SerializeField] public float gravity = 0.25f;
    [SerializeField] public float terminaVelocity = 5.0f;
    [SerializeField] public float jumpForce = 8.0f;

    [Header("Ground Check RayCast")]
    [SerializeField] private float extremitiesOffset = 0.05f;
    [SerializeField] private float innerverticalOffset = 0.25f;
    [SerializeField] private float distanceGrounded = 0.15f;
    [SerializeField] private float slopeThreshold = 0.55f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        transform.position = GameManager.instance.nextPlayerPosition;
    }

    private void Update()
    {
        Vector3 inputVector = PoolInput();

        Vector3 moveVector = new Vector3(inputVector.x * speedX, 0, inputVector.y * speedY);
        anim?.SetFloat("Speed", moveVector.magnitude);
        grounded = Grounded();
        anim?.SetBool("Grounded", grounded);
        if (grounded)
        {
            //applyingGravity
            verticalVelocity = -1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
                slopeNormal = Vector3.up;
                anim?.SetTrigger("Jump");
            }
        }
        else
        {
            verticalVelocity -= gravity;
            slopeNormal = Vector3.up;

            if (verticalVelocity < -terminaVelocity)
                verticalVelocity = -terminaVelocity;
        }

        moveVector.y = verticalVelocity;
        anim?.SetFloat("VerticalVelocity", verticalVelocity);

        if (slopeNormal != Vector3.up) moveVector = FollowFloor(moveVector);


        if(canMove == true)
        {
            controller.Move(moveVector * Time.deltaTime);
        }

        if(results == battleResults.Flee)
        {
            StartCoroutine(FleeTime());
        }

    }

    private Vector3 PoolInput()
    {
        Vector3 r = default(Vector3);

        r.x = Input.GetAxisRaw("Horizontal");
        r.y = Input.GetAxisRaw("Vertical");
        return (r.magnitude > 1) ? r.normalized : r ;
    }

    private Vector3 FollowFloor(Vector3 moveVector)
    {
        Vector3 right = new Vector3(slopeNormal.y, -slopeNormal.x, 0).normalized;
        Vector3 forward = new Vector3(0, -slopeNormal.z, slopeNormal.y).normalized;
        return right * moveVector.x + forward * moveVector.z;
    }

    public bool Grounded()
    {
        if (verticalVelocity > 0)
            return false;

        float yRay = (controller.bounds.center.y) - (controller.height * 0.5f)
            + innerverticalOffset;

        RaycastHit hit;

        //MID
        if(Physics.Raycast(new Vector3(controller.bounds.center.x, yRay, controller.bounds.center.z), -Vector3.up, out hit, innerverticalOffset + distanceGrounded))
        {
            Debug.DrawRay(new Vector3(controller.bounds.center.x, yRay, controller.bounds.center.z), -Vector3.up * (innerverticalOffset + distanceGrounded), Color.red);
            slopeNormal = hit.normal;
            return (slopeNormal.y > slopeThreshold) ? true : false;
        }

        if(Physics.Raycast(new Vector3(controller.bounds.center.x + (controller.bounds.extents.x - extremitiesOffset), yRay, controller.bounds.center.z + (controller.bounds.extents.z - extremitiesOffset)), 
            -Vector3.up, out hit, innerverticalOffset + distanceGrounded))
        {
            slopeNormal = hit.normal;
            return (slopeNormal.y > slopeThreshold) ? true : false;
        }

        if (Physics.Raycast(new Vector3(controller.bounds.center.x - (controller.bounds.extents.x - extremitiesOffset), yRay, controller.bounds.center.z + (controller.bounds.extents.z - extremitiesOffset)), 
            -Vector3.up, out hit, innerverticalOffset + distanceGrounded))
        {
            slopeNormal = hit.normal;
            return (slopeNormal.y > slopeThreshold) ? true : false;
        }

        if (Physics.Raycast(new Vector3(controller.bounds.center.x + (controller.bounds.extents.x - extremitiesOffset), yRay, controller.bounds.center.z - (controller.bounds.extents.z - extremitiesOffset)), 
            -Vector3.up, out hit, innerverticalOffset + distanceGrounded))
        {
            slopeNormal = hit.normal;
            return (slopeNormal.y > slopeThreshold) ? true : false;
        }

        if (Physics.Raycast(new Vector3(controller.bounds.center.x - (controller.bounds.extents.x - extremitiesOffset), yRay, controller.bounds.center.z - (controller.bounds.extents.z - extremitiesOffset)), 
            -Vector3.up, out hit, innerverticalOffset + distanceGrounded))
        {
            slopeNormal = hit.normal;
            return (slopeNormal.y > slopeThreshold) ? true : false;
        }

        return false;
    }

    public enum battleResults
    {
        Normal,
        Victory,
        Flee
    }

    public battleResults results;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextRoom")
        {
            CollisionHandeler col = other.gameObject.GetComponent<CollisionHandeler>();
            GameManager.instance.nextPlayerPosition = col.spawnPoint.transform.position;
            GameManager.instance.SceneToLoad = col.sceneToLoad;
            GameManager.instance.LoadNextScene();
        }
        if (other.tag == "EnemyEncounter")
        {
            
            if (results == battleResults.Victory)
            {
                other.GetComponent<CollectRewards>().CollectReward();
                results = battleResults.Normal;
            }
            else
            {
                pbi.inBattle = true;
                EncounterHandeler eco = other.gameObject.GetComponent<EncounterHandeler>();

                GameManager.instance.curEncounter = eco.encounterNumber;
                GameManager.instance.nextPlayerPosition = eco.spawnPoint.transform.position;
                GameManager.instance.BattleEncounter();
            }                            
        }
    }

    IEnumerator FleeTime()
    {
        results = battleResults.Flee;
        yield return new WaitForSeconds(3f);
        results = battleResults.Normal;
    }
}
