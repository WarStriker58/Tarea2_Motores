/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float speed;
    private float moveInput;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 3;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
    }

    void FixedUpdate()
    {
        float moveVelocity = moveInput * speed;
        float newPositionY = transform.position.y + moveVelocity * Time.fixedDeltaTime;
        if (newPositionY > limitSuperior)
        {
            newPositionY = limitSuperior;
        }
        else if (newPositionY < limitInferior)
        {
            newPositionY = limitInferior;
        }
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float speed;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 3;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(mousePosition.y, limitInferior, limitSuperior), transform.position.z);
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
    }
}