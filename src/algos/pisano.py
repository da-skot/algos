/*
Даны целые числа 1≤n≤1018 и 2≤m≤105, необходимо найти остаток от деления n-го числа Фибоначчи на m.

Задача из курса «Алгоритмы: теория и практика. Методы»: https://stepik.org/course/217/syllabus

Формат ввода
В первой строке входных данных два целых числа n и m.
Формат вывода
Выведите Fnmodm. 
*/

def get_pisano_array(n: int, m: int) -> list:
    pisano = [0]
    if m == 1:
        return pisano
    pisano.append(1)
    if n <= 1:
        return pisano
    pisano.append((pisano[len(pisano) - 1] + pisano[len(pisano) - 2]) % m)
    while not (pisano[- 1] == 1 and pisano[- 2] == 0):
        pisano.append((pisano[len(pisano) - 1] + pisano[len(pisano) - 2]) % m)
    return pisano[:-2]
def fib_mod(n, m):
    pisano = get_pisano_array(n, m)
    return pisano[n % len(pisano)]
def main():
    n, m = map(int, input().split())
    print(fib_mod(n, m))
if __name__ == "__main__":
    main()
