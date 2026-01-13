public class MyQueue {

    private Stack<int> inputStack;
    private Stack<int> outputStack;

    public MyQueue() {
        inputStack = new Stack<int>();
        outputStack = new Stack<int>();
    }
    
    public void Push(int x) {
        // Move elements from outputStack to inputStack
        while(outputStack.Count > 0) {
            inputStack.Push(outputStack.Pop());
        }
        
        // Push the new element onto inputStack
        inputStack.Push(x);
        
        // Move elements from inputStack to outputStack
        while(inputStack.Count > 0) {
            outputStack.Push(inputStack.Pop());
        }
    }
    
    public int Pop() {
        return outputStack.Pop();
    }
    
    public int Peek() {
        return outputStack.Peek();
    }
    
    public bool Empty() {
        return outputStack.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
