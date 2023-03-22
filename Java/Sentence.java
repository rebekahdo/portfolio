import java.until.*;
public class Sentence
{
	public static void main(String[] args)
	{
		Scanner kb = new Scanner();
		System.print.ln("Input a sentence");
		temp = kb.next();
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
}