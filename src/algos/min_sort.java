/*
Требуется отсортировать массив по неубыванию методом "выбор максимума".
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
		for (int i = 0; i < n-1; i++){
			int min = i;
			for (int j = i+1; j < n; j++) {
				if (arr[j] < arr[min])
					min = j;
			}
			int x = arr[i];
			arr[i] = arr[min];
			arr[min] = x;
		}
		for (int i = 0; i < n; i++) {
			System.out.print(arr[i] + " ");
		}
	}
}
