using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Selector : Node
{
    //Selector is a composite node, it can contain one or more child node.
    private List<Node> _nodes = new();

    //Constructor
    public Selector(List<Node> node)
    {
        _nodes = node;
    }

    public override NodeState Evaluate()
    {
        //Iterate through each child
        foreach (Node node in _nodes)
        {
            //Check the state of the child node
            switch (node.Evaluate())
            {
                //if any child returns a Failure, proceed to next node
                case NodeState.Failure:
                    continue;
                //if the child returns Success, the selector immediately returns a Success
                case NodeState.Success:
                    _nodeState = NodeState.Success;
                    return _nodeState;
                case NodeState.Running:
                    _nodeState = NodeState.Running;
                    return _nodeState;
            }
        }
        //If all children resulted to a Failure, selector fails
        _nodeState = NodeState.Failure;
        return _nodeState;
    }
}