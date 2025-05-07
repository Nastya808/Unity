using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject cameraPosition;
    private float angleX = 0f;
    private float angleY = 0f;
    private bool wasFpv;

    [SerializeField] private float mouseSensitivity = 1.5f; // Чувствительность мыши
    [SerializeField] private float verticalMin = -60f;
    [SerializeField] private float verticalMax = 60f;

    void Start()
    {
        cameraPosition = GameObject.Find("CameraPosition");
        angleX = transform.eulerAngles.x;
        angleY = transform.eulerAngles.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        wasFpv = SwitchScript.isFpv;
    }

    void Update()
    {
        float ax = Input.GetAxis("Mouse X") * mouseSensitivity;
        float ay = Input.GetAxis("Mouse Y") * mouseSensitivity;

        angleX -= ay;
        angleY += ax;

        // Ограничение вертикального угла обзора
        angleX = Mathf.Clamp(angleX, verticalMin, verticalMax);

        if (SwitchScript.isFpv)
        {
            transform.eulerAngles = new Vector3(angleX, angleY, 0f);
        }
        else
        {
            if (wasFpv)
            {
                angleX = cameraPosition.transform.eulerAngles.x;
                angleY = cameraPosition.transform.eulerAngles.y;
                wasFpv = false;
            }

            transform.position = cameraPosition.transform.position;
            transform.eulerAngles = cameraPosition.transform.eulerAngles;
        }

        if (SwitchScript.isFpv && !wasFpv)
        {
            wasFpv = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
