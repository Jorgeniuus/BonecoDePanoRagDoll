using UnityEngine;

public class ShooterRaycast : MonoBehaviour
{
    private void FixedUpdate()
    {
        ShotRaycast();
    }

    private void ShotRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hitPoint))
            {
                PlayerRagDoll playerRagDoll = hitPoint.collider.GetComponent<PlayerRagDoll>();

                if(playerRagDoll !=null)
                {
                    playerRagDoll.RagDollManager(false);
                }
            }
        }
    }
}
