using ExPresSXR.Interaction;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ClothTileRespawnSocket : PutBackSocketInteractor
{
    public UnityEvent OnRespawned;

    protected override void ResetPutBackTimer(SelectEnterEventArgs args)
    {
        if (args.interactorObject is ClothTileSubmitSocket)
        {
            // TODO: Maybe randomize the new prefab...
            // Instantly spawn a new Putback Instance
            UnregisterPutBackInteractable();
            InstantiatePutBackPrefab();
            RegisterPutBackInteractable();
            OnRespawned.Invoke();
        }

        base.ResetPutBackTimer(args);
    }

    protected override void InstantiatePutBackPrefab()
    {
        base.InstantiatePutBackPrefab();
        if (putBackObjectInstance.TryGetComponent(out ClothTileDisplay display))
        {
            display.RandomizeClothTypes();
        }
        else
        {
            Debug.LogError("Failed to get a ClothTileDisplay from the new PutbackInstance. Please check your Prefab.", this);
        }
    }
}