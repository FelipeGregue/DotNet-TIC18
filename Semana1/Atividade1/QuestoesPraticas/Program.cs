Console.WriteLine("Atividade pratica 1");
#region Questao 3
Console.WriteLine("\nQuestao 3");

double varDouble = 3.7;
int varInt = (int)varDouble;

Console.WriteLine("Valor Double: " + varDouble);
Console.WriteLine("Valor Inteiro: " + varInt);

// O casting double para int causa a perda da parte fracionária do double.
#endregion

#region Questao 4

int x = 10, y = 3;
Console.WriteLine("\nQuestao 4");
Console.WriteLine("X: " + x + " e Y: " + y);
Console.WriteLine("Adição: " + (x + y));
Console.WriteLine("Subtração: " + (x - y));
Console.WriteLine("Multiplicação: " + (x * y));
Console.WriteLine("Divisão: " + (x / y));
#endregion

#region Questao 5

Console.WriteLine("\nQuestao 5");
int a = 5;
int b = 8;

if(a > b){
  Console.WriteLine("A e maior que B");
}else{
  Console.WriteLine("B e maior que A");
}
#endregion

#region Questao 6
Console.WriteLine("\nQuestao 6");
string texto1 = "Hello",texto2 = "World";
Console.WriteLine("Strings: " + texto1 + " e " + texto2);
if(texto1 == texto2){
  Console.WriteLine("Sao iguais");
}else{
  Console.WriteLine("Sao diferentes");
}
#endregion

#region Questao 7
Console.WriteLine("\nQuestao 7");
bool condicao1 = true, condicao2 = false;

if(condicao1 && condicao2){
  Console.WriteLine("São iguais");
}else{
  Console.WriteLine("São diferentes");
}
#endregion

#region Questao 8
Console.WriteLine("\nQuestao 8");
int num1 = 7, num2 = 3, num3 = 10;
Console.WriteLine("num1: " + num1 + ", num2: " + num2 + ", num3: " + num3);
if(num1 > num2){
  Console.WriteLine("num 1 e maior que num2");
}
if(num3 == num1 + num2){
  Console.WriteLine("num3 e igual a num1 + num2");
}else{
  Console.WriteLine("num3 e diferente de (num1 + num2");
}
#endregion