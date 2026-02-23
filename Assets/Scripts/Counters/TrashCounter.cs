using UnityEngine;

public class TrashCounter : BaseCounter
{
    public override void Interact(PlayerController playerController)
    {
        if (playerController.HasKitchenObject())
        {
            playerController.GetKitchenObject().DestroySelf();
        }
    }
}
