using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    
    private Rigidbody rb;
    
    private float horizontal;
    private float vertical;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        rb.velocity = transform.forward * (vertical * speed);
        transform.Rotate(0, horizontal * rotationSpeed, 0);
    }
}
