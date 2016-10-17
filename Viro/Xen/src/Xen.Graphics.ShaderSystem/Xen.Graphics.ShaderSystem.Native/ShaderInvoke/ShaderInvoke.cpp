// ShaderInvoke.cpp : main project file.

#include "stdafx.h"

using namespace System;

int main(array<System::String ^> ^args)
{
	Xen::Graphics::ShaderSystem::Native::ShaderDecompiler^ sc = gcnew Xen::Graphics::ShaderSystem::Native::ShaderDecompiler(System::IO::File::ReadAllBytes("C:\\Users\\Graham\\Projects\\xen_xna4\\xen\\xen\\src\\Xen.Lx\\Shaders\\Setup.fx"),"C:\\Users\\Graham\\Projects\\xen_xna4\\xen\\xen\\src\\Xen.Lx\\Shaders\\Setup.fx",false,nullptr);

    return 0;
}
