using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagDoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] ragDollPlayer;
    [SerializeField] private Collider[] colliderRagDollPlayer;

    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Collider playerCollider;

    private void Awake()
    {
        ragDollPlayer = GetComponentsInChildren<Rigidbody>();
        colliderRagDollPlayer = GetComponentsInChildren<Collider>();
    }
    private void Start()
    {
        RagDollManager(true);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RagDollManager(true);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            RagDollManager(false);
        }
    }

    public void RagDollManager(bool active)
    {
        foreach(var ragDoll in ragDollPlayer)
        {
            ragDoll.isKinematic = active;
        }
        foreach (var colliderRagDoll in colliderRagDollPlayer)
        {
            colliderRagDoll.enabled = !active;
        }

        playerRigidbody.isKinematic = !active;
        playerAnimator.enabled = active;
        playerCollider.enabled = active;
    }
}
