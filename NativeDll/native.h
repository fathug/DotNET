#pragma once

// 定义一些宏
#ifdef __cplusplus
#define EXTERN extern "C"
#else
#define EXTERN
#endif

#define CallingConvention _cdecl

// 判断用户是否有输入，从而定义区分使用dllimport还是dllexport
#ifdef DLL_IMPORT 
#define HEAD EXTERN __declspec(dllimport)
#else
#define  HEAD EXTERN __declspec(dllexport)
#endif

HEAD int CallingConvention Sum(int a, int b);
