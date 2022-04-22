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
        Dictionary<string, string> numberMeanings;
        Dictionary<string, string> functionMeanings;

        string postfixString;
        char[] postfixStringCharArray;
        int postfixIndex = 0;
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

        public Calculation(string postfixString, Dictionary<string, string> numberMeanings, Dictionary<string, string> functionMeanings, bool isTactMode)
        {
            this.postfixString = postfixString + postfixStringEndSymbol;
            this.isTactMode = isTactMode;

            this.stack = new Stack();
            this.numberMeanings = numberMeanings;
            this.functionMeanings = functionMeanings;
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

        public void General()
        {
            if (!isTactMode)
            {
                postfixStringCharArray = postfixString.ToCharArray();
                CalculatePostfix(postfixStringCharArray, isTactMode: false);
                resultString = string.Join(null, resultCharArray);
            }
            else if (isTactMode)
            {
                postfixStringCharArray = postfixString.ToCharArray();

                while (true)
                {
                    if (isTactButtonPressed && !isEnded)
                    {
                        CalculatePostfix(postfixStringCharArray, isTactMode: true);
                        currentPostfixString = string.Join(null, CreateCurrentPostfixString(postfixStringCharArray, postfixIndex));
                        resultString = string.Join(null, resultCharArray);
                        stackString = string.Join(" ", stack.GetStack());
                        Console.WriteLine("Input string: " + currentPostfixString + "\nOutput string: " + resultString + "\nStack: " + stackString + "\nStackPointer: " + stack.GetStackPointerPos() + "\n");

                        ReleaseTactButtonPressed();
                    }
                    if (isEnded)
                    {
                        Console.WriteLine("\nУспешно завершено! Нажмите Escape для выхода...");
                        System.Windows.Forms.MessageBox.Show("Выражение успешно вычислено выполнен!");
                        break;
                    }
                    if (!isTactButtonPressed)
                        break;
                }
            }
        }

        public char[] CreateCurrentPostfixString(char[] postfixStringCharArray, int postfixIndex)
        {
            List<char> currentPostfixString = new List<char>();
            currentPostfixString.Clear();

            for (int i = postfixStringCharArray.Length -1; i > postfixIndex - 1; i--)
            {
                currentPostfixString.Add(postfixStringCharArray[i]);
            }
            currentPostfixString.Reverse();
            return currentPostfixString.ToArray();
        }

        public void CalculatePostfix(char[] postfixCharArray, bool isTactMode)
        {
            byte[] decisionTable = new byte[]
            { 1, 2, 3, 4, 5};

            /*            1 – если входящий элемент число, добавляем его в стек;
            2 – если входящий элемент операция, берем два последних числа и производим ее;
            3 – если входящий элемент функция, то берем предыдущее число и вычисляем функцию от него;
            4 – успешное окончание расчетов;
            5 – ошибка (в функцию передано невозможное значение (ln(-...)));
*/
            do
            {
                /*string numberMeaningsIndexChar = postfixCharArray[postfixIndex];
                /// 1
                if (numberMeanings.ContainsKey(postfixCharArray[postfixIndex].ToString()))
                    stack.Push(numberMeanings[numberMeaningsIndexChar]);


                foreach (KeyValuePair<string, string> keyValuePair in numberMeanings)
                {
                    string numberMeaningsString = "Число: " + keyValuePair.Value + " = " + keyValuePair.Key;
                    numbersMeaningsListBox.Items.Add(numberMeaningsString);
                }*/

                /*                // Если входящий элемент - число, то добавляем в стек
                                Regex("[\\d]").containsMatchIn(item)-> {
                                    stack.add(item.toInt())
                                           }
                                *//* Если входящий элемент + , берем два последних элемента
                                и производим советующую операцию*//*
                                            item == "+"-> {
                                    stack[stack.lastIndex - 1] = stack[stack.lastIndex - 1] + stack.last()
                                               stack.removeAt(stack.lastIndex)
                                           }
                                *//* Если входящий элемент * , берем два последних элемента
                                и производим советующую операцию*//*
                                            item == "*"-> {
                                    stack[stack.lastIndex - 1] = stack[stack.lastIndex - 1] * stack.last()
                                               stack.removeAt(stack.lastIndex)
                                           }
                                *//* Если входящий элемент / , берем два последних элемента
                                и производим советующую операцию*//*
                                            item == "/"-> {
                                    stack[stack.lastIndex - 1] = stack[stack.lastIndex - 1] / stack.last()
                                               stack.removeAt(stack.lastIndex)
                                           }
                                *//* Если входящий элемент -, берем два последних элемента
                                 и производим советующую операцию*//*
                                            item == "-"-> {
                                    stack[stack.lastIndex - 1] = stack[stack.lastIndex - 1] - stack.last()
                                               stack.removeAt(stack.lastIndex)
                                           }*/

            } while (postfixIndex < postfixCharArray.Length && isTactAvailable && !isEnded);
        }
    }
}
