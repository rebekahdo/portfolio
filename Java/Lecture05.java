public class Lecture05
{
	public static void main(String[] args)
	{
/*
	Stacks

	The Stack ADT
The Stack ADT stores arbitrary objects
Insertions and deletions follow the last-in first-out scheme (LIFO)

	Main stack operations */
	push(object)
//inserts an element
//Add an item in the stack. If the stack is full, then it is said to be an overflow condition.
	object(pop)
//removes and returns the last inserted element
//If the stack is empty, then it said to be underflow condition

//	Auxiliary stack operations
	object top()
//returns the last inserted element without removing it
	integer size()
//returns the number of elements stored
	boolean isEmpty()
//indicates whether no elements are stored

//Example:
//	Method 			Return Value 		Stack Contents	
	push(5) 	// 		-					(5)
	push(3) 	//		-					(5,3)
	size() 		//		2					(5,3)
	pop() 		//		3					(5)
	isEmpty() 	//		false				(5)	
	pop() 		//		5					()
	isEmpty() 	//		true				()	
	pop() 		//		null				()	
	push(7) 	//		-					(7)
	push(9) 	//		-					(7,9)
	top() 		//		9					(7,9)
	push(4) 	//		-					(7,9,4)
	size() 		//		3					(7,9,4)
	pop() 		//		4					(7,9)
	push(6) 	//		-					(7,9,6)
	push(8) 	//		-					(7,9,6,8)
	pop() 		//		8					(7,9,6)

/*	Applications of Stacks
Direct applications
	Page-visited history in a Web browser
	Undo sequence in a text editor
Indirect applications
	Component of other data structures

	Stack implementation using arrays */
	public class StackCustom 
	{
		int size;
		int arr[];
		int top;
	}
	StackCustom(int size) 
	{
	this.size = size;
	this.arr = new int[size];
	this.top = -1;
	}
/*
A constructor to initialize the stack and define the number of the elements to be stored in it
Note, 
The this keyword refers to the current object in a method or constructor
this keyword is used to eliminate the confusion between class attributes and parameters with the same name */

	public void push(int pushedElement) 
	{
		if (!isFull()) 
		{
			top++;
			arr[top] = pushedElement;
			System.out.println("Pushed element:" + pushedElement);
		} 
		else 
		{
			System.out.println("Stack is full !");
		}
	}

	public void pop() 
	{
		if (!isEmpty()) 
		{
			int returnedTop = top;
			top--;
			System.out.println("Popped element :" + arr[returnedTop]);
 
		} 
		else 
		{
			System.out.println("Stack is empty !");
			return -1;
		}
	}

	public void peek() 
	{
		if(!this.isEmpty())
		{
			System.out.println("top item is:" + arr[top]);
		}
		else
		{
			System.out.println("Stack is Empty");
		}
	}

	public boolean isEmpty() 
	{
		return (top == -1);
	}
 
	public boolean isFull() 
	{
		return (size - 1 == top);
	}

/*	Using arrays
Pros: Easy to implement. Memory is saved as references is not involved 
Cons: It is not dynamic. It does not grow and shrink depending to needs */
	}
}