using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
    public void SetKitchenObjectParent(IKitchenObjectParent kitcnthenObjectPare)
    {
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitcnthenObjectPare;
        if(kitcnthenObjectPare.HasKitchenObject())
        {
            Debug.LogError("IKitchenObjectParent already has a kitchen object!");
        }
        kitcnthenObjectPare.SetKitchenObject(this);
        
        transform.parent = kitcnthenObjectPare.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

     public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

}
