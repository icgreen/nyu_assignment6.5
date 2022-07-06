using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 direction;
    public float speed = 500;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // All physics calculations happen in FixedUpdate 
    private void FixedUpdate()
    {
        //Vector3 movement = new Vector3(direction);

        rb.AddForce(direction * speed * Time.deltaTime);
    }

    //Function created from the Keymap. This one reference Move Actions
    public void OnPlayerMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();

        direction.x = inputVector.x;
        direction.z = inputVector.y;

        direction.y = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
        }
        
    }
}
