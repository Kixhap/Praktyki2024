namespace UIforAPI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.ListView itemsListView;
        private System.Windows.Forms.ColumnHeader idColumn;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader priceColumn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            nameBox = new TextBox();
            nameLabel = new Label();
            priceLabel = new Label();
            idLabel = new Label();
            idBox = new TextBox();
            priceBox = new TextBox();
            refreshButton = new Button();
            itemsListView = new ListView();
            idColumn = new ColumnHeader();
            nameColumn = new ColumnHeader();
            priceColumn = new ColumnHeader();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 335);
            addButton.Name = "addButton";
            addButton.Size = new Size(157, 36);
            addButton.TabIndex = 5;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(175, 335);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(145, 36);
            updateButton.TabIndex = 6;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(245, 377);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 36);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(78, 291);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(171, 27);
            nameBox.TabIndex = 3;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(78, 268);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(49, 20);
            nameLabel.TabIndex = 6;
            nameLabel.Text = "Name";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(255, 268);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(41, 20);
            priceLabel.TabIndex = 7;
            priceLabel.Text = "Price";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 268);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 20);
            idLabel.TabIndex = 8;
            idLabel.Text = "ID";
            // 
            // idBox
            // 
            idBox.Location = new Point(12, 291);
            idBox.Name = "idBox";
            idBox.ReadOnly = true;
            idBox.Size = new Size(60, 27);
            idBox.TabIndex = 2;
            // 
            // priceBox
            // 
            priceBox.Location = new Point(255, 291);
            priceBox.Name = "priceBox";
            priceBox.Size = new Size(65, 27);
            priceBox.TabIndex = 4;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(127, 10);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 36);
            refreshButton.TabIndex = 0;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // itemsListView
            // 
            itemsListView.Columns.AddRange(new ColumnHeader[] { idColumn, nameColumn, priceColumn });
            itemsListView.FullRowSelect = true;
            itemsListView.GridLines = true;
            itemsListView.Location = new Point(12, 52);
            itemsListView.Name = "itemsListView";
            itemsListView.Size = new Size(308, 200);
            itemsListView.TabIndex = 1;
            itemsListView.UseCompatibleStateImageBehavior = false;
            itemsListView.View = View.Details;
            itemsListView.SelectedIndexChanged += itemsListView_SelectedIndexChanged;
            // 
            // idColumn
            // 
            idColumn.Text = "ID";
            idColumn.Width = 50;
            // 
            // nameColumn
            // 
            nameColumn.Text = "Name";
            nameColumn.Width = 150;
            // 
            // priceColumn
            // 
            priceColumn.Text = "Price";
            priceColumn.Width = 100;
            // 
            // MainForm
            // 
            AcceptButton = addButton;
            ClientSize = new Size(337, 424);
            Controls.Add(refreshButton);
            Controls.Add(priceBox);
            Controls.Add(idBox);
            Controls.Add(idLabel);
            Controls.Add(priceLabel);
            Controls.Add(nameLabel);
            Controls.Add(nameBox);
            Controls.Add(deleteButton);
            Controls.Add(updateButton);
            Controls.Add(addButton);
            Controls.Add(itemsListView);
            Name = "MainForm";
            Text = "BasicUI";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label idLabel;
        private TextBox idBox;
        private TextBox priceBox;
        private Button refreshButton;
    }
}
