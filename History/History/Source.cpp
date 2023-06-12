#include<iostream>

union 
{
	bool myBool;
	int myInt;
	double myDouble;
}MyUnion;
int main() {
	/*std::cout << sizeof(MyUnion) << std::endl;*/
	MyUnion.myDouble = 1.2;
	std::cout << MyUnion.myDouble << std::endl;

	MyUnion.myInt = 23;
	std::cout << MyUnion.myInt << std::endl;


	MyUnion.myBool = true;
	std::cout <<std::boolalpha<< MyUnion.myBool << std::endl;
}