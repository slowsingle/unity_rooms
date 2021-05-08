using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    private CharacterController _characterController;
    private Transform _transform;
    private Vector3 _moveVelocity;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = transform;
    }

    private void Update()
    {
        _moveVelocity.x = CrossPlatformInputManager.GetAxis("Horizontal");
        _moveVelocity.z = CrossPlatformInputManager.GetAxis("Vertical");

        _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));
        
        if (!_characterController.isGrounded)
        {
            _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }

        _characterController.Move(_moveVelocity * Time.deltaTime);
    }
}
