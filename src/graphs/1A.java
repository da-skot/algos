/*
Ориентированный граф задан матрицей смежности, выведите его представление в виде списка ребер.
Формат ввода

На вход программы поступает число n (1<=n<=100) – количество вершин графа, а затем n строк по n чисел, каждое из которых равно 0 или 1, – его матрица смежности.
Формат вывода

Выведите список ребер заданного графа.
*/

import java.util.Scanner;

public class Main {

    public static void main (String[] args) {
        Scanner in = new Scanner(System.in);
        int n = in.nextInt();
        int[][] arr = new int[n][n];
        for (int i = 0; i < arr.length; i++) {
            for (int j = 0; j < arr[i].length; j++) {
                arr[i][j] = in.nextInt();
            }
        }
        in.close();
        for (int i = 0; i < arr.length; i++) {
            for (int j = 0; j < arr[i].length; j++) {
                if (arr[i][j] == 1){
                    System.out.printf("%d %d\n", i+1, j+1);

                }
            }
        }
    }
}
