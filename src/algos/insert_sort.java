/*
Требуется отсортировать массив по неубыванию методом "вставок".
Формат ввода

В первой строке вводится одно натуральное число, не превосходящее 1000 – размер массива. Во второй строке задаются N чисел – элементы массива (целые числа, не превосходящие по модулю 1000).
Формат вывода

Вывести получившийся массив.
*/

import java.util.Scanner;

public class Main {

	public static void main (String[] args) {
		Scanner in = new Scanner(System.in);
		int n = in.nextInt();
		int[] arr = new int[n];
		for (int i = 0; i < n; i++) {
			arr[i] = in.nextInt();
		}
		in.close();
		for (int i = 1; i < n; i++){
			int x = arr[i];
			int k = i - 1;
			while (k>=0 && arr[k] > x){
				arr[k+1] = arr[k];
				arr[k] = x;
				k--;
			}
		}
		for (int i = 0; i < n; i++) {
			System.out.print(arr[i] + " ");
		}
	}
}
