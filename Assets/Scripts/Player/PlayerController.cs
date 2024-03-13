using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Camera")]
    public Camera playerCamera;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    
    [Header("Movement")]
    public bool canMove = true;
    public float speed = 5f;

    private CharacterController characterController;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        GameManager.SetCursorVisibility(false);
    }

    private void Update()
    {
        #region Handle Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        characterController.Move(moveDirection * Time.deltaTime);
        #endregion

        #region Handle Camera Rotation
        if (canMove)
        {
            rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        #endregion
    }
}
