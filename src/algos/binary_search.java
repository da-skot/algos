/*
Дано два списка чисел, числа в первом списке упорядочены по неубыванию. Для каждого числа из второго списка определите номер первого и последнего появления этого числа в первом списке.
Формат ввода

В первой строке входных данных записано два числа N и M (1 <= N, M <= 20000). Во второй строке записано N упорядоченных по неубыванию целых чисел — элементы первого списка. В третьей строке записаны M целых неотрицательных чисел - элементы второго списка. Все числа в списках - целые 32-битные знаковые.
Формат вывода

Программа должна вывести M строчек. Для каждого числа из второго списка нужно вывести номер его первого и последнего вхождения в первый список. Нумерация начинается с единицы. Если число не входит в первый список, нужно вывести одно число 0. 
*/

import java.util.Scanner;

public class Main {

	public static void main (String[] args) {
		Scanner in = new Scanner(System.in);
		int n = in.nextInt();
		int m = in.nextInt();
		int[] arr = new int[n];
		for (int i = 0; i < n; i++) {
			arr[i] = in.nextInt();
		}
		int[] ps = new int[m];
		for (int i = 0; i < m; i++) {
			ps[i] = in.nextInt();
		}
		in.close();
		for (int i = 0; i < m; i++){
			search(arr, ps[i]);
		}
	}
	public static void search (int[] arr, int x)
	{
		int l = -1, l1 = -1, r = arr.length, r1 = arr.length;
		while (r-l > 1){
			int m = (l + r) / 2;
			if (arr[m] < x)
				l = m;
			else
				r = m;
		}
		while (r1-l1 > 1){
			int m = (l1 + r1) / 2;
			if (arr[m] <= x)
				l1 = m;
			else
				r1 = m;
		}
		if ((l == l1) && (r == r1))
			System.out.println(0);
		else
			System.out.printf(r+1 + " " + (l1+1) + "\n");
	}
}
