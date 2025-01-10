// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace ScratchProject;

// As we can't currently design in VS in the runtime solution, mark as "Default" so this opens in code view by default.
[DesignerCategory("Default")]
public partial class Form1 : Form
{
    public Form1()
    {
        // This call is required by the designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call.
        LoadData();
    }

    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // after some line of code with careful consideration reload the data
        LoadData();
    }

    private void LoadData()
    {
        DataGridView1.Rows.Clear(); // remove the Clear command and everything works
        DataGridView1.Rows.Add(1, 0, "ABC");
        DataGridView1.Rows.Add(2, 0, "DEF");
    }
}
