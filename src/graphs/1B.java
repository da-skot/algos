/*
Ориентированный граф задан списком ребер. Найдите степени всех вершин графа.
Формат ввода

Сначала вводятся числа n (1 <= n <= 100) – количество вершин в графе и m (1 <= m <= n(n-1)) – количество ребер. Затем следует m пар чисел – ребра графа.
Формат вывода

Выведите n пар чисел – для каждой вершины сначала выведите полустепень захода и затем полустепень исхода.
*/

import java.util.Scanner;

public class Main {

    public static void main (String[] args) {
        Scanner in = new Scanner(System.in);
        int n = in.nextInt();
        int[] inArr = new int[n];
        int[] outArr = new int[n];
        int m = in.nextInt();
        for (int i = 0; i < m; i++) {
            int a = in.nextInt();
            inArr[a-1]++;
            int b = in.nextInt();
            outArr[b-1]++;
        }
        in.close();
        for (int i = 0; i < n; i++) {
            System.out.println(outArr[i]);
            System.out.println(inArr[i]);
        }
    }
}
