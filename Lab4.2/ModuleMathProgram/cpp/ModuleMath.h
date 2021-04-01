#pragma once

#ifdef MODULEMATHDLL_EXPORTS
#define MODULEMATHLIBRARY_API __declspec(dllexport)
#else
#define MODULEMATHLIBRARY_API __declspec(dllimport)
#endif

extern "C" {
    MODULEMATHLIBRARY_API long long _cdecl BinPow(long long number, long long power, long long mod);
    MODULEMATHLIBRARY_API long long _cdecl Factorial(long long n, long long mod);
    MODULEMATHLIBRARY_API long long _cdecl C(long long n, long long k, long long mod);
}