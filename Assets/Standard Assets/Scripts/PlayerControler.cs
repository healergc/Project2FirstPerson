using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float speed = 5.0f;

    private float yRotation = 0f;
    private float xRotation = 0f; 

    // Start is called once before the first execution of Update after the
   
void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        var mouseY = Input.GetAxis("Mouse Y");
        var mouseX = Input.GetAxis("Mouse X");

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);


        xRotation += mouseX;

        transform.rotation = Quaternion.Euler(new Vector3(0f, xRotation,0f));

        mainCamera.transform.rotation = Quaternion.Euler(new Vector3(yRotation,
xRotation, 0f));





        var vertInput = Input.GetAxis("Vertical");

        var horzInput = Input.GetAxis("Horizontal");

        var forwardDir = transform.forward * vertInput * Time.deltaTime * speed;
        
        var sideDir = transform.right * horzInput * Time.deltaTime * speed;

        var moveVector = forwardDir + sideDir;
       
        characterController.Move(moveVector);

    }
}
