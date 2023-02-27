using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SlimeAI : MonoBehaviour
{
    //[SerializeField] Collider recognitionRange;
    //[SerializeField] float rotationSpeed;
    bool isTarget;
    [SerializeField]Collider playerCollider; //–Ú•W
    NavMeshAgent _nMA; //NavMesh

    [SerializeField] float _attackRange;
    float distance;

    [SerializeField] Animator _slimeAnim;

    private void Awake()
    {
        _nMA = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerCollider = other;
            isTarget = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerCollider = other;
            isTarget = false;
        }
    }

    private void Update()
    {
        
        distance = Vector3.Distance(this.transform.position, playerCollider.transform.position);
        if (isTarget)
        {
            _nMA.destination = playerCollider.transform.position;
            if(distance < _attackRange)
            {
                print("AttackAnim");
                //print(distance);
            }
        }

    }
}
