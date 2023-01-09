namespace colortv_test_automation
{
    partial class Form_Pass_Mes
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

   

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Pass_Mes));
            this.btn_start = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_ver = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mES测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.生产统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tb_type = new System.Windows.Forms.TextBox();
            this.tb_sn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.com_CA410 = new System.IO.Ports.SerialPort(this.components);
            this.timer_readdata = new System.Windows.Forms.Timer(this.components);
            this.lb_title = new System.Windows.Forms.Label();
            this.timer_start = new System.Windows.Forms.Timer(this.components);
            this.com_TV = new System.IO.Ports.SerialPort(this.components);
            this.com_IR = new System.IO.Ports.SerialPort(this.components);
            this.tb_SOFT_VER = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.tb_mesall = new System.Windows.Forms.TextBox();
            this.lb_workstationid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_plc_info = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ShakeHand_OK_Code = new System.Windows.Forms.TextBox();
            this.tb_memo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PLC_IP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.cb_ir = new System.Windows.Forms.CheckBox();
            this.btn_ir_send = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_start.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_start.Location = new System.Drawing.Point(1074, 178);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(127, 41);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "启动过站";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lb_ver,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 786);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(284, 17);
            this.toolStripStatusLabel1.Text = "四川长虹电器股份有限公司　可靠性与检测技术中心";
            // 
            // lb_ver
            // 
            this.lb_ver.Name = "lb_ver";
            this.lb_ver.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(284, 17);
            this.toolStripStatusLabel2.Text = "                                                                     ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mES测试ToolStripMenuItem,
            this.数据库ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.串口设置ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 25);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mES测试ToolStripMenuItem
            // 
            this.mES测试ToolStripMenuItem.Name = "mES测试ToolStripMenuItem";
            this.mES测试ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.mES测试ToolStripMenuItem.Text = "设置";
            this.mES测试ToolStripMenuItem.Click += new System.EventHandler(this.mES测试ToolStripMenuItem_Click);
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.数据库ToolStripMenuItem.Text = "帮助";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(12, 21);
            // 
            // 串口设置ToolStripMenuItem
            // 
            this.串口设置ToolStripMenuItem.Name = "串口设置ToolStripMenuItem";
            this.串口设置ToolStripMenuItem.Size = new System.Drawing.Size(12, 21);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(76, 21);
            this.toolStripMenuItem1.Text = "20200724";
            // 
            // 生产统计ToolStripMenuItem
            // 
            this.生产统计ToolStripMenuItem.Name = "生产统计ToolStripMenuItem";
            this.生产统计ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 测试数据ToolStripMenuItem
            // 
            this.测试数据ToolStripMenuItem.Name = "测试数据ToolStripMenuItem";
            this.测试数据ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 设置ToolStripMenuItem1
            // 
            this.设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
            this.设置ToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Logo.png");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(226, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 27;
            this.label4.Text = "机型：";
            // 
            // tb_type
            // 
            this.tb_type.Enabled = false;
            this.tb_type.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_type.Location = new System.Drawing.Point(282, 176);
            this.tb_type.Name = "tb_type";
            this.tb_type.Size = new System.Drawing.Size(243, 50);
            this.tb_type.TabIndex = 28;
            // 
            // tb_sn
            // 
            this.tb_sn.Enabled = false;
            this.tb_sn.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_sn.Location = new System.Drawing.Point(591, 176);
            this.tb_sn.Name = "tb_sn";
            this.tb_sn.Size = new System.Drawing.Size(433, 50);
            this.tb_sn.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(545, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 23);
            this.label7.TabIndex = 29;
            this.label7.Text = "SN：";
            // 
            // lb_title
            // 
            this.lb_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_title.Font = new System.Drawing.Font("微软雅黑", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_title.ForeColor = System.Drawing.Color.Blue;
            this.lb_title.Location = new System.Drawing.Point(50, 45);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(1177, 128);
            this.lb_title.TabIndex = 50;
            this.lb_title.Text = "本机型不调白平衡\r\n";
            this.lb_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // com_IR
            // 
            this.com_IR.BaudRate = 115200;
            this.com_IR.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.com_IR_DataReceived);
            // 
            // tb_SOFT_VER
            // 
            this.tb_SOFT_VER.Enabled = false;
            this.tb_SOFT_VER.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SOFT_VER.Location = new System.Drawing.Point(159, 187);
            this.tb_SOFT_VER.Name = "tb_SOFT_VER";
            this.tb_SOFT_VER.Size = new System.Drawing.Size(61, 31);
            this.tb_SOFT_VER.TabIndex = 80;
            this.tb_SOFT_VER.Text = "V1.2";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.Location = new System.Drawing.Point(53, 192);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(115, 21);
            this.label54.TabIndex = 79;
            this.label54.Text = "软件版本：";
            // 
            // tb_mesall
            // 
            this.tb_mesall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_mesall.Location = new System.Drawing.Point(446, 361);
            this.tb_mesall.Multiline = true;
            this.tb_mesall.Name = "tb_mesall";
            this.tb_mesall.Size = new System.Drawing.Size(740, 413);
            this.tb_mesall.TabIndex = 81;
            // 
            // lb_workstationid
            // 
            this.lb_workstationid.Enabled = false;
            this.lb_workstationid.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_workstationid.Location = new System.Drawing.Point(149, 239);
            this.lb_workstationid.Name = "lb_workstationid";
            this.lb_workstationid.Size = new System.Drawing.Size(153, 31);
            this.lb_workstationid.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(53, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 83;
            this.label1.Text = "工作站：";
            // 
            // lb_plc_info
            // 
            this.lb_plc_info.AutoSize = true;
            this.lb_plc_info.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_plc_info.Location = new System.Drawing.Point(763, 278);
            this.lb_plc_info.Name = "lb_plc_info";
            this.lb_plc_info.Size = new System.Drawing.Size(21, 21);
            this.lb_plc_info.TabIndex = 84;
            this.lb_plc_info.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(575, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 21);
            this.label2.TabIndex = 83;
            this.label2.Text = "PLC 5000当前值：";
            // 
            // ShakeHand_OK_Code
            // 
            this.ShakeHand_OK_Code.Enabled = false;
            this.ShakeHand_OK_Code.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShakeHand_OK_Code.Location = new System.Drawing.Point(763, 237);
            this.ShakeHand_OK_Code.Name = "ShakeHand_OK_Code";
            this.ShakeHand_OK_Code.Size = new System.Drawing.Size(47, 31);
            this.ShakeHand_OK_Code.TabIndex = 87;
            // 
            // tb_memo
            // 
            this.tb_memo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_memo.Location = new System.Drawing.Point(57, 301);
            this.tb_memo.Multiline = true;
            this.tb_memo.Name = "tb_memo";
            this.tb_memo.Size = new System.Drawing.Size(363, 473);
            this.tb_memo.TabIndex = 88;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 89;
            this.label5.Text = "提交信息：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 90;
            this.label6.Text = "MES回复：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(587, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 21);
            this.label8.TabIndex = 91;
            this.label8.Text = "过站握手：5000=";
            // 
            // PLC_IP
            // 
            this.PLC_IP.Enabled = false;
            this.PLC_IP.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PLC_IP.Location = new System.Drawing.Point(401, 239);
            this.PLC_IP.Name = "PLC_IP";
            this.PLC_IP.Size = new System.Drawing.Size(180, 31);
            this.PLC_IP.TabIndex = 94;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(308, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 21);
            this.label3.TabIndex = 95;
            this.label3.Text = "PLC IP：";
            // 
            // lb_status
            // 
            this.lb_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_status.AutoSize = true;
            this.lb_status.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_status.Location = new System.Drawing.Point(1037, 237);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(190, 35);
            this.lb_status.TabIndex = 96;
            this.lb_status.Text = "过站未启动";
            // 
            // cb_ir
            // 
            this.cb_ir.AutoSize = true;
            this.cb_ir.Checked = true;
            this.cb_ir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ir.Location = new System.Drawing.Point(589, 325);
            this.cb_ir.Name = "cb_ir";
            this.cb_ir.Size = new System.Drawing.Size(90, 16);
            this.cb_ir.TabIndex = 97;
            this.cb_ir.Text = "发送红外F10";
            this.cb_ir.UseVisualStyleBackColor = true;
            this.cb_ir.CheckedChanged += new System.EventHandler(this.cb_ir_CheckedChanged);
            // 
            // btn_ir_send
            // 
            this.btn_ir_send.Location = new System.Drawing.Point(712, 321);
            this.btn_ir_send.Name = "btn_ir_send";
            this.btn_ir_send.Size = new System.Drawing.Size(96, 23);
            this.btn_ir_send.TabIndex = 98;
            this.btn_ir_send.Text = "手动发送红外";
            this.btn_ir_send.UseVisualStyleBackColor = true;
            this.btn_ir_send.Click += new System.EventHandler(this.btn_ir_send_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(841, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(335, 48);
            this.label9.TabIndex = 99;
            this.label9.Text = "需要红外发射器预先学习4\r\n发射回复的最后两位：\r\n03 发送成功 \r\n04 发送失败 (通常是没有学习过一次，存储器里面还是空白) ";
            this.label9.Visible = false;
            // 
            // Form_Pass_Mes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 808);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_ir_send);
            this.Controls.Add(this.cb_ir);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.PLC_IP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_memo);
            this.Controls.Add(this.ShakeHand_OK_Code);
            this.Controls.Add(this.lb_plc_info);
            this.Controls.Add(this.lb_workstationid);
            this.Controls.Add(this.tb_mesall);
            this.Controls.Add(this.tb_SOFT_VER);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.tb_sn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_type);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Pass_Mes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "线体MES过站软件";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lb_ver;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mES测试ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_type;
        private System.Windows.Forms.TextBox tb_sn;
        private System.Windows.Forms.Label label7;
        private System.IO.Ports.SerialPort com_CA410;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.Timer timer_readdata;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.Timer timer_start;
        private System.IO.Ports.SerialPort com_TV;
        private System.IO.Ports.SerialPort com_IR;
        private System.Windows.Forms.ToolStripMenuItem 串口设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem1;
        private System.Windows.Forms.TextBox tb_SOFT_VER;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem 生产统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试数据ToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_mesall;
        private System.Windows.Forms.TextBox lb_workstationid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_plc_info;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ShakeHand_OK_Code;
        private System.Windows.Forms.TextBox tb_memo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PLC_IP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.CheckBox cb_ir;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button btn_ir_send;
        private System.Windows.Forms.Label label9;
    }
}

