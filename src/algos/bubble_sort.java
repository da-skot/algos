/*
Требуется отсортировать массив по неубыванию методом "пузырька".
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
			for (int j = 0; j < n - i - 1; j++) {
				if (arr[j] > arr[j+1]){
					int x = arr[j];
					arr[j] = arr[j+1];
					arr[j+1] = x;
				}
			}
		}
		for (int i = 0; i < n; i++) {
			System.out.print(arr[i] + " ");
		}
	}
}
