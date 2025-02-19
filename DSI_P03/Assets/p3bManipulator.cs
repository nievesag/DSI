using UnityEngine;
using UnityEngine.UIElements;


public class p3bManipulator : MouseManipulator
{

    public p3bManipulator()
    {
        activators.Add(new ManipulatorActivationFilter{button = MouseButton.RightMouse});
    }
    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
    }

    private void OnMouseDown(MouseDownEvent mev)
    {
        Debug.Log(target.name + ": Click en Elemento");
        if (CanStartManipulation(mev))
        {
            target.style.borderBottomColor   = Color.white; 
            target.style.borderLeftColor     = Color.white;
            target.style.borderRightColor    = Color.white;
            target.style.borderTopColor      = Color.white;
            mev.StopPropagation();
        }
    }

}
