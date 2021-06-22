/*
Найдите перестановку по её номеру в лексикографическом порядке.

Формат ввода
В первой строке входных данных содержится число N (1 <= N <= 12) – количество элементов в перестановке, во второй – число K (1 <= K <= N!) – номер перестановки.

Формат вывода
Выведите N чисел – искомую перестановку.
*/
#include <iostream>
#include <vector>

using std::vector;
using std::cin;
using std::cout;

int main(){

    int n, m;
    vector<int> f = {1, 1, 2, 6, 24, 120, 720, 5040, 40320,
                     362880, 3628800, 39916800, 479001600};
    vector<bool> used;
    cin >> n >> m;
    used.resize(n + 1);
    vector<int> p;
    for (int i = 0; i < n; ++i){

        int was = (m - 1) / f[n  - 1 - i] + 1;
        m = (m - 1) % f[n  - 1 - i] + 1;

        int current = 0;
        for (int j = 0; j < n; ++j){
            if (!used[j])
                ++current;
            if (current == was){
                p.push_back(j);
                used[j] = true;
                break;
            }
        }

    }

    for (int item : p) cout << item + 1 << " ";

    return 0;
}
