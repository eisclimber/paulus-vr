using ExPresSXR.Interaction;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationSnapGrabInteractable : ExPresSXRGrabInteractable
{
    public UnityEvent<int> OnRotationSnapped; 

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRSocketInteractor)
        {
            MatchAttachRotation(args.interactorObject);
        }

        base.OnSelectEntering(args);
    }

    private void MatchAttachRotation(IXRSelectInteractor interactor)
    {
        // Create attach transform if missing
        if (attachTransform == null)
        {
            GameObject attachGo = new("Attach Transform (Generated)");
            attachGo.transform.SetParent(transform);
            attachGo.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            attachTransform = attachGo.transform;
        }

        // Transform own rotation to the sockets attach local space (ignoring rotation of our attach!)
        Transform socketAttach = interactor.GetAttachTransform(this);
        Quaternion worldToSocketLocal = Quaternion.Inverse(socketAttach.rotation);
        Quaternion ownInSocketLocal = transform.rotation * worldToSocketLocal;

        // Snap own rotation to the xz-plane and 90 degree increments of y-rotation in the sockets space
        float eulerY = ownInSocketLocal.eulerAngles.y;
        int rotationSnaps = Mathf.RoundToInt(eulerY / 90.0f);
        Vector3 eulerSnapped = new(0.0f, rotationSnaps * 90.0f, 0.0f);
        Quaternion ownInSocketLocalSnapped = Quaternion.Euler(eulerSnapped);
        // Convert snapped value to world space
        Quaternion snappedInWorldSpace = ownInSocketLocalSnapped * socketAttach.rotation;
        // Finally, we want to compensate the rotation -> Use inverse 
        attachTransform.localRotation = Quaternion.Inverse(snappedInWorldSpace);
        // Emit signal to trigger rotation Data
        OnRotationSnapped.Invoke(rotationSnaps);
    }
}