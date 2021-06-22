/*


Напомним, что ориентированный граф называется транзитивным, если для любых трех различных вершин u, v и w из того, 
что из u в вершину v ведет ребро и из вершины v в вершину w ведет ребро, следует, что из вершины u в вершину w ведет ребро. 
Проверьте, что заданный ориентированный граф является транзитивным.
Формат ввода

Сначала вводится число n (1<=n<=100) – количество вершин в графе, а затем n строк по n чисел, каждое из которых равно 0 или 1, – его матрица смежности.
Формат вывода

Выведите «YES», если граф является транзитивным, и «NO» в противном случае.
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
		Boolean boo = true;
		for (int i = 0; i < arr.length; i++) {
			for (int j = 0; j < arr[i].length; j++) {
				if (arr[i][j] == 1 && (i != j)){
					for (int k = 0; k < arr[j].length; k++) {
						if (arr[j][k] == 1) {
							if (arr[i][k] == 1)
								boo = true;
							else
								boo = false;
						}
						if (!boo)
							break;
					}
				}
				if (!boo)
					break;
			}
			if (!boo)
				break;
		}
		if (boo)
			System.out.println("YES");
		else
			System.out.println("NO");
	}
}
