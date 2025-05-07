using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using MouseButton = UnityEngine.UIElements.MouseButton;

public class Dragger : PointerManipulator
{
    private Vector2 m_TargetStart;
    private Vector2 m_Start;
    protected bool m_Active;
    private int m_PointerId;
    private bool m_wasMoved;

    public Dragger()
    {
        m_PointerId = -1;
        activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
        m_Active = false;
        m_wasMoved = false;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<PointerDownEvent>(OnPointerDown);
        target.RegisterCallback<PointerMoveEvent>(OnPointerMove);
        target.RegisterCallback<PointerUpEvent>(OnPointerUp);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
        target.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
        target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
    }

    protected void OnPointerDown(PointerDownEvent e)
    {
        Debug.Log("OnPointerDown");
        if (m_Active)
        {
            e.StopImmediatePropagation();
            return;
        }

        if (CanStartManipulation(e))
        {
            m_PointerId = e.pointerId;
            m_Start = new Vector2(e.position.x, e.position.y);
            if (!m_wasMoved) {
                m_wasMoved = true;
                m_TargetStart = new Vector2(m_Start.x - 150, 0);
            }
            else {
                m_TargetStart = new Vector2(target.style.left.value.value, target.style.top.value.value);
            }
            Debug.Log("OnPointerDown -> TS : " + m_TargetStart);
            m_Active = true;
            target.CapturePointer(m_PointerId);
            e.StopPropagation();
        }
    }

    protected void OnPointerMove(PointerMoveEvent e)
    {
        if (!m_Active || !target.HasPointerCapture(m_PointerId))
            return;

        Vector2 pos = new Vector2(e.position.x, e.position.y);

        Vector2 diff = pos - m_Start;

        target.style.top = m_TargetStart.y + diff.y;
        target.style.left = m_TargetStart.x + diff.x;

        e.StopPropagation();
    }

    protected void OnPointerUp(PointerUpEvent e)
    {
        if (!m_Active || !target.HasPointerCapture(m_PointerId) || !CanStopManipulation(e))
            return;


        Debug.Log("OnPointerUp");
        m_Active = false;
        target.ReleaseMouse();
        e.StopPropagation();
    }
}