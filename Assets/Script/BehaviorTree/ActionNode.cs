using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : Node
{
    //Declare a delegate that can hold functions that return a NodeState
    public delegate NodeState NodeDelegate();
    private NodeDelegate _nodeAction;

    public ActionNode(NodeDelegate action)
    {
        _nodeAction = action;
    }

    public override NodeState Evaluate()
    {
        // Call the function referenced in the delegate, since its return type is a NodeState
        switch (_nodeAction())
        {
            case NodeState.Success:
                _nodeState = NodeState.Success;
                return _nodeState;
            case NodeState.Failure:
                _nodeState = NodeState.Failure;
                return _nodeState;
            case NodeState.Running:
                _nodeState = NodeState.Running;
                return _nodeState;
            default:
                _nodeState = NodeState.Success;
                return _nodeState;
        }
    }
}
