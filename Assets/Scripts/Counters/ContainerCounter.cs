using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(PlayerController playerController)
    {  
        if (!playerController.HasKitchenObject())
        {
            // PLayer is not carrying anything, so give them the object on the counter
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, playerController);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }

}
