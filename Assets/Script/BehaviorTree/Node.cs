public enum NodeState { Success, Failure, Running}
public abstract class Node
{
    protected NodeState _nodeState;
    public NodeState NodeState => _nodeState;

    //The function that each derived class must implement
    public abstract NodeState Evaluate();
}
