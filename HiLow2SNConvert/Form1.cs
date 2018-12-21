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

    int step = 16384;
    int startHi = 16;
    int endHi = 16383;
    int startLow = 16;
    int endLow = 16383;
    int inputHi;
    int inputLow;
    string pluralSerialShow;
    List<int> SerialList = new List<int>();
    ushort HdlcHi = 0;
    ushort HdlcLow = 1;
    public int soughtSerial;
    FixedValues fixedValues = new FixedValues();

    /* 
     * textBox1 - hi, textBox2 - low, textBox3 - SN, textBox5 - hexHi, textBox6 - hexLow
     * textBox4 - hdlcHi, textBox7 - hdlcLow;
     * radioButton1 - hiLow, radioButton2 - SN, radioButton3 - hex, radioButton4 - hdlc.
     * int endSerNumb = 2147483647;
     * Расчёт серийника из Hi Low работает в пределах от 0 до 1074003967 (8223.16383), если закоментировать 193-ю строку
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
    // метод расчёта всех возможных серийников из Hi Low
    public int SpecialCountSerialFromHiLow(int primaryKeyDict, int firstValueDict)
    {
      return soughtSerial = firstValueDict + ((inputHi - primaryKeyDict) * step + (inputLow - startLow));
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

          if (inputHi >= 8208 && inputHi <= 8223 && inputLow >= 16 && inputLow <= 16383)
          {
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_20, fixedValues.firstValueDict_20);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_22, fixedValues.firstValueDict_22);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_24, fixedValues.firstValueDict_24);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_26, fixedValues.firstValueDict_26);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_28, fixedValues.firstValueDict_28);
            SerialList.Add(soughtSerial);
          }

          if (inputHi >= 16 && inputHi <= 16383 && inputLow >= 16 && inputLow <= 16383)
          {
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_21, fixedValues.firstValueDict_21);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_23, fixedValues.firstValueDict_23);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_25, fixedValues.firstValueDict_25);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_27, fixedValues.firstValueDict_27);
            SerialList.Add(soughtSerial);
          }

          if (inputHi >= 4096 && inputHi <= 8191 && inputLow >= 16 && inputLow <= 31)
          {
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_3, fixedValues.firstValueDict_3);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_8, fixedValues.firstValueDict_8);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_13, fixedValues.firstValueDict_13);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_18, fixedValues.firstValueDict_18);
            SerialList.Add(soughtSerial);
          }

          if (inputHi >= 4112 && inputHi <= 8191 && inputLow >= 16 && inputLow <= 31)
          {
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_2, fixedValues.firstValueDict_2);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_7, fixedValues.firstValueDict_7);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_12, fixedValues.firstValueDict_12);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_17, fixedValues.firstValueDict_17);
            SerialList.Add(soughtSerial);
          }

          if (inputHi >= 12304 && inputHi <= 12319 && inputLow >= 16 && inputLow <= 31)
          {
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_1, fixedValues.firstValueDict_1);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_6, fixedValues.firstValueDict_6);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_11, fixedValues.firstValueDict_11);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_16, fixedValues.firstValueDict_16);
            SerialList.Add(soughtSerial);
          }

          if (inputHi >= 12288 && inputHi <= 16383 && inputLow >= 16 && inputLow <= 31)
          {
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_4, fixedValues.firstValueDict_4);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_5, fixedValues.firstValueDict_5);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_9, fixedValues.firstValueDict_9);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_10, fixedValues.firstValueDict_10);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_14, fixedValues.firstValueDict_14);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_15, fixedValues.firstValueDict_15);
            SerialList.Add(soughtSerial);
            SpecialCountSerialFromHiLow(fixedValues.primaryKeyDict_19, fixedValues.firstValueDict_19);
            SerialList.Add(soughtSerial);
          }

          SerialList.Sort();

          if (serialUnder8tsmi.Checked)
          {
            SerialList.RemoveAll(item => item > 99999999);
          }
          else
          {
            SerialList.RemoveAll(item => item > 1074003967);
          }

          StringBuilder builder = new StringBuilder();

          foreach (int item in SerialList)
          {
            builder.Append(item).Append("; ");
          }

          pluralSerialShow = builder.ToString();

          if (SerialList.Count > 1 && serialUnder8tsmi.Checked)
          {
            MessageBox.Show(pluralSerialShow, "Список возможных серийных номеров до 99 999 999:");
            SerialList.Clear();
            textBox3.Clear();
          }
          if (SerialList.Count > 1 && serialUnder10tsmi.Checked)
          {
            MessageBox.Show(pluralSerialShow, "Список возможных серийных номеров до 1 074 003 967:");
            SerialList.Clear();
            textBox3.Clear();
          }
          else
          {
            pluralSerialShow = pluralSerialShow.Replace(";", "");
            textBox3.Text = pluralSerialShow.ToString();
            SerialList.Clear();
          }

          if (inputHi > endHi)
          {
            MessageBox.Show("Введите число до 16383!");
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
        MessageBox.Show("Введите число до 16383!");
        AllTextBoxClear();
      }

      // алгоритм расчёта серийных номеров от 262160
      //      textBox3.Text = (step * (inputHi - startHi) + startSerNumb + (inputLow - startLow)).ToString();
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
      ulong HI = 0;
      ulong LOW = 0;

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

      if ((String.IsNullOrWhiteSpace(Convert.ToString(textBox3.Text))))
      {
        MessageBox.Show("Введите значения для выбранных полей!");
        textBox3.Text = "0";
      }
      ulong short_serial = UInt64.Parse(textBox3.Text);

      bool isNewAlgorithm = true;
      if ((short_serial & 0x1000) == 0)
      {
        if (short_serial == 0x2000)
        {
          isNewAlgorithm = false;
        }
      }

      // доработанный алгоритм расчёта определённых диапазонов Hi Low из серийников

      if (short_serial == 0x2000)
      {
        isNewAlgorithm = false;
      }

      if (!isNewAlgorithm)
      {
        HI = (short_serial & 0x3FFF) < 16 ? short_serial = (1 << 13) : short_serial & 0x3FFF;
        LOW = ((short_serial >> 14) & 0x3FFF) < 16 ? (1 << 13) : (short_serial >> 14) & 0x3FFF;
      }
      else
      {
        HI = 0;
        LOW = short_serial & 0x3FFF;

        if ((short_serial & 0x3FFF) < 16)
        {
          LOW += 16;
          HI |= (1 << 12);
        }
        else
        {
          LOW = short_serial & 0x3FFF;
        }

        if (((short_serial >> 14) & 0x3FFF) < 16)
        {
          HI += ((short_serial >> 14) & 0x3FFF) + 16;
          HI |= (1 << 13);
        }
        else
        {
          HI |= (short_serial >> 14) & 0x3FFF;
        }
      }

      textBox1.Text = HI.ToString();
      textBox2.Text = LOW.ToString();

      /*try
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
      catch { }*/

      textBox5.Text = Convert.ToString((int)HI, 16);
      textBox6.Text = Convert.ToString((int)LOW, 16);
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

    private void serialUnder8tsmi_Click(object sender, EventArgs e)
    {
      if (serialUnder8tsmi.Checked)
      { serialUnder10tsmi.Checked = false; }
      if (serialUnder10tsmi.Checked == false)
      { serialUnder8tsmi.Checked = true; }
    }

    private void serialUnder10tsmi_Click(object sender, EventArgs e)
    {
      if (serialUnder10tsmi.Checked)
      { serialUnder8tsmi.Checked = false; }
      if (serialUnder8tsmi.Checked == false)
      { serialUnder10tsmi.Checked = true; }
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
