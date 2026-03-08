using UnityEngine;
using System;
using Unity.Netcode;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnAnyObjectTrashed;
    new public static void ResetStaticData()
    {
        OnAnyObjectTrashed = null;
    }
    public override void Interact(PlayerController playerController)
    {
        if (playerController.HasKitchenObject())
        {
           KitchenObject.DestroyKitchenObject(playerController.GetKitchenObject());
            InteractLogicServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void InteractLogicServerRpc()
    {
        InteractLogicClientRpc();
    }
    [ClientRpc]
    private void InteractLogicClientRpc()
    {

        OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty);
    }


}
