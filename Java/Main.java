import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        // Initialize the variable for the menu selection

        // Initialize the variable response
        String response = "-1";
        Scanner myScanner = new Scanner(System.in);

        // This loop will make sure the user stay on the menu or exit when press 4.
        do{
            //Call the display menu function
            displayMenu();
            System.out.println("Please select one of the options: ");
            response = myScanner.next();
            switch (response){


                case "1":
                    System.out.println("Let's start the game!");
                    break;

                case "2":
                    System.out.println("******* LOADING YOUR SAVED GAME *******");
                    break;

                // The option 3 read the file and display it to the user.
                case "3":
                    readFile();
                    break;

                case "4":
                    System.out.println("Thank you For Playing the game!");
                    break;

            }

        } while(!response.equals("4"));

    }
    public static void displayMenu(){
        /* Display the menu of the game
        * where the user has access to choose
        * one of the options as needed. */
        System.out.println("CONNECT 4 GAME");
        System.out.println("PRESS 1 TO Play");
        System.out.println("PRESS 2 TO Load your save game");
        System.out.println("PRESS 3 TO learn how to play");
        System.out.println("PRESS 4 to Exit");
    }

    public static void readFile() {
        /*This function read the file that explains
        * how to play the CONNECT 4 game*/
            try {
                File myFile = new File("Connect4.txt");
                Scanner myReader = new Scanner(myFile);
                while (myReader.hasNextLine()) {
                    String data = myReader.nextLine();
                    System.out.println(data);
                }
                myReader.close();
            } catch (Exception e) {
                System.out.println("An error occurred.");
                e.printStackTrace();
            }
        }
    }


