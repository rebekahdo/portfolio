public class Lecture08
{
	public static void main(String[] args)
	{

/*
	The Queue ADT

The Queue ADT stores arbitrary objects
Insertions and deletions follow the first-in first-out scheme (FIFO) 
            -In other words: First come, First serve
Queue has two ends; one is called rear (tail) and the other is front (head)
Insertions are at the rear of the queue and removals are at the front of the queue

	Main queue operations
*/
	enqueue(object) 
//inserts an element at the end (rear) of the queue

	object dequeue() 
//removes and returns the element at the front of the queue

//	Auxiliary queue operations

	object front()  //or 
			Peek() //or 
			Peek()  
//returns the element at the front without removing it
	integer size() 
//returns the number of elements stored
	boolean isEmpty() 
//indicates whether no elements are stored

//Example
//Operation				Output	Q   	
enqueue(5)	//	–		(5)	
enqueue(3)	//	–		(5, 3)	
dequeue()	//	5		(3)	
enqueue(7)	//	–		(3, 7)	
dequeue()	//	3		(7)	
front()		//	7		(7)	
dequeue()	//	7		()	
dequeue()	//	null	()	
isEmpty()	//	true	()	
enqueue(9)	//	–		(9)	
enqueue(7)	//	–		(9, 7)	
size()		//	2		(9, 7)	
enqueue(3)	//	–		(9, 7, 3)	
enqueue(5)	//	–		(9, 7, 3, 5)	
dequeue()	//	9		(7, 3, 5)	

/*	Applications of Queues
Direct applications
	-Waiting lists, bureaucracy
	-Access to shared resources (e.g., printer)

Indirect applications
	-Auxiliary data structure for algorithms
	-Component of other data structures

	Queue Implementation using arrays
We will need to have front and rear variables that are initialized with -1

	enqueue(object)
Step. 1: check if the Queue is full. If the queue is full, print “overflow condition”
Step. 2: check if the queue is empty, in other words both rear and front = -1. In this case, front and rear should be incremented by one to be 0. Then, insert the element.
Step.3 : if the Queue has space, in this case, we simply increment the “rear” value and then insert the element

	dequeue
Step. 1: check If the queue is empty, print “underflow condition”
Step. 2: check if rear and front has the same value. That means that the queue has only one element in it. So, we set the front and the rear to be -1
Step.3 : if the Queue has elements, in this case, we simply increment the “front” value

	 object  front() : or Peek() or Peek()
Step. 1: check If the queue is empty, print “underflow condition”

Step.2: Otherwise, returns the element at the front without removing it */

class Queue
{
	private int arr[]; //array to store queue elements
	private int front; //front points to front elemtns in the queue (if any)
	private int rear; //rear points to last elements in the queue
	private int capacity; //maximum capacity of the queue
	private int count; //current size of the queue

	//constructor to intialize queue
	Queue(int size)
	{
		arr = new int[size];
		capacity = size;
		front = -1;
		rear -1;
		count = 0;
	}

//	Enqueue operation

	public void enqueue(int item)
	{
		// check for queue overflow
		if (isFull())
		{
			System.out.println("OverFlow\nProgram Terminated");
	
		}
		else if(front== -1 && rear==-1)
		{
			front=rear=0;
			System.out.println("Inserting " + item);
				arr[rear] = item;
		}
		else
		{
		System.out.println("Inserting " + item);

		rear = (rear + 1);
		arr[rear] = item;
	
		}
	}

//	Deueue operation 

	public void dequeue()
	{
                     // check for queue underflow
		if (isEmpty())
		{
			System.out.println("UnderFlow\nProgram Terminated");
		}
	
		else if(front==rear)
		{
				System.out.println("Removing " + arr[front]);
				count=0;
				front=rear=-1;		
		}
		else
		{
 
		System.out.println("Removing " + arr[front]);
 
		front = (front + 1);
		}
 	}

//	Peek operation

	public int peek()
	{
		if (isEmpty())
		{
			System.out.println("UnderFlow\nProgram Terminated");
	
		}
		return arr[front];
	}

//	isEmpty operation

	public Boolean isEmpty()
	{
		return (front == rear ==-1);
	}

//	isFull operation

	// Utility function to check if the queue is full or not
	public Boolean isFull()
	{
		return rear==capacity-1;
	}
	

	}
}