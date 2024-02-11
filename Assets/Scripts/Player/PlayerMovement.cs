using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private ParticleSystem _breathParticle;

    [SerializeField] private Single _speed;
    [SerializeField] private Single _jumpSpeed;
    [SerializeField] private Single _gravity;

    private Shake _shake;
    private Single _lookSpeed;
    private Single _lookXLimit;
    private Boolean _canMove;
    private Boolean _isMooving;

    CharacterController _characterController;
    Vector3 _moveDirector;
    Vector2 _rotation;

    private void Start()
    {
        #region INITIALIZATION
        _speed = 9f;
        _jumpSpeed = 8.0f;
        _gravity = 20.0f;
        _lookSpeed = 2.0f;
        _lookXLimit = 45.0f;
        _canMove = true;
        _isMooving = false;

        _characterController = GetComponent<CharacterController>();
        _shake = GameObject.Find("CameraShake").GetComponent<Shake>();

        _moveDirector = Vector3.zero;
        _rotation = Vector2.zero;
        #endregion

        _rotation.y = transform.eulerAngles.y;
        Cursor.visible = false;
    }

    private void Update()
    {
        Movement(1.8f);
    }

    private void Movement(Single speedFactor)
    {
        if (_characterController.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            Single curSpeedX;
            Single curSpeedY;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                curSpeedX = _canMove ? (_speed * speedFactor) * Input.GetAxis("Vertical") : 0;
                curSpeedY = _canMove ? (_speed * speedFactor) * Input.GetAxis("Horizontal") : 0;
            }
            else
            {
                curSpeedX = _canMove ? _speed * Input.GetAxis("Vertical") : 0;
                curSpeedY = _canMove ? _speed * Input.GetAxis("Horizontal") : 0;
            }
            _isMooving = Input.GetButton("Vertical") || Input.GetButton("Horizontal");
            _moveDirector = (forward * curSpeedX) + (right * curSpeedY);

            if(Input.GetButton("Jump") && _canMove)
            {
                _moveDirector.y = _jumpSpeed;
                _shake.JumpShake();
            }
        }
        _moveDirector.y -= _gravity * Time.deltaTime;
        _characterController.Move(_moveDirector * Time.deltaTime);
        
        if (_canMove)
        {
            _rotation.y += Input.GetAxis("Mouse X") * _lookSpeed;
            _rotation.x += -Input.GetAxis("Mouse Y") * _lookSpeed;
            _rotation.x = Mathf.Clamp(_rotation.x, -_lookXLimit, _lookXLimit);
            _playerCamera.transform.localRotation = Quaternion.Euler(_rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, _rotation.y);
        }

        if (_characterController.isGrounded && _isMooving)
        {
            _shake.TriggerWalkShake(0.005f, 0.005f);

            //FindObjectOfType<AudioManager>().Play("Step");
        }
        /*
        else
        {
            GetComponent<AudioSource>().Stop();
        }
        */

    }
}
