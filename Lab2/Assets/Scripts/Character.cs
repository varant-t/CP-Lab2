using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Add the error checking classes

//Makes sure that the script never deletes off the asset assigned to it
[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    CharacterController cc;

    public float speed;
    public float jumpSpeed;
    public float rotationSpeed; // Used when not using MouseLook.Cs to rotate character.
    public float gravity;

    Vector3 moveDirection;

    enum ControllerType { SimpleMove, Move};
    [SerializeField] ControllerType type;

    public float projectileSpeed;
    public Rigidbody projectilePrefab;
    public Transform projectileSpawnPoint;

   
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            cc = GetComponent<CharacterController>();

            if (speed <= 0)
            {
                speed = 6.0f;
                Debug.Log("Speed not set on " + name + " defaulting to " + speed);
            }

            if (jumpSpeed <= 0)
            {
                jumpSpeed = 8.0f;
                Debug.Log("JumpingSpeed not set on " + name + " defaulting to " + jumpSpeed);
            }

            if (rotationSpeed <= 0)
            {
                rotationSpeed = 2.0f;
                Debug.Log("RotationSpeed not set on " + name + " defaulting to " + rotationSpeed);
            }

            if (gravity <= 0)
            {
                gravity = 9.0f;
                Debug.Log("Gravity not set on " + name + " defaulting to " + gravity);
            }

            moveDirection = Vector3.zero;

            if (projectileSpeed <= 0)
            {
                projectileSpeed = 5.0f;
                Debug.Log("projectileSpeednot set on " + name + " defaulting to " + projectileSpeed);
            }

            if (!projectilePrefab)
            {
                Debug.Log("Missing projectilePrefab " + name );
            }

            if(!projectileSpawnPoint)
            {
                Debug.Log("Missing projectileSpawnPoint " + name);
            }

        }
        catch(NullReferenceException e)
        {
            Debug.LogWarning(e.Message);
        }
        catch (ArgumentException e)
        {
            Debug.LogWarning(e.Message);
        }
        finally
        {
            Debug.Log("Always Gets Called.");
        }
    }

    // Update is called once per frame
    void Update()
    {
            switch (type)
            {
                case ControllerType.SimpleMove:
                    //transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

                    //Vector3 forward = transform.TransformDirection(Vector3.forward);

                    //float curSpeed = Input.GetAxis("Vertical") * speed;

                    cc.SimpleMove(transform.forward * (Input.GetAxis("Vertical") * speed));
                 

                    break;

                case ControllerType.Move:
                    if (cc.isGrounded)
                    {
                        moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));

                        // transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

                        moveDirection = transform.TransformDirection(moveDirection);

                        moveDirection *= speed;

                        if (Input.GetButtonDown("Jump"))
                            moveDirection.y = jumpSpeed;
                    }
                    moveDirection.y -= gravity * Time.deltaTime;

                    cc.Move(moveDirection * Time.deltaTime);
                  
                    break;

            }

            if (Input.GetButtonDown("Fire1"))
            {
                fire();
                Debug.Log("Player is shooting");
            }
    }

    
    public void fire()
    {
        if(projectileSpawnPoint && projectilePrefab)
        {
            Rigidbody temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            temp.AddForce(projectileSpawnPoint.forward * projectileSpeed, ForceMode.Impulse);
        }
    }
}
