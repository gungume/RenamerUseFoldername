using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RenamerUseFoldername
{
    public partial class RenamerUseFoldername : Form
    {
        #region 전역변수
        /// <summary>드래그&드롭된 폴더 목록</summary>
        private List<string> strFolderList = new List<string>();

        /// <summary>일련번호에 쓰일 String.Format</summary>
        private string strSerialNumber = string.Empty;

        /// <summary>상위 경로 포함에 쓰일 경로</summary>
        private string fullParentPath = string.Empty;

        /// <summary>현재 추가한 파일 갯수</summary>
        private int currentFileCount = 0;

        /// <summary>현재까지 추가된 파일 갯수</summary>
        private int totalFileCount = 0;

        /// <summary>'변경 될 파일명' 컬럼 길이</summary>
        private int columnWidth = 250; 
        #endregion

        public RenamerUseFoldername()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 폴더 & 파일에 대해서만 드래그&드롭 처리.
        /// </summary>
        private void listViewFolderlist_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 드래그&드롭된 폴더 & 파일 처리.
        /// </summary>
        private void listViewFolderlist_DragDrop(object sender, DragEventArgs e)
        {
            //int count = ((string[])e.Data.GetData(DataFormats.FileDrop)).GetLength(0);
            strFolderList.Clear();
            currentFileCount = 0;

            // currentFileCount 필드에 현재 추가된 파일의 갯수 구함. (타입에 따라 추가 안하는 파일 존재하므로 오차 존재)
            // strFolderList 객체에 드래그&드롭된 폴더 목록 저장. (드래그&드롭시 파일은 제외)
            foreach (string folderName in ((string[])e.Data.GetData(DataFormats.FileDrop)))
            {
                try
                {
                    currentFileCount += new DirectoryInfo(folderName).GetFiles("*", SearchOption.AllDirectories).Length;
                    strFolderList.Add(folderName);
                }
                catch (IOException)
                {
                    continue;
                }
            }

            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = currentFileCount;
            progressBar.Step = 1;

            // "{0}{1:D}{2}"
            strSerialNumber = "{0}{1:D" + numericSerialNumber.Value.ToString() + "}{2}";

            // 드래그&드롭된 폴더 목록을 이용 하위 폴더 & 파일리스트 작성
            foreach (string folderName in strFolderList)
            {
                fullParentPath = string.Empty;

                if (checkParentPath.Checked)
                {
                    listViewFolderlist.Columns[1].Width = 0;
                    listViewFolderlist.Columns[2].Width = columnWidth;
                }
                else
                {
                    listViewFolderlist.Columns[2].Width = 0;
                    listViewFolderlist.Columns[1].Width = columnWidth;
                }

                SetFileList(folderName);
            }

            progressBar.Value = currentFileCount;
        }

        /// <summary>
        /// 드래그&드롭된 폴더 목록을 이용 하위 폴더 & 파일리스트 작성,
        /// 하위 항목에 대해 직접 재귀호출.
        /// </summary>
        /// <param name="folderName">현재 폴더경로</param>
        private void SetFileList(string folderName)
        {
            DirectoryInfo di = new DirectoryInfo(folderName);

            fullParentPath += di.Name + "_";

            // 폴더 추가.
            listViewFolderlist.Items.Add(di.FullName, 0);

            // 일반파일, 읽기전용 파일 추가, 숨김파일 제외.
            int cnt = 1;
            foreach (FileInfo file in di.GetFiles())
            {
                if ( File.GetAttributes(file.FullName).ToString().StartsWith("Archive") == true  ||
                     File.GetAttributes(file.FullName).ToString().StartsWith("ReadOnly") == true ||
                     File.GetAttributes(file.FullName).ToString().StartsWith("Hidden") != true)
                {
                    ListViewItem itemFile = new ListViewItem(new string[] { 
                            file.Name, 
                            string.Format(strSerialNumber, di.Name +"_", cnt, file.Extension),      // File
                            string.Format(strSerialNumber, fullParentPath, cnt, file.Extension),    // FullPath
                            file.Name,
                            di.Name +"_",
                            fullParentPath,
                            file.Extension
                        });
                    cnt++;

                    listViewFolderlist.Items.Add(itemFile);

                    progressBar.PerformStep();
                    totalFileCount++;
                }
            }

            // 하위 폴더가 존재하는 경우 재귀호출.
            foreach (DirectoryInfo subDi in di.GetDirectories())
            {
                SetFileList(subDi.FullName);

                try
                {
                    fullParentPath = fullParentPath.Remove(fullParentPath.LastIndexOf(subDi.Name + "_"));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// 프로그램 초기화.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            listViewFolderlist.Items.Clear();
            progressBar.Value = 0;
            currentFileCount = 0;
            totalFileCount = 0;

            numericSerialNumber.Value = 1;
            checkParentPath.Checked = false;

        }

        /// <summary>
        /// 파일명 변경.
        /// </summary>
        private void btnChange_Click(object sender, EventArgs e)
        {
            string strRenamePath = string.Empty;

            foreach (ListViewItem item in listViewFolderlist.Items)
            {
                // ListView 항목 중 File에 대해서만 처리.
                if (item.SubItems.Count <= 1)
                {
                    strRenamePath = item.Text;
                }
                else if (item.SubItems.Count > 1)
                {
                    try
                    {
                        strRenamePath += "\\";
                        if (checkParentPath.Checked)
                        {
                            File.Move(strRenamePath + item.SubItems[3].Text, strRenamePath + item.SubItems[2].Text);
                            item.SubItems[3].Text = item.SubItems[2].Text;
                        }
                        else
                        {
                            File.Move(strRenamePath + item.SubItems[3].Text, strRenamePath + item.SubItems[1].Text);
                            item.SubItems[3].Text = item.SubItems[1].Text;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 상위 경로 포함 파일명 생성
        /// </summary>
        private void checkParentPath_CheckedChanged(object sender, EventArgs e)
        {
            columnWidth = listViewFolderlist.Columns[1].Width > listViewFolderlist.Columns[2].Width ? listViewFolderlist.Columns[1].Width : listViewFolderlist.Columns[2].Width;

            if (checkParentPath.Checked)
            {
                listViewFolderlist.Columns[1].Width = 0;
                listViewFolderlist.Columns[2].Width = columnWidth;
            }
            else
            {
                listViewFolderlist.Columns[2].Width = 0;
                listViewFolderlist.Columns[1].Width = columnWidth;
            }
        }

        /// <summary>
        /// 일련번호 자릿수 변경.
        /// </summary>
        private void numericSerialNumber_ValueChanged(object sender, EventArgs e)
        {
            int cnt=1;
            strSerialNumber = "{0}{1:D" + numericSerialNumber.Value.ToString() + "}{2}";

            foreach (ListViewItem item in listViewFolderlist.Items)
            {
                if (item.SubItems.Count <= 1)
                {
                    cnt = 1;
                }
                else if (item.SubItems.Count > 1)
                {
                    item.SubItems[1].Text = string.Format(strSerialNumber, item.SubItems[4].Text, cnt, item.SubItems[6].Text);   // File
                    item.SubItems[2].Text = string.Format(strSerialNumber, item.SubItems[5].Text, cnt, item.SubItems[6].Text);   // FullPath
                    cnt++;
                }
            }
        }
    }
}
