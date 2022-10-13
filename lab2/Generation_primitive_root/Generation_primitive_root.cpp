#include <iostream>
#include <vector>
#include <fstream>

unsigned long powmod(unsigned long a, unsigned long b, unsigned long p)
{
	int res = 1;
	while (b)
		if (b & 1)
			res = unsigned long(res * 1ll * a % p), --b;
		else
			a = unsigned long(a * 1ll * a % p), b >>= 1;
	return res;
}

unsigned long generator(unsigned long p)
{
	std::ofstream out("out.txt");
	std::vector<unsigned long> fact;
	unsigned long phi = p - 1, n = phi;
	for (unsigned long i = 2; i * i <= n; ++i)
		if (n % i == 0) {
			fact.push_back(i);
			while (n % i == 0)
				n /= i;
		}
	if (n > 1)
		fact.push_back(n);

	int countNumber = 0;
	for (unsigned long res = p / 2; res >= 2; --res)
	{
		bool ok = true;
		for (size_t i = 0; i < fact.size() && ok; ++i)
			ok &= powmod(res, phi / fact[i], p) != 1;
		if (ok)
			if (countNumber < 20)
			{
				out << res << std::endl;
				++countNumber;
			}
		if (countNumber == 20) return 0;
	}
	out.close();
	return -1;
}

int main()
{
	setlocale(LC_ALL, "ru");
	unsigned long p;
	std::cout << "Введите простое число p" << std::endl;
	std::cout << "В файл выведется до 20-и чисел(первообразных по модулю p лежащих ниже середины отрезка [1,p])" << std::endl;
	std::cin >> p;
	generator(p);
}