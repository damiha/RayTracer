using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracing
{
    public partial class Form1 : Form
    {

        RayTracer rayTracer;

        float trackbarPositionUnit = 0.5f;
        float focalLengthUnit = 0.5f;

        bool renderFinished = false;
        bool progressBarFinished = false;

        public Form1()
        {
            InitializeComponent();

            rayTracer = new RayTracer();

            // raytracer mit drop down synchronisieren
            sceneComboBox.DataSource = Enum.GetValues(typeof(SceneType));
            sceneComboBox.SelectedItem = SceneType.Suzanne;

            renderComboBox.DataSource = Enum.GetValues(typeof(Resolution));
            renderComboBox.SelectedItem = Resolution.p_240;

            shadingComboBox.DataSource = Enum.GetValues(typeof(ShadingType));
            shadingComboBox.SelectedItem = ShadingType.Flat_Shading;

            // labels und raytracer mit trackbar synchronisieren
            xValueLabel.Text = $"Value: {posXTrackbar.Value * trackbarPositionUnit}";
            rayTracer.cameraPosX = posXTrackbar.Value * trackbarPositionUnit;

            yValueLabel.Text = $"Value: {posYTrackbar.Value * trackbarPositionUnit}";
            rayTracer.cameraPosY = posYTrackbar.Value * trackbarPositionUnit;

            zValueLabel.Text = $"Value: {posZTrackbar.Value * trackbarPositionUnit}";
            rayTracer.cameraPosZ = posZTrackbar.Value * trackbarPositionUnit;

            rotXValueLabel.Text = $"Value: {rotXTrackbar.Value}";
            rayTracer.cameraRotX = rotXTrackbar.Value;

            rotYValueLabel.Text = $"Value: {rotYTrackbar.Value}";
            rayTracer.cameraRotY = rotYTrackbar.Value;

            focalLengthValueLabel.Text = $"Value: {focalLengthTrackbar.Value * focalLengthUnit}";
            rayTracer.focalLength = focalLengthTrackbar.Value * focalLengthUnit;

            // raytracer mit checkboxen synchronisieren
            rayTracer.setBVHActivated(bvhCheckbox.Checked);

            // die background worker sollen nur einmal subscriben (die ganzen subscriptions werden jedes mal ausgeführt)
            renderBackgroundWorker.DoWork += new DoWorkEventHandler(renderImage);
            reportBackgroundWorker.DoWork += new DoWorkEventHandler(renderReport);
            reportBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(renderBackgroundWorker_ProgressChanged);
            reportBackgroundWorker.WorkerReportsProgress = true;

            // selektieren, um NullPointer exception abzuwenden
            lightsListBox.SelectedIndex = 0;
            materialListBox.SelectedIndex = 0;
            meshListBox.SelectedIndex = 0;

            shininessTrackbar.Value = getSelectedMaterial().specularity;
            shininessValueLabel.Text = $"Value: {getSelectedMaterial().specularity}";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rayTracer.setCurrentScene((SceneType)sceneComboBox.SelectedItem);

            // wenn die szene wechselt müssen in die mesh list view die neuen meshes eingetragen werden
            meshListBox.Items.Clear();
            materialListBox.Items.Clear();
            lightsListBox.Items.Clear();

            // Verhindere, dass Materialien (werden zwischen Meshes geteilt) doppelt eingefügt werden
            HashSet<string> materialNames = new HashSet<string>();

            foreach(Mesh mesh in rayTracer.currentScene.meshes)
            {
                meshListBox.Items.Add(mesh.name);

                if (!materialNames.Contains(mesh.material.name))
                {
                    materialListBox.Items.Add(mesh.material.name);
                    materialNames.Add(mesh.material.name);
                }
            }

            foreach(Light light in rayTracer.currentScene.lights)
            {
                lightsListBox.Items.Add(light.name);
            }

            // wieder selecten, um keine NullPointer-Probleme zu bekommen
            lightsListBox.SelectedIndex = 0;
            materialListBox.SelectedIndex = 0;
            meshListBox.SelectedIndex = 0;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            renderButton.Enabled = false;

            renderFinished = false;
            progressBarFinished = false;

            rayTracer.isDone = false;
            rayTracer.currentRenderProgress = 0.0f;
            renderProgressBar.Value = 0;

            renderBackgroundWorker.RunWorkerAsync();
            reportBackgroundWorker.RunWorkerAsync();

        }

        private void renderImage(object sender, DoWorkEventArgs e)
        {
            renderDisplay.Image = rayTracer.getFinalImage();
        }

        private void sceneComboBox_DropDown(object sender, EventArgs e)
        {
            sceneComboBox.SelectedIndex = 0;
        }

        private void renderProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void sceneLabel_Click(object sender, EventArgs e)
        {

        }

        private void renderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rayTracer.setResolution((Resolution) renderComboBox.SelectedItem);
        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            rayTracer.setBVHActivated(bvhCheckbox.Checked);
        }

        private void label2_Click_3(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void shadingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rayTracer.setShadingType((ShadingType) shadingComboBox.SelectedItem);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            rayTracer.setDrawFacets(checkBox2.Checked);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            shininessValueLabel.Text = $"Value: {shininessTrackbar.Value}";
            Material selectedMaterial = getSelectedMaterial();

            selectedMaterial.specularity = shininessTrackbar.Value;
        }

        private void posXTrackbar_Scroll(object sender, EventArgs e)
        {

        }

        private void posXTrackbar_ValueChanged(object sender, EventArgs e)
        {
            xValueLabel.Text = $"Value: {posXTrackbar.Value * trackbarPositionUnit}";
            rayTracer.cameraPosX = posXTrackbar.Value * trackbarPositionUnit;
        }

        private void posYTrackbar_ValueChanged(object sender, EventArgs e)
        {
            yValueLabel.Text = $"Value: {posYTrackbar.Value * trackbarPositionUnit}";
            rayTracer.cameraPosY = posYTrackbar.Value * trackbarPositionUnit;
        }

        private void posZTrackbar_ValueChanged(object sender, EventArgs e)
        {
            zValueLabel.Text = $"Value: {posZTrackbar.Value * trackbarPositionUnit}";
            rayTracer.cameraPosZ = posZTrackbar.Value * trackbarPositionUnit;
        }

        private void rotXTrackbar_ValueChanged(object sender, EventArgs e)
        {
            rotXValueLabel.Text = $"Value: {rotXTrackbar.Value}";
            rayTracer.cameraRotX = rotXTrackbar.Value;
        }

        private void rotYTrackbar_ValueChanged(object sender, EventArgs e)
        {
            rotYValueLabel.Text = $"Value: {rotYTrackbar.Value}";
            rayTracer.cameraRotY = rotYTrackbar.Value;
        }

        private void focalLengthTrackbar_ValueChanged(object sender, EventArgs e)
        {
            focalLengthValueLabel.Text = $"Value: {focalLengthTrackbar.Value * focalLengthUnit}";
            rayTracer.focalLength = focalLengthTrackbar.Value * focalLengthUnit;
        }

        private void xValueLabel_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                // hole das bild aus dem renderfenster und speicher es
                Image renderedImage = renderDisplay.Image;
                renderedImage.Save($"{dialog.FileName}.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        // hier wird in regelmäßigen abständen die neue prozentzahl berechnet
        // wenn die Funktion aufgerufen wird, sind wir im Background-Worker
        void renderReport(object sender, DoWorkEventArgs e)
        {
            while (!rayTracer.isDone)
            {
                reportBackgroundWorker.ReportProgress((int)rayTracer.getRenderProgress());

                // man muss nicht immer updaten
                System.Threading.Thread.Sleep(100);
            }
            reportBackgroundWorker.ReportProgress(100);
        }


        // TODO: why is this not fired!!!!!!
        private void renderBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            renderProgressBar.Value = e.ProgressPercentage;
        }

        private void exportObjButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog  = new SaveFileDialog();

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Mesh exportedMesh = rayTracer.currentScene.meshes[meshListBox.SelectedIndex];
                File.WriteAllText($"{dialog.FileName}.obj", exportedMesh.toObj());
            }
        }

        private void meshListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // aktiviere export to obj button nur, wenn genau ein objekt ausgewählt wurde
            exportObjButton.Enabled = meshListBox.SelectedItems.Count == 1;
        }

        private void renderBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            renderFinished = true;

            if (progressBarFinished)
            {
                renderButton.Enabled = true;
            }
        }

        private void reportBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarFinished = true;

            if (renderFinished)
            {
                renderButton.Enabled = true;
            }
        }

        private void lightsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // man kann nicht deselektieren bei einer ListBox, also ist immer etwas ausgewählt
            // setze die Farbwerte
            Light selectedLight = getSelectedLight();

            lightAmbientBox.BackColor = Util.getColor(selectedLight.I_a);
            lightDiffuseBox.BackColor = Util.getColor(selectedLight.I_d);
            lightSpecularBox.BackColor = Util.getColor(selectedLight.I_s);
        }

        private Material getSelectedMaterial()
        {
            return rayTracer.currentScene.materials[materialListBox.SelectedIndex];
        }

        private Light getSelectedLight()
        {
            return rayTracer.currentScene.lights[lightsListBox.SelectedIndex];
        }

        private void materialListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Material selectedMaterial = getSelectedMaterial();
            materialAmbientBox.BackColor = Util.getColor(selectedMaterial.K_a);
            materialDiffuseBox.BackColor = Util.getColor(selectedMaterial.K_d);
            materialSpecularBox.BackColor = Util.getColor(selectedMaterial.K_s);
        }

        private void materialAmbientBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = materialAmbientBox.BackColor;

            Material selectedMaterial = getSelectedMaterial();

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                materialAmbientBox.BackColor = dialog.Color;
                selectedMaterial.K_a = Util.getColor(dialog.Color);
            }
        }

        private void materialDiffuseBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = materialDiffuseBox.BackColor;

            Material selectedMaterial = getSelectedMaterial();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                materialDiffuseBox.BackColor = dialog.Color;
                selectedMaterial.K_d = Util.getColor(dialog.Color);
            }
        }

        private void materialSpecularBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = materialSpecularBox.BackColor;

            Material selectedMaterial = getSelectedMaterial();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                materialSpecularBox.BackColor = dialog.Color;
                selectedMaterial.K_s = Util.getColor(dialog.Color);
            }
        }

        private void lightAmbientBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = lightAmbientBox.BackColor;

            Light selectedLight = getSelectedLight();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lightAmbientBox.BackColor = dialog.Color;
                selectedLight.I_a = Util.getColor(dialog.Color);
            }
        }

        private void lightDiffuseBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = lightDiffuseBox.BackColor;

            Light selectedLight = getSelectedLight();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lightDiffuseBox.BackColor = dialog.Color;
                selectedLight.I_d = Util.getColor(dialog.Color);
            }
        }

        private void lightSpecularBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = lightSpecularBox.BackColor;

            Light selectedLight = getSelectedLight();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lightSpecularBox.BackColor = dialog.Color;
                selectedLight.I_s = Util.getColor(dialog.Color);
            }
        }
    }
}
