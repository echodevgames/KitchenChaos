using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public override void Interact(PlayerController playerController)
    {
        if (playerController.HasKitchenObject())
        {
            if (playerController.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                // Only accept plates, not other kitchen objects

                DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
                playerController.GetKitchenObject().DestroySelf();
            }
        }
    }
}
