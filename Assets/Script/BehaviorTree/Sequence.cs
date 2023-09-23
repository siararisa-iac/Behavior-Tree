using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    //Sequence is a composite node, it can contain one or more child node.
    private List<Node> _nodes = new();

    //Constructor
    public Sequence(List<Node> node)
    {
        _nodes = node;
    }

    public override NodeState Evaluate()
    {
        bool isAnyChildRunning = false;
        //Iterate through each child
        foreach(Node node in _nodes)
        {
            //Check the state of the child node
            switch (node.Evaluate())
            {
                //if any child returns a Failure, the entire sequence will fail
                case NodeState.Failure:
                    _nodeState = NodeState.Failure;
                    return _nodeState;
                //if the child returns Success, check the next node
                case NodeState.Success:
                    continue;
                case NodeState.Running:
                    isAnyChildRunning = true;
                    continue;
            }
        }
        //If there is still a child running, return running state
        //If no more child is running, then the state is a success
        _nodeState = isAnyChildRunning ? NodeState.Running : NodeState.Success;
        return _nodeState;
    }
}
