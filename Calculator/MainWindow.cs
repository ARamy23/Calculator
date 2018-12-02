using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    float input;
    float firstNumber;
    float secondNumber;
    float results;
    bool isFirstNumber = false;
    bool isSecondNumber = false;
    int op; //operator
    char opChar;
    bool isUsingDecimal = false;
    float divBy10 = 1;
    int i;
    int l = 1;
    bool flag = false;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private void handleNumberClick(int number) {
        input = number;
        if(!isSecondNumber) {
            if (!isFirstNumber)
            {
                if (!isUsingDecimal)
                {
                    firstNumber = input;
                    isFirstNumber = true;
                } else {
                    l++;
                    for (i = 0; i < l; i++)
                    {
                        divBy10 /= 10;
                    }
                    firstNumber = divBy10 * input;
                    isFirstNumber = true;
                }
            }
            else
            {
                if (!isUsingDecimal)
                {
                    firstNumber = (firstNumber * 10) + input;
                } else {
                    for (i = 0; i < l; i++)
                    {
                        divBy10 /= 10;
                    }
                    firstNumber += (divBy10 * input);
                }
            }

            this.entryBox.Text = Convert.ToString(firstNumber);
        } else {
            if (!isFirstNumber)
            {
                if (!isUsingDecimal)
                {
                    secondNumber = input;
                    isFirstNumber = true;
                } else {
                    l++;
                    for (int i = 0; i < l; i++)
                    {
                        divBy10 /= 10;
                    }
                    secondNumber = divBy10 * input;
                    isFirstNumber = true;
                }
            }
            else
            {
                if (!isUsingDecimal)
                {
                    secondNumber = (secondNumber * 10) + number;
                }
                else
                {
                    l++;
                    for (i = 0; i < l; i++)
                    {
                        divBy10 /= 10;
                    }
                    secondNumber += (divBy10 * input);
                }
            }

            this.entryBox.Text = Convert.ToString(firstNumber) + " " + opChar + " " + Convert.ToString(secondNumber);
        }
    }

    protected void clickedOne(object sender, EventArgs e)
    {
        handleNumberClick(1);
    }

    protected void clickZero(object sender, EventArgs e)
    {
        handleNumberClick(0);
    }

    protected void clickDot(object sender, EventArgs e)
    {
        isUsingDecimal = true;
        if(isFirstNumber) {
            this.entryBox.Text = Convert.ToString(firstNumber) + ".";
        } else if(isSecondNumber) {
            this.entryBox.Text = Convert.ToString(firstNumber) + " " + opChar + " " + Convert.ToString(secondNumber) + ".";
            isUsingDecimal = true;
        }
    }

    protected void clickTwo(object sender, EventArgs e)
    {
        handleNumberClick(2);
    }

    protected void clickThree(object sender, EventArgs e)
    {
        handleNumberClick(3);
    }

    protected void clickFour(object sender, EventArgs e)
    {
        handleNumberClick(4);
    }

    protected void clickFive(object sender, EventArgs e)
    {
        handleNumberClick(5);
    }

    protected void clickSix(object sender, EventArgs e)
    {
        handleNumberClick(6);
    }

    protected void clickSeven(object sender, EventArgs e)
    {
        handleNumberClick(7);
    }

    protected void clickEight(object sender, EventArgs e)
    {
        handleNumberClick(8);
    }

    protected void clickNine(object sender, EventArgs e)
    {
        handleNumberClick(9);
    }

    protected void clickSqrt(object sender, EventArgs e)
    {
        if (isSecondNumber)
        {
            this.entryBox.Text = "you can make the root of only first number";
        }
        else if (!isFirstNumber)
        {
            this.entryBox.Text = "Input a number first";
        } else if(firstNumber < 0)
        {
            this.entryBox.Text = "Sqrt can't be applied to a negative number";
        }
        else {
            this.entryBox.Text = Convert.ToString(Math.Sqrt(firstNumber));
            firstNumber = 0;
            secondNumber = 0;
            isSecondNumber = false;
            isFirstNumber = false;
        }
    }

    protected void clickEqual(object sender, EventArgs e)
    {
        switch(op) { 
            case 1:
                results = firstNumber + secondNumber;
                break;
            case 2:
                results = firstNumber - secondNumber;
                break;
            case 3:
                results = firstNumber * secondNumber;
                break;
            case 4:
                if (secondNumber.Equals(0.0f))
                    flag = true;
                else 
                    results = firstNumber / secondNumber;
                break;
            case 5:
                results = firstNumber % secondNumber;
                break;
        }

        if (flag)
            this.entryBox.Text = "Operation can't be performed!";
        else
            this.entryBox.Text = Convert.ToString(firstNumber) + " " + opChar + " " + Convert.ToString(secondNumber) + " = " + results;
        firstNumber = 0;
        secondNumber = 0;
        isSecondNumber = false;
        isFirstNumber = false;
        divBy10 = 1;
        isUsingDecimal = false;
        l = 1;
        flag = false;
    }

    protected void clickAdd(object sender, EventArgs e)
    {
        op = 1;
        opChar = '+';
        isSecondNumber = true;
        divBy10 = 1;
        isUsingDecimal = false;
        l = 0;
        this.entryBox.Text = Convert.ToString(firstNumber) + " " + opChar;
    }

    protected void clickMinus(object sender, EventArgs e)
    {
        op = 2;
        opChar = '-';
        isSecondNumber = true;
        divBy10 = 1;
        isUsingDecimal = false;
        l = 0;
        this.entryBox.Text = Convert.ToString(firstNumber) + " " + opChar;
    }

    protected void clickMultiply(object sender, EventArgs e)
    {
        op = 3;
        opChar = 'x';
        isSecondNumber = true;
        divBy10 = 1;
        isUsingDecimal = false;
        l = 0;
        this.entryBox.Text = Convert.ToString(firstNumber) + " " + opChar;
    }

    protected void clickDivide(object sender, EventArgs e)
    {
        op = 4;
        opChar = '/';
        isSecondNumber = true;
        divBy10 = 1;
        isUsingDecimal = false;
        l = 0;
        this.entryBox.Text = Convert.ToString(firstNumber) + " " + opChar;
    }

    protected void clickModulo(object sender, EventArgs e)
    {
        op = 5;
        opChar = '%';
        isSecondNumber = true;
        divBy10 = 1;
        isUsingDecimal = false;
        l = 0;
        this.entryBox.Text = Convert.ToString(firstNumber) + " " + opChar;
    }

    protected void clickPlusMinus(object sender, EventArgs e)
    {
        if (isFirstNumber)
        {
            firstNumber *= -1;
            this.entryBox.Text = Convert.ToString(firstNumber);
        }
        else
        {
            secondNumber *= -1;
            this.entryBox.Text = Convert.ToString(firstNumber) + " " + opChar + " " + Convert.ToString(secondNumber);
        }
        l = 1;
        divBy10 = 0;
    }

    protected void clickClear(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        isFirstNumber = false;
        isSecondNumber = false;
        divBy10 = 1;
        l = 1;
        isUsingDecimal = false;
        this.entryBox.Text = " ";
    }
}
