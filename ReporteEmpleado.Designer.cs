
namespace Sistema_D2_Seguridad_Privada
{
    partial class ReporteEmpleado
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteEmpleado));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DatosSD2 = new Sistema_D2_Seguridad_Privada.DatosSD2();
            this.d2_empleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.d2_empleadosTableAdapter = new Sistema_D2_Seguridad_Privada.DatosSD2TableAdapters.d2_empleadosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DatosSD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2_empleadosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DEmpleado";
            reportDataSource1.Value = this.d2_empleadosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema_D2_Seguridad_Privada.ReportEmpleado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1436, 808);
            this.reportViewer1.TabIndex = 0;
            // 
            // DatosSD2
            // 
            this.DatosSD2.DataSetName = "DatosSD2";
            this.DatosSD2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // d2_empleadosBindingSource
            // 
            this.d2_empleadosBindingSource.DataMember = "d2_empleados";
            this.d2_empleadosBindingSource.DataSource = this.DatosSD2;
            // 
            // d2_empleadosTableAdapter
            // 
            this.d2_empleadosTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1460, 832);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteEmpleado";
            this.Text = "Reporte Empleado";
            this.Load += new System.EventHandler(this.ReporteEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatosSD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2_empleadosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource d2_empleadosBindingSource;
        private DatosSD2 DatosSD2;
        private DatosSD2TableAdapters.d2_empleadosTableAdapter d2_empleadosTableAdapter;
    }
}