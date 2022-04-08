using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionsTranslation
{
    public class Calculation
    {
        public Stack stack; // этот стек отличен от стека в Transformation

        string postfixString;
        char[] postfixStringCharArray;
        int postfixInde = 0;
        const char postfixStringEndSymbol = '\0';
        const char whiteSpace = ' ';

        string currentPostfixString; // Для потактового режима вывода (отображение входной строки)

        string resultString = string.Empty;
        const byte resultCharArraysize = 200;
        char[] resultCharArray = new char[resultCharArraysize];
        int resultIndex = 0;

        string stackString = string.Empty;

        bool isTactMode = false; // Определяет работу метода в пошаговом режиме
        bool isTactAvailable = true; // Флаг доступности очередного такта в потактовом режиме
        bool isEnded = false; // Флаг окончания преобразований
        bool isTactButtonPressed = false;

        public Calculation(string postfixString, bool isTactMode)
        {
            this.postfixString = postfixString + postfixStringEndSymbol;
            this.isTactMode = isTactMode;
            this.stack = new Stack();
        }

        public void SetTactButtonPressed() // Метод, вызываемый извне для модификации переменной отвечающей за потактовое продвижение алгоритма
        {
            isTactButtonPressed = true;
        }

        public bool GetTactMode() // Используется для отображения стека (если true, то стек отображается)
        {
            return isTactMode;
        }

        public bool GetEndFlag() // Используется для получения признака завершения алгоритма
        {
            return isEnded;
        }

        public void ReleaseTactButtonPressed() // Метод, вызываемый извне для модификации переменной отвечающей за потактовое продвижение алгоритма
        {
            isTactButtonPressed = false;
        }
    
        public void CalculatePostfix()
        {
        /*            //Создаем стек для работы (создан в конструкторе)
                    val stack = mutableListOf<Int>()
            // Перебераем все эелементы очереди
            for (item in queue)
                    {
                        when {
                            // Если входящий элемент - число, то добавляем в стек
                            Regex("[\\d]").containsMatchIn(item)-> {
                                stack.add(item.toInt())
                           }
                            *//* Если входящий элемент + , берем два последних элемента
                            и производим советующую операцию *//*
                            item == "+"-> {
                                stack[stack.lastIndex - 1] = stack[stack.lastIndex - 1] + stack.last()
                               stack.removeAt(stack.lastIndex)
                           }
                            *//* Если входящий элемент * , берем два последних элемента
                            и производим советующую операцию *//*
                            item == "*"-> {
                                stack[stack.lastIndex - 1] = stack[stack.lastIndex - 1] * stack.last()
                               stack.removeAt(stack.lastIndex)
                           }
                            *//* Если входящий элемент / , берем два последних элемента
                            и производим советующую операцию *//*
                            item == "/"-> {
                                stack[stack.lastIndex - 1] = stack[stack.lastIndex - 1] / stack.last()
                               stack.removeAt(stack.lastIndex)
                           }
                            *//* Если входящий элемент -, берем два последних элемента
                             и производим советующую операцию *//*
                            item == "-"-> {
                                stack[stack.lastIndex - 1] = stack[stack.lastIndex - 1] - stack.last()
                               stack.removeAt(stack.lastIndex)
                           }
                        }*/


            }
    }
}
