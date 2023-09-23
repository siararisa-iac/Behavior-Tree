using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    private Node _node;

    public Inverter(Node node)
    {
        _node = node;
    }
    public override NodeState Evaluate()
    {
        switch (_node.Evaluate())
        {
            //return  the opposite
            case NodeState.Success:
                _nodeState = NodeState.Failure;
                return _nodeState;
            //return  the opposite
            case NodeState.Failure:
                _nodeState = NodeState.Success;
                return _nodeState;
            //return  the opposite
            case NodeState.Running:
                _nodeState = NodeState.Running;
                return _nodeState;
        }
        //Normally, we wouldnt reach this part,
        _nodeState = NodeState.Success;
        return _nodeState;
    }
}
