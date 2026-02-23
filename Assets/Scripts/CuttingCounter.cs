using Unity.VisualScripting;
using UnityEngine;

public class CuttingCounter : BaseCounter 
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray
        ;

    public override void Interact(PlayerController playerController)
    {
        if (!HasKitchenObject())
        {
            // there is no kitchen object
            if (playerController.HasKitchenObject())
            {
                // player is carrying something
                if (HasRecipeWithInput(playerController.GetKitchenObject().GetKitchenObjectSO()))
                {
                    playerController.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            //there is a kitchen object here AND it can be cut
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

            GetKitchenObject().DestroySelf();

             KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);

        }
    }

    private bool HasRecipeWithInput (KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSO GetOutputForInput (KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }

}
