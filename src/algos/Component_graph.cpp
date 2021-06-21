/*


Дан неориентированный невзвешенный граф. Необходимо посчитать количество его компонент связности и вывести их.

Формат ввода

Во входном файле записано два числа N и M (0 < N ≤ 100000, 0 ≤ M ≤ 100000). В следующих M строках записаны по два числа i и j (1 ≤ i, j ≤ N), которые означают, что вершины i и j соединены ребром.

Формат вывода

В первой строчке выходного файла выведите количество компонент связности. Далее выведите сами компоненты связности в следующем формате: в первой строке количество вершин в компоненте, во второй - сами вершины в произвольном порядке. 
*/

#include <iostream>
#include <vector>
using namespace std;

const int N = 100000;
vector<int> g[N];
bool used[N];
vector<int> component;

void dfs (int v)
{
	used[v] = true;
	component.push_back(v + 1);
	for (int i : g[v])
    	{
		if (!used[i])
        {
			dfs (i);
        }
    }
}

int main(int argc, char **argv)
{
    int n, m;
    cin >> n >> m;
    for (int i = 0; i < m; i++)
    {
        int in_node, out_node;
        cin >> out_node >> in_node;
        g[out_node - 1].push_back(in_node - 1);
        g[in_node - 1].push_back(out_node - 1);
    }
    used[n];
    int count = 0;
    for (int i = 0; i < n; i++)
    {
        if (!used[i])
        {
            component.clear();
            dfs(i);
            count++;
        }
    }
    for (int i = 0; i < n; i++)
	used[i] = false;
    cout << count << endl;
    for (int i = 0; i < n; i++)
    {
        if (!used[i])
        {
            component.clear();
            dfs(i);
            cout << component.size() << endl;
            for (int x : component)
            {
                cout << x << " ";
            }
            cout << endl;
        }
    }
    return 0;
}
