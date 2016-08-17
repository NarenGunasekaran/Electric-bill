using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Myproject
{
    class op_functions
    {
        public int rand_num()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        public bool validate(String text1,String text2,String text3,String text4,String text5,String text6,String text7)
        {
            if (!string.IsNullOrWhiteSpace(text1))
            {
                Regex r = new Regex("^[a-zA-Z]*$");
                if (r.IsMatch(text1))
                {
                    if (!string.IsNullOrWhiteSpace(text2))
                    {
                        Regex r1 = new Regex("^([0-9]{10})$");
                        if (r1.IsMatch(text2))
                        {
                            if (!string.IsNullOrWhiteSpace(text3))
                            {
                                Regex r2 = new Regex("^([0-9]){6,9}$");
                                if (r2.IsMatch(text3.ToString()))
                                {
                                    if (!string.IsNullOrWhiteSpace(text4))
                                    {
                                        Regex r3 = new Regex("^[a-zA-Z]*$");
                                        if (r3.IsMatch(text4))
                                        {
                                            if (!string.IsNullOrWhiteSpace(text5))
                                            {
                                                Regex r4 = new Regex("^([0-9]){1,7}$");
                                                if (r4.IsMatch(text5.ToString()))
                                                {
                                                    if (!string.IsNullOrWhiteSpace(text6) & !string.IsNullOrWhiteSpace(text7))
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Please fill all the details");
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Invalid square meter value");
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please fill the square meter details");
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid city name !!!");
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Fill the City field");
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid pin code");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Pin code field should be filled !!!");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid contact number");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter the contact number !!!");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid customer name");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please enter the customer name !!!");
                return false;
            }
        }
    }
}
