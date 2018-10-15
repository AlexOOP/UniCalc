using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace HiLow2SNConvert
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    int startSerNumb = 262160;
    int step = 16384;
    int startHi = 16;
    int endHi = 550371327;
    int startLow = 16;
    int endLow = 16383;
    int inputHi;
    int inputLow;
    string pluralSerialShow;
    List<int> SerialList = new List<int>();
    ushort HdlcHi = 0;
    ushort HdlcLow = 1;

    /* 
     * textBox1 - hi, textBox2 - low, textBox3 - SN, textBox5 - hexHi, textBox6 - hexLow
     * textBox4 - hdlcHi, textBox7 - hdlcLow;
     * radioButton1 - hiLow, radioButton2 - SN, radioButton3 - hex, radioButton4 - hdlc.
     * int endSerNumb = 2147483647;
    */

    // очистка всех текстбоксов
    private void AllTextBoxClear()
    {
      textBox1.Clear();
      textBox2.Clear();
      textBox3.Clear();
      textBox5.Clear();
      textBox6.Clear();
      textBox4.Clear();
      textBox7.Clear();
    }

    // алгоритм расчёта HDLC из HEX
    public int Hdlc_HiLow(int _a, int _l)
    {
      int result = (((((_a) << 1) & 0x00FE) | (_l)) | (((_a) << 2) & 0xFE00));
      return result;
    }

    // метод расчёта HDLC из HEX 
    public void Hex2Hdlc()
    {
      int inHi = Convert.ToInt32(textBox5.Text, 16);
      int inLow = Convert.ToInt32(textBox6.Text, 16);

      int inHiRes = Hdlc_HiLow(inHi, HdlcHi);
      int inLowRes = Hdlc_HiLow(inLow, HdlcLow);

      textBox4.Text = Convert.ToString(inHiRes, 16);
      textBox7.Text = Convert.ToString(inLowRes, 16);
    }

    // алгоритм расчёта HEX из HDLC
    public int HiLow_Hdlc(int _a)
    {
      int result = ((((_a) >> 1) & 0x007F) | (((_a) >> 2) & 0x3F80));
      return result;
    }

    // метод расчёта HEX из HDLC
    public void Hdlc2Hex()
    {
      if ((String.IsNullOrWhiteSpace(Convert.ToString(textBox4.Text)) || (String.IsNullOrWhiteSpace(Convert.ToString(textBox7.Text)))))
      {
        MessageBox.Show("Введите значения для выбранных полей!");
        textBox4.Text = Convert.ToString(0);
        textBox7.Text = Convert.ToString(0);
      }

      int inHi = Convert.ToInt32(textBox4.Text, 16);
      int inLow = Convert.ToInt32(textBox7.Text, 16);

      int inHiRes = HiLow_Hdlc(inHi);
      int inLowRes = HiLow_Hdlc(inLow);

      textBox5.Text = Convert.ToString(inHiRes, 16);
      textBox6.Text = Convert.ToString(inLowRes, 16);
    }

    // алгоритм расчёта из HI LOW -> Serial Number
    private void HiLow2SN()
    {
      try
      {
        inputHi = Math.Abs(Convert.ToInt32(textBox1.Text));

        try
        {
          inputLow = Math.Abs(Convert.ToInt32(textBox2.Text));

          // алгоритм расчёта серийных номеров до 262143 (где hi 8192)
          if (inputHi == 8192)
          {
            textBox3.Multiline = true;
            for (int j = 0; j < 16; j++)
            {
              SerialList.Add(inputLow);
              inputLow = inputLow + step;
            }

            StringBuilder builder = new StringBuilder();

            foreach (int item in SerialList)
            {
              builder.Append(item).Append("; ");
            }

            pluralSerialShow = builder.ToString();
            MessageBox.Show(pluralSerialShow, "Список возможных серийных номеров:");
          }

          if (inputHi > endHi)
          {
            MessageBox.Show("Введите число до 550371327!");
            AllTextBoxClear();
          }

          if (inputLow > endLow)
          {
            MessageBox.Show("Введите Low до 16383!");
            AllTextBoxClear();
          }
        }
        catch (FormatException)
        {
          MessageBox.Show("Введите целое число для Low!");
          AllTextBoxClear();
        }
      }
      catch (FormatException)
      {
        MessageBox.Show("Введите целое число для Hi!");
        AllTextBoxClear();
      }
      catch (OverflowException)
      {
        MessageBox.Show("Введите число до 550371327!");
        AllTextBoxClear();
      }

      // алгоритм расчёта серийных номеров от 262160
      textBox3.Text = (step * (inputHi - startHi) + startSerNumb + (inputLow - startLow)).ToString();
      textBox5.Text = Convert.ToString(inputHi, 16);
      textBox6.Text = Convert.ToString(inputLow, 16);
      Hex2Hdlc();
    }

    // алгоритм расчёта HEX -> DEC
    private int HexToDec(string hex)
    {
      int dec = 0;
      for (int i = 0, j = hex.Length - 1; i < hex.Length; i++, j--)
      {
        if (hex[i] == 'A' || hex[i] == 'a') { dec += 10 * (int)Math.Pow(16, j); }
        else if (hex[i] == 'B' || hex[i] == 'b') { dec += 11 * (int)Math.Pow(16, j); }
        else if (hex[i] == 'C' || hex[i] == 'c') { dec += 12 * (int)Math.Pow(16, j); }
        else if (hex[i] == 'D' || hex[i] == 'd') { dec += 13 * (int)Math.Pow(16, j); }
        else if (hex[i] == 'E' || hex[i] == 'e') { dec += 14 * (int)Math.Pow(16, j); }
        else if (hex[i] == 'F' || hex[i] == 'f') { dec += 15 * (int)Math.Pow(16, j); }
        else { dec += (hex[i] - '0') * (int)Math.Pow(16, j); }
      }
      return dec;
    }

    // метод расчёта HEX -> DEC
    public void Hex2DecShow()
    {
      string hiHex = Convert.ToString(textBox5.Text);
      string lowHex = Convert.ToString(textBox6.Text);

      textBox1.Text = Convert.ToString(HexToDec(hiHex));
      textBox2.Text = Convert.ToString(HexToDec(lowHex));
    }

    // алгоритм расчёта hi low из серийного номера
    private int Serial2Hi(ulong serial)
    {
      ushort resultHi = (ushort)((serial >> 14) & 0x3FFF);
      return resultHi < 16 ? 1 << 13 : resultHi;
    }

    private int Serial2Lo(ulong serial)
    {
      ushort resultLow = (ushort)(serial & 0x3FFF);
      return resultLow < 16 ? 1 << 13 : resultLow;
    }

    private void Serial2HiLow()
    {
      int HI = 0;
      int LOW = 0;

      try
      {
        try
        {
          Convert.ToInt32(textBox3.Text);
        }
        catch (OverflowException)
        {
          MessageBox.Show("Введите число до 2147483647!");
          AllTextBoxClear();
        }
      }
      catch (FormatException)
      {
        MessageBox.Show("Введите целое число!");
        AllTextBoxClear();
      }

      try
      {
        HI = Math.Abs(Serial2Hi(UInt64.Parse(textBox3.Text)));
        textBox1.Text = HI.ToString();
      }
      catch { }

      try
      {
        LOW = Math.Abs(Serial2Lo(UInt64.Parse(textBox3.Text)));
        textBox2.Text = LOW.ToString();
      }
      catch { }

      textBox5.Text = Convert.ToString(HI, 16);
      textBox6.Text = Convert.ToString(LOW, 16);
      Hex2Hdlc();
    }

    // события по нажатию кнопки Расчитать
    private void button1_Click(object sender, EventArgs e)
    {
      // событие, по которому нужно расчитывать Hi Low/HEX/HDLC из серийника
      if (radioButton2.Checked)
      {
        Serial2HiLow();
      }

      // событие, по которому нужно расчитывать серийник/HEX/HDLC из Hi Low 
      if (radioButton1.Checked)
      {
        HiLow2SN();
      }

      // событие, по которому нужно расчитывать серийник/Hi Low/HDLC из HEX
      if (radioButton3.Checked)
      {
        Hex2DecShow();
        HiLow2SN();
        Hex2Hdlc();
      }

      // событие, по которому нужно расчитывать серийник/Hi Low/HEX из HDLC
      if (radioButton4.Checked)
      {
        Hdlc2Hex();
        Hex2DecShow();
        HiLow2SN();
      }
    }

    // Правила для радиокнопок
    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      RadioButton radioButton = (RadioButton)sender;
      if (radioButton.Checked)
      {
        textBox1.Focus();
        TextBoxFocused();
      }
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
      RadioButton radioButton = (RadioButton)sender;
      if (radioButton.Checked)
      {
        textBox3.Focus();
        TextBoxFocused();
      }
    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
      RadioButton radioButton = (RadioButton)sender;
      if (radioButton.Checked)
      {
        textBox5.Focus();
        TextBoxFocused();
      }
    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {
      RadioButton radioButton = (RadioButton)sender;
      if (radioButton.Checked)
      {
        textBox4.Focus();
        TextBoxFocused();
      }
    }

    // Правила для текстбоксов
    private void TextBoxFocused()
    {
      if (textBox1.Focused && radioButton1.Checked)
      {
        textBox1.ReadOnly = false;
        textBox2.ReadOnly = false;
        textBox3.ReadOnly = true;
        textBox5.ReadOnly = true;
        textBox6.ReadOnly = true;
        textBox4.ReadOnly = true;
        textBox7.ReadOnly = true;
        AllTextBoxClear();
      }

      else if (textBox4.Focused && radioButton4.Checked)
      {
        textBox1.ReadOnly = true;
        textBox2.ReadOnly = true;
        textBox3.ReadOnly = true;
        textBox4.ReadOnly = false;
        textBox7.ReadOnly = false;
        textBox5.ReadOnly = true;
        textBox6.ReadOnly = true;
        AllTextBoxClear();
      }

      else if (textBox3.Focused && radioButton2.Checked)
      {
        textBox1.ReadOnly = true;
        textBox2.ReadOnly = true;
        textBox3.ReadOnly = false;
        textBox5.ReadOnly = true;
        textBox6.ReadOnly = true;
        textBox4.ReadOnly = true;
        textBox7.ReadOnly = true;
        AllTextBoxClear();
      }

      else if (textBox5.Focused && radioButton3.Checked)
      {
        textBox1.ReadOnly = true;
        textBox2.ReadOnly = true;
        textBox3.ReadOnly = true;
        textBox5.ReadOnly = false;
        textBox6.ReadOnly = false;
        textBox4.ReadOnly = true;
        textBox7.ReadOnly = true;
        AllTextBoxClear();
      }
    }
  }
}
