using Unity.VisualScripting;
using UnityEngine;

public class CuttingCounter : BaseCounter 
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;

    public override void Interact(PlayerController playerController)
    {
        if (!HasKitchenObject())
        {
            // there is no kitchen object
            if (playerController.HasKitchenObject())
            {
                // player is carrying something
                playerController.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // player is not carrying anything
            }
        }
        else
        {
            // There is a kitchen object
            if (playerController.HasKitchenObject())
            {
                //player is carrying something
            }
            else
            {
                // player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(playerController);
            }
        }
    }
    public override void InteractAlternate(PlayerController playerController)
    {
        if (HasKitchenObject())
        {
            //there is a kitchen object
             GetKitchenObject().DestroySelf();

             KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);

        }
    }
}
