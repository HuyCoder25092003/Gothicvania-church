using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimation
{
    public void ChangeAnim(PlayerState playerState);
    public void ChangeAnim(GhoulState ghoulState);
    public void ChangeAnim(WizardState wizardState);
    public void ChangeAnim(AngleState angleState);
}
