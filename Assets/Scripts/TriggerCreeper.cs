using UnityEngine;
using System.Collections;

public class TriggerCreeper : AkTriggerBase {

    public void Trigger()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
