using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initialLocalPros;
    private Quartenion initialLocalHot;
    // Start is called before the first frame update
    void Start()
    {
        if (!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offsett Grab Pivot");
            attachPoint.transform.SetParent(Transform, false);
            attachTransfrom = attachPoint.transfrom;
        }
        else
        {
            initialLocalPos = attachTransform.localPosition;
            initialLocalRot = attachTransform.LocalRotation;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            attachTransfrom.position = args.interactionObject.transform.position;
            attachTransfrom.position = args.interactionObject.transform.rotation;

        }
        else
        {
            attachTransfrom.localPosition = inititalLocalPos;
            attachTransfrom.localRotation = inititalLocalRot;
        }

        base.OnSelectEntered(args);
    }
}
