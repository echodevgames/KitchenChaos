//-----ClearCounter.cs START-----
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;




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
                if (playerController.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                 
                   if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) 
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //Player is not carrying a plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                        {
                            if (plateKitchenObject.TryAddIngredient(playerController.GetKitchenObject().GetKitchenObjectSO()))
                            {
                                playerController.GetKitchenObject().DestroySelf();
                        }
                    }
                }

            }
            else
            {
                // player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(playerController);
            }
        }

    }


}
//-----ClearCounter.cs END-----