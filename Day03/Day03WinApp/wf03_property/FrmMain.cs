﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class FrmMain : Form
    {
        Random rnd = new Random();

        public FrmMain()
        {
            

            InitializeComponent();
            // 생성자에는 되도록 설정부분을 넣지마세요.
            // Form_Load() 이벤트 핸들러에 작성할 것
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            GbxMain.Text = "컨트롤 학습";
            var fonts = FontFamily.Families.ToList(); // 내 OS 폰트이름 다 가져옴
            foreach (var font in fonts)
            {
                CboFontFamily.Items.Add(font.Name);
            }
            // 글자크기 최소값, 최대값 지정
            NudFontSize.Minimum = 5;
            NudFontSize.Maximum = 40;
            // 텍스트박스 초기화
            TxtResult.Text = "Hello, WinForms!!";

            NudFontSize.Value = 9; // 글자체 크기를 9로 지정
        }

        /// <summary>
        /// 글자스타일, 크기, 글자체를 변경해주는 메소드
        /// </summary>
        private void ChangeFontStyle()
        {
            if (CboFontFamily.SelectedIndex < 0)
            {
                CboFontFamily.SelectedIndex = 257; // 디폴트는 나눔고딕 고정
            }

            FontStyle style = FontStyle.Regular; // 기본
            if (ChkBold.Checked == true)
            {
                style |= FontStyle.Bold; // Bit연산 or
            }
            if (Chkitalic.Checked == true)
            {
                style |= FontStyle.Italic;
            }

            decimal fontSize = NudFontSize.Value;

            TxtResult.Font = new Font((string)CboFontFamily.SelectedItem, (float)fontSize, style);
                        
        }

        void ChangeIndent()
        {
            if (Rdo1.Checked) // 라디오버튼 추가 이벤트
            {
                TxtResult.Text = TxtResult.Text.Trim();
            }
            else if (Rdo2.Checked)
            {
                TxtResult.Text = "    " + TxtResult.Text;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void CboFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void NudFontSize_ValueChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void TxtResult_TextChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PgbDummy.Value = TrbDummy.Value;
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form frm = new Form() 
            {
                Text = "Modal Form",
                Width = 300,
                Height = 200,
                Left = 10,
                Top = 20,
                BackColor = Color.Crimson,
                StartPosition = FormStartPosition.CenterParent
            };
            frm.ShowDialog(); // 자식창 띄우기
        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modaless Form",
                Width = 300,
                Height = 200,
                StartPosition = FormStartPosition.CenterScreen, // Modaless는 CenterParent 안먹힘
                BackColor = Color.GreenYellow,
            };
            frm.Show(); // 모달리스방식으로 자식창 띄움
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(TxtResult.Text); // 기본
            //MessageBox.Show(TxtResult.Text, caption: "메시지창"); // 캡션사용방법
            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.AbortRetryIgnore);
            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error); // 아이콘
            MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2); // 기본포커스 버튼 설정
            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign); // 글자 오른쪽 정렬            
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rnd.Next(50).ToString());
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode != null)
            {
                TrvDummy.SelectedNode.Nodes.Add(rnd.Next(50, 100).ToString());
                TrvDummy.SelectedNode.Expand(); // 트리노드 하위것 펼쳐주기 반대 .Collapse()
                TreeToList();
            }
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear(); // 리스트뷰, 트리뷰 모든 아이템을 제거 초기화메소드
            foreach (TreeNode item in TrvDummy.Nodes)
            {
                TreeToList(item);
            }
        }

        private void TreeToList(TreeNode item)
        {
            LsvDummy.Items.Add(
                new ListViewItem(new []{ item.Text, item.FullPath.ToString() }));

            foreach (TreeNode node in item.Nodes)
            {
                TreeToList(node); // 재귀호출
            }
        }

        private void Rdo1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        private void Rdo2_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            PcbDummy.Image = Bitmap.FromFile("cat.png");
        }

        private void PcbDummy_Click(object sender, EventArgs e)
        {
            if (PcbDummy.SizeMode == PictureBoxSizeMode.Normal) 
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
    }
}
