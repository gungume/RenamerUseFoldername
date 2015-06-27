namespace RenamerUseFoldername
{
    partial class RenamerUseFoldername
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenamerUseFoldername));
            this.listViewFolderlist = new System.Windows.Forms.ListView();
            this.chOriginal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chChange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chChangeFull = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAfterFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chParentPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFileExtension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.numericSerialNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkParentPath = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericSerialNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewFolderlist
            // 
            this.listViewFolderlist.AllowDrop = true;
            this.listViewFolderlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFolderlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOriginal,
            this.chChange,
            this.chChangeFull,
            this.chAfterFile,
            this.chParentPath,
            this.chFullPath,
            this.chFileExtension});
            this.listViewFolderlist.FullRowSelect = true;
            this.listViewFolderlist.GridLines = true;
            this.listViewFolderlist.Location = new System.Drawing.Point(0, 0);
            this.listViewFolderlist.Name = "listViewFolderlist";
            this.listViewFolderlist.Size = new System.Drawing.Size(584, 390);
            this.listViewFolderlist.SmallImageList = this.imageList;
            this.listViewFolderlist.TabIndex = 0;
            this.listViewFolderlist.UseCompatibleStateImageBehavior = false;
            this.listViewFolderlist.View = System.Windows.Forms.View.Details;
            this.listViewFolderlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewFolderlist_DragDrop);
            this.listViewFolderlist.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewFolderlist_DragEnter);
            // 
            // chOriginal
            // 
            this.chOriginal.Text = "원본 파일명";
            this.chOriginal.Width = 300;
            // 
            // chChange
            // 
            this.chChange.Text = "변경 될 파일명";
            this.chChange.Width = 250;
            // 
            // chChangeFull
            // 
            this.chChangeFull.Text = "변경 될 파일명";
            this.chChangeFull.Width = 0;
            // 
            // chAfterFile
            // 
            this.chAfterFile.Text = "chAfterFile";
            this.chAfterFile.Width = 0;
            // 
            // chParentPath
            // 
            this.chParentPath.Text = "chParentPath";
            this.chParentPath.Width = 0;
            // 
            // chFullPath
            // 
            this.chFullPath.Text = "chFullPath";
            this.chFullPath.Width = 0;
            // 
            // chFileExtension
            // 
            this.chFileExtension.Text = "chFileExtension";
            this.chFileExtension.Width = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Folder");
            this.imageList.Images.SetKeyName(1, "File");
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, 396);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(584, 23);
            this.progressBar.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(416, 434);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "초기화";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnChange
            // 
            this.btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChange.Location = new System.Drawing.Point(497, 434);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "변경하기";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // numericSerialNumber
            // 
            this.numericSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericSerialNumber.Location = new System.Drawing.Point(219, 435);
            this.numericSerialNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericSerialNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSerialNumber.Name = "numericSerialNumber";
            this.numericSerialNumber.Size = new System.Drawing.Size(37, 21);
            this.numericSerialNumber.TabIndex = 4;
            this.numericSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericSerialNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSerialNumber.ValueChanged += new System.EventHandler(this.numericSerialNumber_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "일련번호 자릿수";
            // 
            // checkParentPath
            // 
            this.checkParentPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkParentPath.AutoSize = true;
            this.checkParentPath.Location = new System.Drawing.Point(283, 438);
            this.checkParentPath.Name = "checkParentPath";
            this.checkParentPath.Size = new System.Drawing.Size(104, 16);
            this.checkParentPath.TabIndex = 6;
            this.checkParentPath.Text = "상위 경로 포함";
            this.checkParentPath.UseVisualStyleBackColor = true;
            this.checkParentPath.CheckedChanged += new System.EventHandler(this.checkParentPath_CheckedChanged);
            // 
            // RenamerUseFoldername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.checkParentPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericSerialNumber);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.listViewFolderlist);
            this.Name = "RenamerUseFoldername";
            this.Text = "폴더명으로 파일명 일괄변경 (Gungume.com)";
            ((System.ComponentModel.ISupportInitialize)(this.numericSerialNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewFolderlist;
        private System.Windows.Forms.ColumnHeader chOriginal;
        private System.Windows.Forms.ColumnHeader chChange;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.NumericUpDown numericSerialNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkParentPath;
        private System.Windows.Forms.ColumnHeader chChangeFull;
        private System.Windows.Forms.ColumnHeader chAfterFile;
        private System.Windows.Forms.ColumnHeader chParentPath;
        private System.Windows.Forms.ColumnHeader chFullPath;
        private System.Windows.Forms.ColumnHeader chFileExtension;
    }
}

