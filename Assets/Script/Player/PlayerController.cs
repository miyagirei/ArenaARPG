using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float _mainSpeed;
    [SerializeField] Animator anim;
    Rigidbody _rb;
    Vector3 _moveDirection;
    Quaternion _rotation;
    [SerializeField] float _rotationSpeed;

    int _attackStep = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MoveInput();
        AttackSword();
    }

    void MoveInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * z + Camera.main.transform.right * x;

        _moveDirection = moveForward.normalized + new Vector3(0, _moveDirection.y, 0);

        _rb.AddForce(_moveDirection * _mainSpeed);

        if (moveForward != Vector3.zero)
        {
            _rotation = Quaternion.LookRotation(moveForward);
            transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, _rotationSpeed * Time.deltaTime);
        }
    }
    void AttackSword()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(AnimationFinish(1f , "AttackSword"));
        }
    }

    IEnumerator AnimationFinish(float time, string trans)
    {
        anim.SetBool(trans, true);
        yield return new WaitForSeconds(time);
        anim.SetBool(trans, false);
    }
}
