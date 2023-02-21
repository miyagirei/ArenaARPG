using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float _mainSpeed;
    [SerializeField] float _defaultSpeed;
    [SerializeField] float _backSpeed;
    [SerializeField] Animator anim;
    Rigidbody _rb;
    Vector3 _moveDirection;
    Quaternion _rotation;
    [SerializeField] float _rotationSpeed;

    [Header("swordAnimation")]
    [SerializeField] string[] swordAnim;
    [SerializeField] float[] swordAnimCT;

    //[SerializeField] string[] shieldAnim;
    //[SerializeField] float[] shieldAinmCT;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MoveInput();
        AttackSword();
        GuardShield();
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

        if (Input.GetAxis("Vertical") >= 1)
        {
            anim.SetBool("MoveF", true);
            anim.SetBool("MoveB", false);
            _mainSpeed = _defaultSpeed;
        }
        else if(Input.GetAxis("Vertical") <= -1){
            anim.SetBool("MoveB", true);
            anim.SetBool("MoveF", false);
            _mainSpeed = _backSpeed;
        }
        else
        {
            anim.SetBool("MoveF", false);
            anim.SetBool("MoveB", false);
            _mainSpeed = _defaultSpeed;
        }
    }
    void AttackSword()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(DoubleAttackAnim(swordAnim[0],swordAnimCT[0],KeyCode.Mouse0,swordAnim[1],swordAnimCT[1]));
        }
    }

    IEnumerator DoubleAttackAnim(string trans,float time,  KeyCode key, string next,float nextTime)
    {
        anim.SetBool(trans, true);
        yield return new WaitForSeconds(time);
        if (Input.GetKey(key)){
            anim.SetBool(next, true);
            yield return new WaitForSeconds(nextTime);
            anim.SetBool(next, false);
            anim.SetBool(trans, false);
        }
        else
        {
            anim.SetBool(trans, false);
        }

    }

    void GuardShield()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("Guard", true);
        }
        else
        {
            anim.SetBool("Guard", false);
        }
    }
}
