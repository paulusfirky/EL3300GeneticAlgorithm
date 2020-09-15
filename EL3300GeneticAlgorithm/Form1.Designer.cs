namespace EL3300GeneticAlgorithm
{
    partial class Form1
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
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.rbCrossRand = new System.Windows.Forms.RadioButton();
            this.lblCrossoverCtrl = new System.Windows.Forms.Label();
            this.rbNumCross = new System.Windows.Forms.RadioButton();
            this.lblMutationCtrl = new System.Windows.Forms.Label();
            this.rbRandMutation = new System.Windows.Forms.RadioButton();
            this.rbSetMutation = new System.Windows.Forms.RadioButton();
            this.numMutationChance = new System.Windows.Forms.NumericUpDown();
            this.numCrossovers = new System.Windows.Forms.NumericUpDown();
            this.lblPopulationSize = new System.Windows.Forms.Label();
            this.numPopSize = new System.Windows.Forms.NumericUpDown();
            this.lblFinish = new System.Windows.Forms.Label();
            this.rbEpochs = new System.Windows.Forms.RadioButton();
            this.rbTarget = new System.Windows.Forms.RadioButton();
            this.numEpochs = new System.Windows.Forms.NumericUpDown();
            this.numFitness = new System.Windows.Forms.NumericUpDown();
            this.gbCrossover = new System.Windows.Forms.GroupBox();
            this.gbMutation = new System.Windows.Forms.GroupBox();
            this.numMutations = new System.Windows.Forms.NumericUpDown();
            this.lblSetMutationChance = new System.Windows.Forms.Label();
            this.cbOffspring = new System.Windows.Forms.CheckBox();
            this.cbParents = new System.Windows.Forms.CheckBox();
            this.gbFinish = new System.Windows.Forms.GroupBox();
            this.lblPoolSize = new System.Windows.Forms.Label();
            this.numPoolSize = new System.Windows.Forms.NumericUpDown();
            this.tbBest = new System.Windows.Forms.TextBox();
            this.lblOverallBest = new System.Windows.Forms.Label();
            this.lblIterationBest = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossovers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFitness)).BeginInit();
            this.gbCrossover.SuspendLayout();
            this.gbMutation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutations)).BeginInit();
            this.gbFinish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPoolSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(290, 342);
            this.tbOutput.Margin = new System.Windows.Forms.Padding(2);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(502, 279);
            this.tbOutput.TabIndex = 100;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(498, 625);
            this.btnRun.Margin = new System.Windows.Forms.Padding(2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(87, 34);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // rbCrossRand
            // 
            this.rbCrossRand.AutoSize = true;
            this.rbCrossRand.Checked = true;
            this.rbCrossRand.Location = new System.Drawing.Point(10, 39);
            this.rbCrossRand.Name = "rbCrossRand";
            this.rbCrossRand.Size = new System.Drawing.Size(174, 17);
            this.rbCrossRand.TabIndex = 2;
            this.rbCrossRand.TabStop = true;
            this.rbCrossRand.Text = "Random Single Crossover Point";
            this.rbCrossRand.UseVisualStyleBackColor = true;
            // 
            // lblCrossoverCtrl
            // 
            this.lblCrossoverCtrl.AutoSize = true;
            this.lblCrossoverCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrossoverCtrl.Location = new System.Drawing.Point(6, 16);
            this.lblCrossoverCtrl.Name = "lblCrossoverCtrl";
            this.lblCrossoverCtrl.Size = new System.Drawing.Size(161, 20);
            this.lblCrossoverCtrl.TabIndex = 3;
            this.lblCrossoverCtrl.Text = "Crossover Controls";
            // 
            // rbNumCross
            // 
            this.rbNumCross.AutoSize = true;
            this.rbNumCross.Location = new System.Drawing.Point(10, 62);
            this.rbNumCross.Name = "rbNumCross";
            this.rbNumCross.Size = new System.Drawing.Size(124, 17);
            this.rbNumCross.TabIndex = 4;
            this.rbNumCross.Text = "Set # of Crossovers: ";
            this.rbNumCross.UseVisualStyleBackColor = true;
            // 
            // lblMutationCtrl
            // 
            this.lblMutationCtrl.AutoSize = true;
            this.lblMutationCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMutationCtrl.Location = new System.Drawing.Point(6, 16);
            this.lblMutationCtrl.Name = "lblMutationCtrl";
            this.lblMutationCtrl.Size = new System.Drawing.Size(151, 20);
            this.lblMutationCtrl.TabIndex = 6;
            this.lblMutationCtrl.Text = "Mutation Controls";
            // 
            // rbRandMutation
            // 
            this.rbRandMutation.AutoSize = true;
            this.rbRandMutation.Location = new System.Drawing.Point(10, 116);
            this.rbRandMutation.Name = "rbRandMutation";
            this.rbRandMutation.Size = new System.Drawing.Size(136, 17);
            this.rbRandMutation.TabIndex = 6;
            this.rbRandMutation.Text = "Random # of Mutations";
            this.rbRandMutation.UseVisualStyleBackColor = true;
            // 
            // rbSetMutation
            // 
            this.rbSetMutation.AutoSize = true;
            this.rbSetMutation.Checked = true;
            this.rbSetMutation.Location = new System.Drawing.Point(10, 93);
            this.rbSetMutation.Name = "rbSetMutation";
            this.rbSetMutation.Size = new System.Drawing.Size(145, 17);
            this.rbSetMutation.TabIndex = 7;
            this.rbSetMutation.TabStop = true;
            this.rbSetMutation.Text = "Set Number of Mutations:";
            this.rbSetMutation.UseVisualStyleBackColor = true;
            // 
            // numMutationChance
            // 
            this.numMutationChance.Location = new System.Drawing.Point(118, 67);
            this.numMutationChance.Name = "numMutationChance";
            this.numMutationChance.Size = new System.Drawing.Size(48, 20);
            this.numMutationChance.TabIndex = 8;
            this.numMutationChance.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numCrossovers
            // 
            this.numCrossovers.Location = new System.Drawing.Point(140, 62);
            this.numCrossovers.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.numCrossovers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCrossovers.Name = "numCrossovers";
            this.numCrossovers.Size = new System.Drawing.Size(48, 20);
            this.numCrossovers.TabIndex = 5;
            this.numCrossovers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPopulationSize
            // 
            this.lblPopulationSize.AutoSize = true;
            this.lblPopulationSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPopulationSize.Location = new System.Drawing.Point(13, 11);
            this.lblPopulationSize.Name = "lblPopulationSize";
            this.lblPopulationSize.Size = new System.Drawing.Size(134, 20);
            this.lblPopulationSize.TabIndex = 11;
            this.lblPopulationSize.Text = "Population Size";
            // 
            // numPopSize
            // 
            this.numPopSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPopSize.Location = new System.Drawing.Point(17, 35);
            this.numPopSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPopSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPopSize.Name = "numPopSize";
            this.numPopSize.Size = new System.Drawing.Size(72, 20);
            this.numPopSize.TabIndex = 1;
            this.numPopSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblFinish
            // 
            this.lblFinish.AutoSize = true;
            this.lblFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinish.Location = new System.Drawing.Point(6, 16);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(144, 20);
            this.lblFinish.TabIndex = 13;
            this.lblFinish.Text = "Stopping Criteria";
            // 
            // rbEpochs
            // 
            this.rbEpochs.AutoSize = true;
            this.rbEpochs.Checked = true;
            this.rbEpochs.Location = new System.Drawing.Point(10, 39);
            this.rbEpochs.Name = "rbEpochs";
            this.rbEpochs.Size = new System.Drawing.Size(116, 17);
            this.rbEpochs.TabIndex = 9;
            this.rbEpochs.TabStop = true;
            this.rbEpochs.Text = "Number of Epochs:";
            this.rbEpochs.UseVisualStyleBackColor = true;
            // 
            // rbTarget
            // 
            this.rbTarget.AutoSize = true;
            this.rbTarget.Location = new System.Drawing.Point(10, 63);
            this.rbTarget.Name = "rbTarget";
            this.rbTarget.Size = new System.Drawing.Size(95, 17);
            this.rbTarget.TabIndex = 11;
            this.rbTarget.Text = "Target Fitness:";
            this.rbTarget.UseVisualStyleBackColor = true;
            // 
            // numEpochs
            // 
            this.numEpochs.Location = new System.Drawing.Point(132, 39);
            this.numEpochs.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numEpochs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEpochs.Name = "numEpochs";
            this.numEpochs.Size = new System.Drawing.Size(58, 20);
            this.numEpochs.TabIndex = 10;
            this.numEpochs.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numFitness
            // 
            this.numFitness.Location = new System.Drawing.Point(111, 63);
            this.numFitness.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numFitness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFitness.Name = "numFitness";
            this.numFitness.Size = new System.Drawing.Size(48, 20);
            this.numFitness.TabIndex = 12;
            this.numFitness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gbCrossover
            // 
            this.gbCrossover.Controls.Add(this.rbCrossRand);
            this.gbCrossover.Controls.Add(this.rbNumCross);
            this.gbCrossover.Controls.Add(this.numCrossovers);
            this.gbCrossover.Controls.Add(this.lblCrossoverCtrl);
            this.gbCrossover.Location = new System.Drawing.Point(10, 106);
            this.gbCrossover.Name = "gbCrossover";
            this.gbCrossover.Size = new System.Drawing.Size(275, 95);
            this.gbCrossover.TabIndex = 101;
            this.gbCrossover.TabStop = false;
            // 
            // gbMutation
            // 
            this.gbMutation.Controls.Add(this.numMutations);
            this.gbMutation.Controls.Add(this.lblSetMutationChance);
            this.gbMutation.Controls.Add(this.cbOffspring);
            this.gbMutation.Controls.Add(this.cbParents);
            this.gbMutation.Controls.Add(this.lblMutationCtrl);
            this.gbMutation.Controls.Add(this.rbRandMutation);
            this.gbMutation.Controls.Add(this.rbSetMutation);
            this.gbMutation.Controls.Add(this.numMutationChance);
            this.gbMutation.Location = new System.Drawing.Point(12, 207);
            this.gbMutation.Name = "gbMutation";
            this.gbMutation.Size = new System.Drawing.Size(275, 164);
            this.gbMutation.TabIndex = 102;
            this.gbMutation.TabStop = false;
            // 
            // numMutations
            // 
            this.numMutations.Location = new System.Drawing.Point(152, 93);
            this.numMutations.Margin = new System.Windows.Forms.Padding(2);
            this.numMutations.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.numMutations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMutations.Name = "numMutations";
            this.numMutations.Size = new System.Drawing.Size(48, 20);
            this.numMutations.TabIndex = 12;
            this.numMutations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSetMutationChance
            // 
            this.lblSetMutationChance.AutoSize = true;
            this.lblSetMutationChance.Location = new System.Drawing.Point(7, 68);
            this.lblSetMutationChance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSetMutationChance.Name = "lblSetMutationChance";
            this.lblSetMutationChance.Size = new System.Drawing.Size(108, 13);
            this.lblSetMutationChance.TabIndex = 11;
            this.lblSetMutationChance.Text = "Mutation Chance (%):";
            // 
            // cbOffspring
            // 
            this.cbOffspring.AutoSize = true;
            this.cbOffspring.Location = new System.Drawing.Point(122, 39);
            this.cbOffspring.Margin = new System.Windows.Forms.Padding(2);
            this.cbOffspring.Name = "cbOffspring";
            this.cbOffspring.Size = new System.Drawing.Size(104, 17);
            this.cbOffspring.TabIndex = 10;
            this.cbOffspring.Text = "Mutate Offspring";
            this.cbOffspring.UseVisualStyleBackColor = true;
            this.cbOffspring.CheckedChanged += new System.EventHandler(this.cbOffspring_CheckedChanged);
            // 
            // cbParents
            // 
            this.cbParents.AutoSize = true;
            this.cbParents.Checked = true;
            this.cbParents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbParents.Location = new System.Drawing.Point(10, 39);
            this.cbParents.Margin = new System.Windows.Forms.Padding(2);
            this.cbParents.Name = "cbParents";
            this.cbParents.Size = new System.Drawing.Size(98, 17);
            this.cbParents.TabIndex = 9;
            this.cbParents.Text = "Mutate Parents";
            this.cbParents.UseVisualStyleBackColor = true;
            this.cbParents.CheckedChanged += new System.EventHandler(this.cbParents_CheckedChanged);
            // 
            // gbFinish
            // 
            this.gbFinish.Controls.Add(this.lblFinish);
            this.gbFinish.Controls.Add(this.rbEpochs);
            this.gbFinish.Controls.Add(this.rbTarget);
            this.gbFinish.Controls.Add(this.numFitness);
            this.gbFinish.Controls.Add(this.numEpochs);
            this.gbFinish.Location = new System.Drawing.Point(10, 377);
            this.gbFinish.Name = "gbFinish";
            this.gbFinish.Size = new System.Drawing.Size(275, 97);
            this.gbFinish.TabIndex = 103;
            this.gbFinish.TabStop = false;
            // 
            // lblPoolSize
            // 
            this.lblPoolSize.AutoSize = true;
            this.lblPoolSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoolSize.Location = new System.Drawing.Point(16, 59);
            this.lblPoolSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoolSize.Name = "lblPoolSize";
            this.lblPoolSize.Size = new System.Drawing.Size(174, 20);
            this.lblPoolSize.TabIndex = 104;
            this.lblPoolSize.Text = "Parent Pool Size (%)";
            // 
            // numPoolSize
            // 
            this.numPoolSize.Location = new System.Drawing.Point(16, 83);
            this.numPoolSize.Margin = new System.Windows.Forms.Padding(2);
            this.numPoolSize.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.numPoolSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPoolSize.Name = "numPoolSize";
            this.numPoolSize.Size = new System.Drawing.Size(54, 20);
            this.numPoolSize.TabIndex = 105;
            this.numPoolSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tbBest
            // 
            this.tbBest.Location = new System.Drawing.Point(290, 34);
            this.tbBest.Margin = new System.Windows.Forms.Padding(2);
            this.tbBest.Multiline = true;
            this.tbBest.Name = "tbBest";
            this.tbBest.ReadOnly = true;
            this.tbBest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBest.Size = new System.Drawing.Size(502, 279);
            this.tbBest.TabIndex = 106;
            // 
            // lblOverallBest
            // 
            this.lblOverallBest.AutoSize = true;
            this.lblOverallBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverallBest.Location = new System.Drawing.Point(286, 11);
            this.lblOverallBest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOverallBest.Name = "lblOverallBest";
            this.lblOverallBest.Size = new System.Drawing.Size(111, 20);
            this.lblOverallBest.TabIndex = 107;
            this.lblOverallBest.Text = "Overall Best:";
            // 
            // lblIterationBest
            // 
            this.lblIterationBest.AutoSize = true;
            this.lblIterationBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIterationBest.Location = new System.Drawing.Point(292, 320);
            this.lblIterationBest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIterationBest.Name = "lblIterationBest";
            this.lblIterationBest.Size = new System.Drawing.Size(119, 20);
            this.lblIterationBest.TabIndex = 108;
            this.lblIterationBest.Text = "Iteration Best";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 670);
            this.Controls.Add(this.lblIterationBest);
            this.Controls.Add(this.lblOverallBest);
            this.Controls.Add(this.tbBest);
            this.Controls.Add(this.numPoolSize);
            this.Controls.Add(this.lblPoolSize);
            this.Controls.Add(this.gbFinish);
            this.Controls.Add(this.gbMutation);
            this.Controls.Add(this.gbCrossover);
            this.Controls.Add(this.numPopSize);
            this.Controls.Add(this.lblPopulationSize);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbOutput);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "EL3300 Genetic Algorithm";
            ((System.ComponentModel.ISupportInitialize)(this.numMutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossovers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpochs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFitness)).EndInit();
            this.gbCrossover.ResumeLayout(false);
            this.gbCrossover.PerformLayout();
            this.gbMutation.ResumeLayout(false);
            this.gbMutation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutations)).EndInit();
            this.gbFinish.ResumeLayout(false);
            this.gbFinish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPoolSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.RadioButton rbCrossRand;
        private System.Windows.Forms.Label lblCrossoverCtrl;
        private System.Windows.Forms.RadioButton rbNumCross;
        private System.Windows.Forms.Label lblMutationCtrl;
        private System.Windows.Forms.RadioButton rbRandMutation;
        private System.Windows.Forms.RadioButton rbSetMutation;
        private System.Windows.Forms.NumericUpDown numMutationChance;
        private System.Windows.Forms.NumericUpDown numCrossovers;
        private System.Windows.Forms.Label lblPopulationSize;
        private System.Windows.Forms.NumericUpDown numPopSize;
        private System.Windows.Forms.Label lblFinish;
        private System.Windows.Forms.RadioButton rbEpochs;
        private System.Windows.Forms.RadioButton rbTarget;
        private System.Windows.Forms.NumericUpDown numEpochs;
        private System.Windows.Forms.NumericUpDown numFitness;
        private System.Windows.Forms.GroupBox gbCrossover;
        private System.Windows.Forms.GroupBox gbMutation;
        private System.Windows.Forms.GroupBox gbFinish;
        private System.Windows.Forms.Label lblPoolSize;
        private System.Windows.Forms.NumericUpDown numPoolSize;
        private System.Windows.Forms.TextBox tbBest;
        private System.Windows.Forms.Label lblOverallBest;
        private System.Windows.Forms.Label lblIterationBest;
        private System.Windows.Forms.CheckBox cbOffspring;
        private System.Windows.Forms.CheckBox cbParents;
        private System.Windows.Forms.Label lblSetMutationChance;
        private System.Windows.Forms.NumericUpDown numMutations;
    }
}

