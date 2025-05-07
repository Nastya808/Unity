using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxSpeed = 6f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float fx = Input.GetAxis("Horizontal");
        float fz = Input.GetAxis("Vertical");

        // Направление от камеры
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * fz + right * fx;

        // Ограничение скорости
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveDirection * moveSpeed, ForceMode.VelocityChange);
        }

        // Камера следует за игроком в обоих режимах (или настрой по необходимости)
        if (SwitchScript.isFpv)
        {
            Camera.main.transform.position = transform.position;
        }
        else
        {
            Camera.main.transform.position = transform.position;
        }
    }
}
