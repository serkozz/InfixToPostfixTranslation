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
        Dictionary<char, double> numberMeanings = new Dictionary<char, double>();
        Dictionary<string, string> functionMeanings = new Dictionary<string, string>();

        string stackString;
        string postfixString;
        char[] postfixStringCharArray;
        int postfixIndex = 0;
        string currentPostfixString; // Для потактового режима вывода (отображение входной строки)
        string resultString = string.Empty;

        const byte resultCharArraysize = 200;
        const char postfixStringEndSymbol = '\0';
        const string mathOperations = "+-*/^";
        double result;

        bool isTactMode = false; // Определяет работу метода в пошаговом режиме
        bool isTactAvailable = true; // Флаг доступности очередного такта в потактовом режиме
        bool isEnded = false; // Флаг окончания преобразований
        bool isTactButtonPressed = false;

        public Calculation(string postfixString, Dictionary<char, double> numberMeanings, Dictionary<string, string> functionMeanings, bool isTactMode)
        {
            this.postfixString = postfixString + postfixStringEndSymbol;
            this.isTactMode = isTactMode;

            stack = new Stack(Stack.StackType.CalculationStack);
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

        public string GetResultString() // Получение выходной строки
        {
            return resultString;
        }

        public string GetPostfixString() // Получение исходной постфиксной строки
        {
            return postfixString;
        }

        public string GetCurrentPostfixString() // Получение текущей постфиксной строки
        {
            return currentPostfixString;
        }
        public void General()
        {
            if (!isTactMode)
            {
                postfixStringCharArray = postfixString.ToCharArray();
                CalculatePostfix(postfixStringCharArray, isTactMode: false);
                resultString = result.ToString();
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
                        resultString = result.ToString();
                        stackString = string.Join(" ", stack.GetStack(true));
                        Console.WriteLine("Input string: " + currentPostfixString + "\nOutput string: " + resultString + "\nStack: " + stackString + "\nStackPointer: " + stack.GetStackPointerPos() + "\n");

                        ReleaseTactButtonPressed();
                    }
                    if (isEnded)
                    {
                        Console.WriteLine("\nУспешно завершено! Нажмите Escape для выхода...");
                        System.Windows.Forms.MessageBox.Show("Выражение успешно вычислено!");
                        break;
                    }
                    if (!isTactButtonPressed)
                        break;
                }
            }
        }

        public void CalculatePostfix(char[] postfixCharArray, bool isTactMode)
        {
            byte decision = 0;
            double value = 0;
            double tempResult = 0;
            /*          1 – если входящий элемент число, добавляем его в стек;
                        2 – если входящий элемент операция, берем два последних числа и производим ее;
                        3 – если входящий элемент функция, то берем предыдущее число и вычисляем функцию от него;
                        4 – успешное окончание расчетов;
                        5 – ошибка (в функцию передано невозможное значение (ln(-...)));
            */
            do
            {
                /// 1
                if (numberMeanings.ContainsKey(postfixCharArray[postfixIndex]))
                {
                    decision = 1;
                }
                /// 2
                else if (mathOperations.Contains(postfixCharArray[postfixIndex]))
                {
                    decision = 2;
                }
                /// 3
                else if (functionMeanings.ContainsKey(postfixCharArray[postfixIndex].ToString()))
                {
                    decision = 3;
                }
                /// 4
                else if (postfixCharArray[postfixIndex] == postfixStringEndSymbol)
                {
                    decision = 4;
                }

                switch (decision)
                {
                    case 1:
                        value = numberMeanings[postfixCharArray[postfixIndex]];
                        Console.WriteLine("--- CalculationStackValueParsed: " + value + " ---");
                        stack.Push(value);
                        postfixIndex++;
                        if (isTactMode)
                            isTactAvailable = false;
                        break;

                    case 2:
                        char operation = postfixCharArray[postfixIndex];
                        double firstOperator = stack.GetStackElement((stack.GetStackPointerPos() - 2), true); // В параметры передана заглушка, которая различает перегрузки метода stack.GetStackElement(int index)
                        double secondOperator = stack.GetStackElement((stack.GetStackPointerPos() - 1), true);
                        tempResult = 0;

                        switch (operation)
                        {
                            case '+':
                                tempResult = firstOperator + secondOperator;
                                break;
                            case '-':
                                tempResult = firstOperator - secondOperator;
                                break;
                            case '*':
                                tempResult = firstOperator * secondOperator;
                                break;
                            case '/':
                                tempResult = firstOperator / secondOperator;
                                break;
                            case '^':
                                tempResult = Math.Pow(firstOperator, secondOperator);
                                break;
                        }

                        stack.DeleteLastStackItem(times: 2);
                        stack.Push(tempResult);
                        postfixIndex++;

                        if (isTactMode)
                            isTactAvailable = false;
                        break;

                    case 3:
                        string function = functionMeanings[postfixCharArray[postfixIndex].ToString()];

                        if (function == "sin" || function == "cos")
                            value = DegreesToRadians(stack.Pop(true)); // В параметры передана заглушка, которая различает перегрузки метода stack.Pop()
                        else
                            value = stack.Pop(true);

                        tempResult = 0;

                        switch (function)
                        {
                            case "sin": // sin
                                tempResult = Math.Sin(value);
                                break;
                            case "cos": // cos
                                tempResult = Math.Cos(value);
                                break;
                            case "sqrt": // sqrt
                                if (value >= 0)
                                    tempResult = Math.Sqrt(value);
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show("Недопустимое подкоренное выражение!");
                                    return;
                                }
                                break;
                            case "ln": // ln
                                if (value > 0)
                                    tempResult = Math.Log(value);
                                else if (value == 0)
                                    tempResult = Double.PositiveInfinity;
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show("Невозможно найти натуральный логарифм от заданного числа!");
                                    return;
                                }
                                break;
                        }
                        stack.Push(tempResult);
                        postfixIndex++;

                        if (isTactMode)
                            isTactAvailable = false;
                        break;

                    case 4:
                        result = stack.Pop(true);

                        if (isTactMode)
                            isTactAvailable = false;
                        isEnded = true;
                        return;

                }
            }
            while (postfixIndex < postfixCharArray.Length && isTactAvailable && !isEnded);
        }

        public double DegreesToRadians(double degreesAngle)
        {
            double radians = (degreesAngle * Math.PI) / 180;
            return radians;
        }

        public char[] CreateCurrentPostfixString(char[] postfixStringCharArray, int postfixIndex)
        {
            List<char> currentPostfixString = new List<char>();
            currentPostfixString.Clear();

            for (int i = postfixStringCharArray.Length - 1; i > postfixIndex - 1; i--)
            {
                currentPostfixString.Add(postfixStringCharArray[i]);
            }
            currentPostfixString.Reverse();
            return currentPostfixString.ToArray();
        }
    }
}
