using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace portofolio2022new
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //【変数宣言】
            //annual_income＝年収　loan_status＝借り入れ状況
            int age, annual_income, loan,
                loan_status1, loan_status2, loan_status3, loan_status4, loan_status5, loan_status6, loan_statusTotal, answer;
            //employee = 会社員　management=経営者　part_arbeit= パートアルバイト　housewife=専業主婦　pension=年金受給者
            String employee = "会社員", management = "経営者", part_arbeit= "パートアルバイト", housewife= "専業主婦", pension= "年金受給者";
            String free_loan = "フリーローン", card_loan = "カードローン", education_loan = "教育ローン", car_loan = "カーローン", target_type_loan = "目的型（ブライダル・リフォーム等）";

            //【入力ない場合0を挿入】
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Text = "0";
                textBox5.Text = "0";
                textBox6.Text = "0";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";

            }
            else if (String.IsNullOrEmpty(textBox5.Text))
            {
               
                textBox5.Text = "0";
                textBox6.Text = "0";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";
            }
            else if (String.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Text = "0";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";
            }
            else if (String.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";
            }
            else if (String.IsNullOrEmpty(textBox8.Text))
            {
                textBox8.Text = "0";
                textBox9.Text = "0";
            }
            else if (String.IsNullOrEmpty(textBox9.Text))
            {
                textBox9.Text = "0";
            }
            else if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("※年齢が入力されておりません※");
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("※職業が選択されていません※");
            }
            else if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("※年収が入力されておりません※");
            }
            else if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("※借入額が入力されておりません※");
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("※ローンが選択されていません※");
            }
            else
            {
                //テキストボックスの文字列をキャストして変数に入れる。
                age = Convert.ToInt32(textBox1.Text);
                annual_income = Convert.ToInt32(textBox2.Text);
                loan = Convert.ToInt32(textBox3.Text);
                loan_status1 = Convert.ToInt32(textBox4.Text);
                loan_status2 = Convert.ToInt32(textBox5.Text);
                loan_status3 = Convert.ToInt32(textBox6.Text);
                loan_status4 = Convert.ToInt32(textBox7.Text);
                loan_status5 = Convert.ToInt32(textBox8.Text);
                loan_status6 = Convert.ToInt32(textBox9.Text);
                
                //ローントータルの計算
                loan_statusTotal = loan_status1 + loan_status2 + loan_status3 + loan_status4 + loan_status5 + loan_status6;

                //テキストに各値を表示
                //label24.Text = Convert.ToString(loan_statusTotal);
                //label25.Text = Convert.ToString(age);
                //label26.Text = Convert.ToString(annual_income);
                //label27.Text = Convert.ToString(loan);

                //コンボボックスで選択した職種をjob_categoryに入れる
                String job_category = comboBox1.SelectedItem.ToString();
              
                //コンボボックスで選択したローンの種類をloan_categoryに入れる
                String loan_category = comboBox2.SelectedItem.ToString();

                //職種判定　会社員・経営者＝年収　パートアルバイト・年金受給者・専業主婦＝50万円
                //（会社員）
                if (job_category.Equals(employee))
                {
                    annual_income = annual_income;
                }
                //（経営者）
                else if (job_category.Equals(management))
                {
                    annual_income = annual_income; 
                }
                //（パート・アルバイト）
                else if (job_category.Equals(part_arbeit))
                {
                    annual_income = 500000;
                }
                //（専業主婦）
                else if (job_category.Equals(housewife))
                {
                    annual_income = 500000;
                }
                //（年金受給者）
                else if (job_category.Equals(pension))
                {
                    annual_income = 500000;
                }

                //【ローンの種類判別と計算】
                //（フリーローン）
                if (loan_category.Equals(free_loan))
                {
                    answer = annual_income / 2 -  loan_statusTotal;
                    String ansewr = Convert.ToString(answer);
                    //MessageBox.Show("借入可能額：" + ansewr);
                    label24.Text = Convert.ToString(answer+"円");
                }
                //（カードローン）
                else if(loan_category.Equals(card_loan))
                {
                    answer = annual_income / 3 -  loan_statusTotal;
                    String ansewr = Convert.ToString(answer);
                    //MessageBox.Show("借入可能額：" + ansewr);
                    label24.Text = Convert.ToString(answer + "円");
                }
                //（教育ローン）仮　※会社員と経営者以外対象外
                else if (loan_category.Equals(education_loan))
                {
                    if (job_category.Equals(part_arbeit))
                    {
                        label24.Text = Convert.ToString("※※借入対象外※※");
                        //MessageBox.Show("借入対象外");
                    }
                    else if (job_category.Equals(housewife))
                    {
                        label24.Text = Convert.ToString("※※借入対象外※※");
                        //MessageBox.Show("借入対象外");
                    }
                    else if (job_category.Equals(pension))
                    {
                        label24.Text = Convert.ToString("※※借入対象外※※");
                        //MessageBox.Show("借入対象外");
                    }
                    else
                    {
                        label24.Text = Convert.ToString("判定外（仮審査判定）");
                        //MessageBox.Show("借入範囲額判定外（当行での判定）");
                        //answer = annual_income / 2 - loan - loan_statusTotal;
                        //String ansewr = Convert.ToString(answer);
                        //MessageBox.Show("借入可能額：" + ansewr);
                    }
                }
                //（カーローン）仮　※会社員と経営者以外対象外
                else if (loan_category.Equals(car_loan))
                {
                    if (job_category.Equals(part_arbeit))
                    {
                        label24.Text = Convert.ToString("※※借入対象外※※");
                        //MessageBox.Show("借入対象外");
                    }
                    else if (job_category.Equals(housewife))
                    {
                        label24.Text = Convert.ToString("※※借入対象外※※");
                        //MessageBox.Show("借入対象外");
                    }
                    else if (job_category.Equals(pension))
                    {
                        label24.Text = Convert.ToString("※※借入対象外※※");
                       // MessageBox.Show("借入対象外");
                    }
                    else
                    {
                        answer = annual_income - loan_statusTotal;
                        String ansewr = Convert.ToString(answer);
                        //MessageBox.Show("借入可能額：" + ansewr);
                        label24.Text = Convert.ToString(answer + "円");
                    }
                }

                //（目的型ローン）仮　※会社員と経営者以外対象外
                else if (loan_category.Equals(target_type_loan))
                {
                    if (job_category.Equals(part_arbeit))
                    {
                        label24.Text = Convert.ToString("※※借入対象外※※");
                        //MessageBox.Show("借入対象外");
                    }
                    else if (job_category.Equals(housewife))
                    {
                        label24.Text = Convert.ToString("※※借入対象外※※");
                       // MessageBox.Show("借入対象外");
                    }
                    else if (job_category.Equals(pension))
                    {
                        label24.Text = Convert.ToString("※※借入対象外※※");
                        //MessageBox.Show("借入対象外");
                    }
                    else
                    {
                        answer = annual_income  - loan_statusTotal;
                        String ansewr = Convert.ToString(answer);
                        //MessageBox.Show("借入可能額：" + ansewr);
                        label24.Text = Convert.ToString(answer + "円");
                    }
                    //label24.Text = Convert.ToString(answer);
                }
                if (age > 81)
                {
                    label24.Text = Convert.ToString("※※年齢超過※※");
                }
                else if(age <= 19)
                {
                    label24.Text = Convert.ToString("※※借入年齢未満※※");
                }



            }

        }
        



        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
