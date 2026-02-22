using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
    public void SetKitchenObjectParent(IKitchenObjectParent kitcnthenObjectParent)
    {
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitcnthenObjectParent;
        if(kitcnthenObjectParent.HasKitchenObject())
        {
            Debug.LogError("IKitchenObjectParent already has a kitchen object!");
        }
        kitcnthenObjectParent.SetKitchenObject(this);
        
        transform.parent = kitcnthenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

     public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

}
