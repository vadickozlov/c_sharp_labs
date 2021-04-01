#include "pch.h"
#include <utility>
#include "ModuleMath.h"

long long BinPow(long long number, long long power, long long mod) {
    if (power == 0) {
        return 1;
    }
    long long result = BinPow(number, power / 2, mod);
    if (power & 1) {
        return result * result % mod * number % mod;
    }
    else {
        return result * result % mod;
    }
}

long long Factorial(long long n, long long mod) {
    long long result = 1;
    for (int i = 1; i <= n; i++) {
        result = (result * i) % mod;
    }
    return result;
}

long long C(long long n, long long k, long long mod) {
    if (k > n) return 0;
    long long n_fact = Factorial(n, mod);
    long long n_k_inv = BinPow(Factorial(n - k, mod), mod - 2, mod);
    long long k_inv = BinPow(Factorial(k, mod), mod - 2, mod);
    return n_fact * n_k_inv % mod * k_inv % mod;
}