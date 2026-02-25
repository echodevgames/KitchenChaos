using UnityEngine;

public class DeliveryCounter : BaseCounter
{

    public override void Interact(PlayerController playerController)
    {
        if (!playerController.HasKitchenObject()) return;
        if (playerController.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
        {
            //DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
            playerController.GetKitchenObject().DestroySelf();
        }
    }
}
