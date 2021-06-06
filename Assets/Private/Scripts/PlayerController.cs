using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Animator animator;
    private CharacterController _characterController;
    private Transform _transform;
    private Vector3 _moveVelocity;

    // ワープによる強制移動があるかどうか？
    private bool isForcedPosition = false;
    private Vector3 forcedPosition;

    // ゴールしたか？
    private bool isGoal = false;

    private bool IsGrounded
    {
        get
        {
            var ray = new Ray(_transform.position + new Vector3(0, 0.1f), Vector3.down);
            var raycastHits = new RaycastHit[1];
            var hitCount = Physics.RaycastNonAlloc(ray, raycastHits, 0.2f);
            return hitCount >= 1;
        }
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = transform;
    }

    private void Update()
    {
        if (isForcedPosition)
        {
            // https://gametukurikata.com/basic/pitfallsofcharactercontroller をもとに修正
            _characterController.enabled = false;
            _transform.position = forcedPosition;
            _moveVelocity = new Vector3(0, 0, 0);
            _characterController.enabled = true;
            isForcedPosition = false;
        }
        else
        {
            if (isGoal)
            {
                _moveVelocity = new Vector3(0, 0, 0);
                _moveVelocity.y += 2.0f;
            }
            else
            {
                _moveVelocity.x = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
                _moveVelocity.z = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;

                _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));

                if (IsGrounded)
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        _moveVelocity.y = jumpPower;
                    }
                }
                else
                {
                    _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
                }
            }

            _characterController.Move(_moveVelocity * Time.deltaTime);
            animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
        }
    }

    public void SetForcedPosition(Vector3 position)
    {
        isForcedPosition = true;
        forcedPosition = position;
    }

    public void SetGoingUp()
    {
        isGoal = true;
    }
}
