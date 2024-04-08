using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabinteractableTwoAttach : XRGrabInteractable
{
    public Transform leftAttachTransfrom;
    public Transform rightAttachTransfrom;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transfrom.CompareTag("Left Hand"))
        {
            attachTransfrom = leftAttachTransform;
        }
        else if (args.interactorObject.transfrom.CompareTag("Right Hand"))
        {
            attachTransfrom = rightAttachTransform;
        }

        base.OnSelectEntered(args);
    }

}