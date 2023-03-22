public class Board{
        public static void showBoard() {
            System.out.println("BOARD GAME");
            System.out.println("-----------------");

            for (int i = 0; i < 6; i++) {
                System.out.print("|_");
                for (int j = 0; j < 7; j++)
                    System.out.print("_|");
                System.out.println("\n");
            }
            System.out.println("-----------------");
        }
    }
