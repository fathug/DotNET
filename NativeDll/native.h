#pragma once

// ����һЩ��
#ifdef __cplusplus
#define EXTERN extern "C"
#else
#define EXTERN
#endif

#define CallingConvention _cdecl

// �ж��û��Ƿ������룬�Ӷ���������ʹ��dllimport����dllexport
#ifdef DLL_IMPORT 
#define HEAD EXTERN __declspec(dllimport)
#else
#define  HEAD EXTERN __declspec(dllexport)
#endif

HEAD int CallingConvention Sum(int a, int b);
