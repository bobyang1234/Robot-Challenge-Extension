
namespace Robot_Challenge
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.txtbox_validcommand = new System.Windows.Forms.TextBox();
            this.lbl_validcommanddefinition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbox_validcommand
            // 
            this.txtbox_validcommand.Location = new System.Drawing.Point(12, 38);
            this.txtbox_validcommand.Multiline = true;
            this.txtbox_validcommand.Name = "txtbox_validcommand";
            this.txtbox_validcommand.ReadOnly = true;
            this.txtbox_validcommand.Size = new System.Drawing.Size(776, 315);
            this.txtbox_validcommand.TabIndex = 21;
            this.txtbox_validcommand.Text = resources.GetString("txtbox_validcommand.Text");
            // 
            // lbl_validcommanddefinition
            // 
            this.lbl_validcommanddefinition.AutoSize = true;
            this.lbl_validcommanddefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_validcommanddefinition.Location = new System.Drawing.Point(12, 10);
            this.lbl_validcommanddefinition.Name = "lbl_validcommanddefinition";
            this.lbl_validcommanddefinition.Size = new System.Drawing.Size(259, 25);
            this.lbl_validcommanddefinition.TabIndex = 22;
            this.lbl_validcommanddefinition.Text = "Valid Command Definition";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_validcommanddefinition);
            this.Controls.Add(this.txtbox_validcommand);
            this.Name = "HelpForm";
            this.Text = "HelpForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox_validcommand;
        private System.Windows.Forms.Label lbl_validcommanddefinition;
    }
}